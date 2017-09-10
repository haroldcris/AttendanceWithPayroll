using AiTech.LiteOrm.Database;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Library.Tools
{
    internal static partial class InputControls
    {
        public static void LoadImage(PictureBox control, string filenameFromServer)
        {
            if (string.IsNullOrEmpty(filenameFromServer)) return;

            var path = string.Format("http://{0}/amwp/pictures/{1}.jpg", Connection.MyDbCredential.ServerName, filenameFromServer);

            control.LoadAsync(path);
        }


        public static Image GetImage(string filenameFromServer)
        {
            var pb = new PictureBox();
            try
            {
                if (string.IsNullOrEmpty(filenameFromServer)) return null;

                var path = string.Format("http://{0}/amwp/pictures/{1}.jpg",
                    Connection.MyDbCredential.ServerName, filenameFromServer);

                Debug.WriteLine(path);

                //pb.WaitOnLoad = false;
                pb.Load(path);

                return pb.Image;
            }
            catch
            {
                return pb.ErrorImage;
            }
        }
    }
}