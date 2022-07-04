using GigaaGymAssistant.Domain.Common.Models.User;

namespace GigaaGymAssistant.Interfaces.Infrastructure
{
    public interface IAccountSrv
    {
        UserDTO RegisterUser(RegisterDTO registerDTO);
        UserDTO LoginUser(LoginDTO loginDTO);
    }
}
