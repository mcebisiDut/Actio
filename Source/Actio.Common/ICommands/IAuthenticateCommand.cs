using System;

namespace Actio.Common.ICommands
{
    public interface IAuthenticateCommand : ICommand
    {
         Guid UserId{get;set;}
    }
}