using System.Threading.Tasks;
using Actio.Common.Authentication;
using Actio.Common.Exceptions;
using Actio.Common.IAuthentication;
using Authentication.IEncryption;
using Authentication.IRepositories;
using Authentication.IServices;
using Authentication.Models;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        public async Task RegisterAsync(string email, string password, string name)
        {
            var user = await _userRepository.GetAsync(email) ??
                                throw new ActioException("email_in_use", $"Email: '{email}' is already in use.");

            user = new User(email, name);
            user.SetPassword(password, _encrypter);
            await _userRepository.AddAsync(user);
        }

        public async Task<JsonWebToken> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email) ??
                                throw new ActioException("invalid_credentials", $"Invalid credentials.");

            if (!user.ValidatePassword(password, _encrypter))
            {
                throw new ActioException("invalid_credentials", $"Invalid credentials.");
            }

            return _jwtHandler.Create(user.Id);
        }
    }
}