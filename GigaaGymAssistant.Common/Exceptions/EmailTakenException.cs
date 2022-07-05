namespace GigaaGymAssistant.Domain.Common.Exceptions;

public class EmailTakenException : Exception
{
    public EmailTakenException() : base("That email is taken")
    {
    }
}