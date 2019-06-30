using System;

namespace Actio.Common.ICommands
{
    public interface IAuthenticateUser : ICommand
    {
        Guid UserId { get; set; }
    }
}