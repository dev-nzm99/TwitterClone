using TwitterClone.Application.DTOs;

namespace TwitterClone.Application.Interfaces
{
    public interface IUserService
    {
        UserDto? CreateUser(CreateUserDto createUserDto);
        List<UserDto> GetUsers();
        UserDto GetUserById(Guid id);
        UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto);
        bool DeleteUser(Guid id);
    }
}
