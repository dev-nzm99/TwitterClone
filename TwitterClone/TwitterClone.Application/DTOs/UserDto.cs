using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.DTOs
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
