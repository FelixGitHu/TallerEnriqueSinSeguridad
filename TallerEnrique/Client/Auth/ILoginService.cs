using TallerEnrique.Shared.Complement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerEnrique.Client.Auth
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task Logout();
        Task ManejarRenovacionToken();
    }
}
