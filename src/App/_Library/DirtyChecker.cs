﻿using System;
using System.Drawing;
using System.Windows.Forms;

/// <summary>
/// Monitor every form if it has pending changes
/// to be saved in the database
/// </summary>
public class DirtyChecker
{
    private readonly ISave _form;
    private Color _defaultColor;

    private readonly Winform.frmMain MainMDIForm;

    public bool IsDirty { get; private set; }

    public DirtyChecker(ISave form)
    {
        _form = form;
        IsDirty = false;

        MainMDIForm = (Winform.frmMain)((Form)form).MdiParent;

        SubscribeToControlCollection(((Form)form).Controls);
    }


    private void SubscribeToControlCollection(Control.ControlCollection coll)
    {
        foreach (Control c in coll)
        {
            if (c is TextBox ||
                c is ComboBox)
                c.TextChanged += Control_TextChanged;

            if (c is DateTimePicker)
                ((DateTimePicker)c).ValueChanged += Control_TextChanged;

            if (c is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                ((DevComponents.Editors.DateTimeAdv.DateTimeInput)c).ValueChanged += Control_TextChanged;


            if (c is DevComponents.DotNetBar.SuperGrid.SuperGridControl)
                ((DevComponents.DotNetBar.SuperGrid.SuperGridControl)c).RowMarkedDirty += (s, arg) => SetDirty();

            if (c is CheckBox)
                (c as CheckBox).CheckedChanged += Control_CheckChanged;

            if (c is DevComponents.DotNetBar.Controls.SwitchButton)
                ((DevComponents.DotNetBar.Controls.SwitchButton)c).ValueChanged += (s, e) => SetDirty();


            // recurively apply to inner collections
            if (c.HasChildren)
                SubscribeToControlCollection(c.Controls);
        }
    }

    private void Control_TextChanged(object sender, EventArgs e)
    {
        SetDirty();
    }

    private void Control_CheckChanged(object sender, EventArgs e)
    {
        SetDirty();
    }


    public void Clear()
    {
        IsDirty = false;

        var form = (Form)_form;
        var title = form.Text;

        if (!form.IsMdiChild) return;

        if (title.Substring(title.Length - 1) == "*")
            form.Text = form.Tag.ToString();

        UpdateMDIForm();
    }

    public void SetDirty()
    {
        IsDirty = true;
        var title = ((Form)_form).Text;

        if (!((Form)_form).IsMdiChild) return;

        //Change Form Caption
        if (title.Substring(title.Length - 1) != "*")
            title += " *";
        ((Form)_form).Text = title;

        UpdateMDIForm();
    }



    public void UpdateMDIForm(bool leavingFocus = false)
    {
        if (MainMDIForm == null) return;

        var statusBar = MainMDIForm.StatusBar;

        if (leavingFocus)
        {
            //Clear Error
            MainMDIForm.cmdSave.Enabled = false;
            MainMDIForm.lblStatus.Text = @"Ready";
            statusBar.Refresh();
            return;
        }

        if (statusBar.BackColor != Color.Red)
        {
            _defaultColor = statusBar.BackColor;
        }

        if (IsDirty)
        {
            //Set Dirty
            statusBar.BackColor = System.Drawing.Color.Red;
            MainMDIForm.lblStatus.Text = @"Pending changes detected. Save is required";
        }
        else
        {

            //Clear Error
            statusBar.BackColor = _defaultColor;
            statusBar.BackColor = new Color();
            MainMDIForm.lblStatus.Text = @"Ready";
        }

        statusBar.Refresh();

        //Enable Save Buttons
        MainMDIForm.cmdSave.Enabled = IsDirty;
    }


}

