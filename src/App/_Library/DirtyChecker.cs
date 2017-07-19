using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Monitor every form if it has pending changes
/// to be saved in the database
/// </summary>
public class DirtyChecker
{
    private ISave _form;
    private bool _IsDirty;

    private Winform.frmMain MainMDIForm;

    public bool IsDirty
    {
        get { return _IsDirty; }
    }

    public DirtyChecker(ISave form)
    {
        _form = form;
        _IsDirty = false;

        MainMDIForm = (Winform.frmMain)((Form)form).MdiParent;

        SubscribeToControlCollection(((Form)form).Controls);
    }


    private void SubscribeToControlCollection(Control.ControlCollection coll)
    {
        foreach (Control c in coll)
        {
            if (c is TextBox  ||
                c is ComboBox ) 
                c.TextChanged += Control_TextChanged;

            if (c is DateTimePicker)
                ((DateTimePicker)c).ValueChanged += Control_TextChanged;

            if (c is DevComponents.Editors.DateTimeAdv.DateTimeInput)
                ((DevComponents.Editors.DateTimeAdv.DateTimeInput)c).ValueChanged += Control_TextChanged;

            //if(c is ComboBox)
            //    (c as ComboBox).TextChanged += Control_TextChanged;

            if (c is CheckBox)
                (c as CheckBox).CheckedChanged += Control_CheckChanged;

            // recurively apply to inner collections
            if (c.HasChildren)
                SubscribeToControlCollection(c.Controls);
        }
    }

    private void Control_TextChanged(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //_IsDirty = true;
        SetDirty();
    }

    private void Control_CheckChanged(object sender, EventArgs e)
    {
        //throw new NotImplementedException();
        //_IsDirty = true;
        SetDirty();
    }


    public void Clear()
    {
        _IsDirty = false;
        var form = (Form)_form;
        var title = form.Text;

        if (title.Substring(title.Length - 1) == "*")
            form.Text = form.Tag.ToString();

        UpdateMDIForm();
    }

    public void SetDirty()
    {
        _IsDirty = true;
        var title = ((Form)_form).Text;


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
            statusBar.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            MainMDIForm.cmdSave.Enabled = false;
            MainMDIForm.lblStatus.Text = "Ready";
            statusBar.Refresh();
            return;
        }


        if (_IsDirty)
        {
            //Set Dirty
            statusBar.BackgroundStyle.BackColor = System.Drawing.Color.Red;
            MainMDIForm.lblStatus.Text = "Pending changes detected. Save is required";
        }
        else
        {
            //Clear Error
            //statusBar.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionBackground;
            statusBar.BackgroundStyle.BackColor = new System.Drawing.Color();
            //statusBar.BackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBorder;
            MainMDIForm.lblStatus.Text = "Ready";
        }

        statusBar.Refresh();

        //Enable Save Buttons
        MainMDIForm.cmdSave.Enabled = _IsDirty;
    }


}

