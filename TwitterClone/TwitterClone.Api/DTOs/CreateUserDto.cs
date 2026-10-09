using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Api.DTOs
{
    public class CreateUserDto
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public required string Email { get; set; }
    }
}
