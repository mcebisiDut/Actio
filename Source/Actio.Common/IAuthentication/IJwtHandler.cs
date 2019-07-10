using System;
using Actio.Common.Authentication;

namespace Actio.Common.IAuthentication
{
    public interface IJwtHandler
    {
         JsonWebToken Create(Guid userId);
    }
}