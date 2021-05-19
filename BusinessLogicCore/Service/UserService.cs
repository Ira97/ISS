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
        private readonly IMapperProvider _mapperProvider;
        private readonly IHashProvider _hashProvider;

        public UserService(UserRepository userRepository, IMapperProvider mapperProvider, IHashProvider hashProvider)
        {
            _userRepository = userRepository;
            _mapperProvider = mapperProvider;
            _hashProvider = hashProvider;
        }

        public UserDto ValidateUserAsync(ValidateUserDto validateUser)
        {
            var hashPassword = _hashProvider.HashMd5(validateUser.Password);
            var user = _userRepository.GetUserAsync(validateUser.Login, hashPassword);
            if (user != null)
            {
                var mappedUser = _mapperProvider.CreateMapByProfile<ScientificDatabase.Models.User, UserDto, BaseProfile>(user);
                return mappedUser;
            }
            return new UserDto();
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
                        Password =  _hashProvider.HashMd5(registerUser.Password),
                        FullName = registerUser.FullName,
                        Contact = registerUser.Contact,
                        RoleId = 3
                    };
                    var userId = await _userRepository.InsertItemAsync(user);                
                }
            }
            catch (Exception exception)
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