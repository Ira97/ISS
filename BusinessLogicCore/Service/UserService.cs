using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using Models.User;
using ScientificDatabase.Repositories.UserRepository;
using System;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly UserRoleRepository _userRoleRepository;
        private readonly IMapperProvider _mapperProvider;
        private readonly IHashProvider _hashProvider;

        public UserService(UserRepository userRepository, IMapperProvider mapperProvider, IHashProvider hashProvider, UserRoleRepository userRoleRepository)
        {
            _userRepository = userRepository;
            _mapperProvider = mapperProvider;
            _hashProvider = hashProvider;
            _userRoleRepository = userRoleRepository;
        }

        public User ValidateUserAsync(ValidateUserDto validateUser)
        {
            var hashPassword = _hashProvider.HashMd5(validateUser.Password);
            var user = _userRepository.GetUserAsync(validateUser.Login, hashPassword);
            var mappedUser = _mapperProvider.CreateMapByProfile<ScientificDatabase.Models.User, User, BaseProfile>(user);
            return mappedUser;
        }
        public async Task RegisterUserAsync(RegisterUserDto registerUser)
        {
            try
            {
                if (await GetUserAsync(registerUser.Login) == null)
                {
                    var user = new ScientificDatabase.Models.User
                    {
                        Login = registerUser.Login,
                        Password = _hashProvider.HashMd5(registerUser.Password),
                        FullName = registerUser.FullName,
                        Contact = registerUser.Contact,
                        Roles = new System.Collections.Generic.List<ScientificDatabase.Models.UserRole>()
                    };
                    var userId = await _userRepository.InsertItemAsync(user);
                    if (userId != 0)
                    {
                        var userRole = new ScientificDatabase.Models.UserRole
                        {
                            UserId = Convert.ToInt32(userId),
                            RoleId = 3
                        };
                        await _userRoleRepository.InsertItemAsync(userRole);
                    }
                }
            }
            catch(Exception exception)
            {
                throw new Exception("Не удалось создать пользовател, попробуйте позднее");
            }

        }

        private async Task<ScientificDatabase.Models.User> GetUserAsync(string login)
        {
            return await _userRepository.GetItemAsync(x => x.Login == login);
        }
    }
}