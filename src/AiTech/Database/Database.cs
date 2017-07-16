using System;
using System.Data.SqlClient;
using System.IO;

namespace AiTech.Database
{
    public sealed class Connection
    {
        public static DatabaseCredential MyDbCredential;
        private static bool CredentialIsLoaded;
        private static void LoadCredential()
        {
            var settings = new System.Xml.XmlDocument();

            if (!System.IO.File.Exists("credentials.xml")) throw new FileNotFoundException("Credential File NOT Found!");

            try
            {
                settings.Load("credentials.xml");

            } catch
            {
                throw;
            }

            var rootNode = settings.SelectSingleNode("Settings");

            var node = rootNode.SelectSingleNode("Connection");
            if (node == null) throw new Exception("Can not Read Connection Settings");

            MyDbCredential.ServerName  = node.Attributes["ServerIp"].Value;
            MyDbCredential.DatabaseName = node.Attributes["Database"].Value;
            MyDbCredential.Username = Password.Decrypt(node.Attributes["Username"].Value);
            MyDbCredential.Password = Password.Decrypt(node.Attributes["Password"].Value);

            CredentialIsLoaded = true;
        }

        public static SqlConnection CreateConnection()
        {
            //System.Threading.Thread.Sleep(2000);

            if (!CredentialIsLoaded) LoadCredential();

            if (string.IsNullOrEmpty(MyDbCredential.DatabaseName)) throw new Exception("Database Credential NOT set!");

            var credential = MyDbCredential;

            var builder = new SqlConnectionStringBuilder()
            {
                DataSource = credential.ServerName,
                InitialCatalog = credential.DatabaseName,
                UserID = credential.Username,
                Password = credential.Password,
                IntegratedSecurity = credential.IntegratedSecurity,
                MultipleActiveResultSets = true
            };

            return new SqlConnection(builder.ToString());
        }

    }
}
