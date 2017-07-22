using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using AiTech.Database;
using AiTech.Properties;

namespace AiTech.Account
{
    public sealed class Credential
    {

        public static AccountToken GetAppToken(AccountUser user)
        {
            using (var db = Database.Connection.CreateConnection())
            {
                db.Open();

                var appToken = new AccountToken()
                {
                    Username = user.Username,
                    Token = TokenGenerator.Generate(128),

                    WindowsUsername = Environment.UserName,
                    MachineName = Environment.MachineName,
                    IpAddress = Network.GetIpAddresses(),

                    CreatedBy = user.Username,
                    ModifiedBy = user.Username,
                };

                var ret = db.Query(@"INSERT INTO AccountToken (Username, Token, WindowsUsername, MachineName, IpAddress, ModifiedBy, CreatedBy) VALUES 
                                    (@Username, @Token, @WindowsUsername, @MachineName, @IpAddress, @encoder, @encoder)",
                                new
                                {
                                    Username = appToken.Username,
                                    Token = appToken.Token,
                                    WindowsUsername = appToken.WindowsUsername,
                                    MachineName = appToken.MachineName,
                                    IpAddress = appToken.IpAddress,
                                    Encoder = user.Username
                                });

                return appToken;
            }
        }

        public static async Task<AccountUser> AuthenticateAsync(string userName, string password)
        {
            var result = Task.Factory.StartNew<AccountUser>(() =>
            {
                return Authenticate(userName, password);
            });

            return await result;
        }

        public static AccountUser Authenticate(string userName, string password)
        {
            //var appToken = null;
            //System.Threading.Thread.Sleep(3000);
            using (var db = Connection.CreateConnection())
            {
                db.Open();

                var encryptedPassword = Password.Encrypt(password);

                var user = db.Query<AccountUser>("Select username from AccountUser where username = @user and password = @pwd", new { user = userName, pwd = encryptedPassword }).FirstOrDefault();

                if (user == null) return null;

                return user;
            }

        }

        //    public static bool IsValidToken(string token)
        //    {            
        //        using (var db = DbConnection.CreateConnection())
        //        {
        //            db.Open();
        //            var ret = db.Query<AccountUser>("Select username from AccountToken where token = @Token and Expiration > getdate()", new { Token = token }).FirstOrDefault();

        //            if (ret == null) return false;

        //            return true;
        //        }
        //    }

    }
}
