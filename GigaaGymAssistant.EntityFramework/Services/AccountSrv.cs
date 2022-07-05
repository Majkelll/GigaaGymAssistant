using GigaaGymAssistant.Domain.Common.Exceptions;
using GigaaGymAssistant.Domain.Common.Models.User;
using GigaaGymAssistant.Domain.Common.Utils;
using GigaaGymAssistant.Infrastructure.EntityFramework.Entities;
using GigaaGymAssistant.Interfaces.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace GigaaGymAssistant.Infrastructure.EntityFramework.Services;

public class AccountSrv : IAccountSrv
{
    private readonly GGADbContext _dbContext;
    private readonly IJwtUtils _jwtUtils;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AccountSrv(GGADbContext dbContext, IPasswordHasher<User> passwordHasher, IJwtUtils jwtUtils)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _jwtUtils = jwtUtils;
    }

    public UserDTO RegisterUser(RegisterDTO registerDTO)
    {
        var emailInUse = _dbContext.Users.Any(u => u.Email == registerDTO.Email);
        if (emailInUse) throw new EmailTakenException();

        // TO DO: MAPPER
        var newUser = new User
        {
            Email = registerDTO.Email,
            FirstName = registerDTO.FirstName,
            LastName = registerDTO.LastName
        };
        var hashedPassword = _passwordHasher.HashPassword(newUser, registerDTO.Password);
        newUser.PasswordHash = hashedPassword;

        _dbContext.Users.Add(newUser);
        _dbContext.SaveChanges();

        // TO DO
        var userAuth = new UserDTO
        {
            Id = newUser.Id,
            Email = newUser.Email,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName
        };

        var token = _jwtUtils.GenerateJWT(userAuth);
        userAuth.Token = token;

        return userAuth;
    }

    public UserDTO LoginUser(LoginDTO loginDTO)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginDTO.Email);
        if (user == null) throw new LoginException();

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDTO.Password);
        if (result == PasswordVerificationResult.Failed) throw new LoginException();

        // TO DO: MAPPER
        var userAuth = new UserDTO
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        var token = _jwtUtils.GenerateJWT(userAuth);
        userAuth.Token = token;

        return userAuth;
    }
}