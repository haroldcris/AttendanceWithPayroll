using System.Windows.Forms;

namespace Library.Tools
{
    internal static partial class InputControls
    {

        public static class Form
        {

            public static void AskToSaveOnDirtyClosing(ISave frm)
            {
                ((System.Windows.Forms.Form)frm).FormClosing += (s, e) =>
               {

                   switch (e.CloseReason)
                   {
                       case CloseReason.None:
                       case CloseReason.UserClosing:
                           //Check for Dirty
                           if (!frm.DirtyStatus.IsDirty) break;

                           var response = App.Message.AskToSave();

                           switch (response)
                           {
                               case MessageDialogResult.Yes:
                                   if (!frm.FileSave()) e.Cancel = true;
                                   break;

                               case MessageDialogResult.Cancel:
                                   e.Cancel = true;
                                   break;
                           }
                           break;
                   }
               };
            }


            public static void ConvertEnterToTab(System.Windows.Forms.Form form)
            {
                form.KeyPreview = true;
                form.KeyPress += (s, e) =>
                {
                    if ((e.KeyChar != (int)Keys.Enter) && (e.KeyChar != (int)Keys.Return)) return;

                    //Console.WriteLine("Next Control " + form.ActiveControl.Name); ;
                    form.SelectNextControl(form.ActiveControl, true, true, true, true);
                    e.Handled = true;
                };
            }
        }

    }
}
