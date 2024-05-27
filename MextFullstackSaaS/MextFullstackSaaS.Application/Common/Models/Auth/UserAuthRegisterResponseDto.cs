namespace MextFullstackSaaS.Application.Common.Models.Auth;

public class UserAuthRegisterResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }

    public UserAuthRegisterResponseDto(Guid id, string email)
    {
        Id = id;
        
        Email = email;
    }
}