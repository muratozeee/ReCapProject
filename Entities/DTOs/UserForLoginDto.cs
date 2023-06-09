using Core.Entities.Abstract;

namespace Entities.DTOs
{
    //they are common all thing that's why we are using together.
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
