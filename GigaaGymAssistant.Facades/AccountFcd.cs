using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Interfaces.Facades;
using GigaaGymAssistant.Interfaces.Infrastructure;

namespace GigaaGymAssistant.Domain.Facades;

public class AccountFcd : IAccountFcd
{
    private readonly IAccountSrv _accountSrv;

    public AccountFcd(IAccountSrv accountSrv)
    {
        _accountSrv = accountSrv;
    }

    public UserDTO LoginUser(LoginDTO loginDTO)
    {
        return _accountSrv.LoginUser(loginDTO);
    }

    public UserDTO RegisterUser(RegisterDTO registerDTO)
    {
        return _accountSrv.RegisterUser(registerDTO);
    }
}