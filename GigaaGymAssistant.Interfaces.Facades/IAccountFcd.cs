using GigaaGymAssistant.Domain.Common.Models.User;

namespace GigaaGymAssistant.Interfaces.Facades
{
    public interface IAccountFcd
    {
        UserDTO RegisterUser(RegisterDTO registerDTO);
        UserDTO LoginUser(LoginDTO loginDTO);
    }
}
