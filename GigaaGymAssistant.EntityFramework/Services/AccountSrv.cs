using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Interfaces.Infrastructure;

namespace GigaaGymAssistant.Infrastructure.EntityFramework.Services
{
    public class AccountSrv : IAccountSrv
    {
        public UserDTO RegisterUser(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO LoginUser(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}
