using System;
using Actio.Common.Exceptions;
using Authentication.IEncryption;

namespace Authentication.Models
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Name { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string name)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(name))
            {
                throw new ActioException("Invalid_Credentials", "Check your credentails and try again");
            }
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Name = name;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ActioException("Invalid_Password", "Password can not be empty");
            }
            Salt = encrypter.GetSalt(password);
            Password = encrypter.GetHash(password,Salt);
        }

        public bool ValidatePassword(string password, IEncrypter encrypter)
            => Password.Equals(encrypter.GetHash(password,Salt));
    }
}