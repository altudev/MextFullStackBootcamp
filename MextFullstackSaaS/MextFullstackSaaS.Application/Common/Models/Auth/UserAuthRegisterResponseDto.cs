namespace MextFullstackSaaS.Application.Common.Models.Auth;

public class UserAuthRegisterResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string EmailToken { get; set; }

    public UserAuthRegisterResponseDto(Guid id, string email,string firstName, string emailToken)
    {
        Id = id;
        
        Email = email;
        
        FirstName = firstName;
        
        EmailToken = emailToken;
    }
}