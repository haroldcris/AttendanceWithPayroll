using AiTech.LiteOrm.Database;
using AiTech.Security;
using System.Threading.Tasks;

namespace Dll.Security
{
    public class Credential
    {

        public static async Task<UserAccount> AuthenticateAsync(string username, string password)
        {
            var service = new AuthenticationService(Connection.CreateConnection().ConnectionString);

            return await service.AuthenticateAsync(username, password);
        }


        public UserAccount Authenticate(string username, string password)
        {
            var service = new AuthenticationService(Connection.CreateConnection().ConnectionString);

            return service.Authenticate(username, password);
        }


    }
}
