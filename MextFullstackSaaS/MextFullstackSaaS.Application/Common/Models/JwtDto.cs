namespace MextFullstackSaaS.Application.Common.Models
{
    public class JwtDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public JwtDto(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }

        public JwtDto()
        {
            
        }
    }
}
