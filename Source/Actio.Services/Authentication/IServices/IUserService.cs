using System.Threading.Tasks;
using Actio.Common.Authentication;

namespace Authentication.IServices
{
    public interface IUserService
    {
         Task RegisterAsync(string email, string password, string name);
         Task<JsonWebToken> LoginAsync(string email, string password);
    }
}