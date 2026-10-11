using TwitterClone.Application.DTOs;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
           _userRepository = userRepository;
        }

        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.Firstname) ||
               string.IsNullOrWhiteSpace(createUserDto.Lastname) ||
               string.IsNullOrWhiteSpace(createUserDto.Email) ||
               string.IsNullOrWhiteSpace(createUserDto.PhoneNumber)
              )
            {
                return null;
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);

            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(new User
            {
                FirstName = createUserDto.Firstname,
                LastName = createUserDto.Lastname,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber
            });

            return new UserDto
            {
                Id = createdUser.Id,
                Firstname = createdUser.FirstName,
                Lastname = createdUser.LastName,
                Email = createdUser.Email,
                PhoneNumber = createdUser.PhoneNumber,
            };
        }

        public bool DeleteUser(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return false;
            }

            var isDeleted = _userRepository.DeleteUser(user);

            return isDeleted;
        }

        public UserDto GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            return new UserDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                PhoneNumber= user.PhoneNumber,
            };
        }

        public List<UserDto> GetUsers()
        {
            return _userRepository.GetUsers()
                .OrderBy(u => u.CreatedAt)
                .Select(u => new UserDto
                {
                    Id = u.Id,
                    Firstname= u.FirstName,
                    Lastname= u.LastName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber
                })
                .ToList();
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return null;
            }

            user.FirstName = updateUserDto.Firstname;
            user.LastName = updateUserDto.Lastname;
            user.Email = updateUserDto.Email ?? user.Email;
            user.PhoneNumber = updateUserDto.PhoneNumber ?? user.PhoneNumber;
            
            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
        }

        public UserDto? UpdateUserPhoneNumber(Guid id, String  phoneNumber)
        {
            var user = _userRepository.GetUserById(id);

            if(user  == null)
            {
                return null;
            }

            user.PhoneNumber = phoneNumber;
            _userRepository.UpdateUser(user);

            return new UserDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

        }
    }
}
