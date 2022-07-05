namespace GigaaGymAssistant.Domain.Common.Exceptions;

public class LoginException : Exception
{
    public LoginException() : base("Invalid email or password")
    {
    }
}