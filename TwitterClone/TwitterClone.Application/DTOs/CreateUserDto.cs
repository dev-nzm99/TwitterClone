using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    public class CreateUserDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
    }
}
