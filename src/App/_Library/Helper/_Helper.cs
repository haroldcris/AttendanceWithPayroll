using DevComponents.DotNetBar.Validator;
using System;
using System.Windows.Forms;

public static partial class Helper
{
    internal static Winform.frmMain MainForm { get; set; }

    internal static void ClearErrorDisplay(Control control, ErrorProvider errorProvider = null, Highlighter highlighter = null)
    {
        if (errorProvider != null)
            errorProvider.Clear();

        if (highlighter != null)
            highlighter.SetHighlightColor(control, DevComponents.DotNetBar.Validator.eHighlightColor.None);
    }

    internal static void HandleEnterKey(Form form, KeyPressEventArgs e)
    {
        if ((e.KeyChar == (int)Keys.Enter) || (e.KeyChar == (int)Keys.Return))
        {
            Console.WriteLine("Next Control " + form.ActiveControl.Name); ;
            form.SelectNextControl(form.ActiveControl, true, true, true, true);
            e.Handled = true;
        }
    }


    internal static void HandleComboAutoComplete(ComboBox control, KeyPressEventArgs e)
    {
        if (char.IsControl(e.KeyChar))
        {
            //let it go if it's a control char such as escape, tab, backspace, enter...
            return;
        }

        ComboBox box = ((ComboBox)control);

        //must get the selected portion only. Otherwise, we append the e.KeyChar to the AutoSuggested value (i.e. we'd never get anywhere)
        string nonSelected = box.Text.Substring(0, box.Text.Length - box.SelectionLength);

        string text = nonSelected + e.KeyChar;
        //if(box.Items.ToString().StartsWith(text)

        bool matched = false;
        for (int i = 0; i < box.Items.Count; i++)
        {
            if (box.Items[i].ToString().ToLowerInvariant().StartsWith(text, StringComparison.CurrentCultureIgnoreCase))
            {
                matched = true;
                break;
            }
        }

        //toggle the matched bool because if we set handled to true, it precent's input, and we don't want to prevent
        //input if it's matched.
        e.Handled = !matched;
    }
 



}



