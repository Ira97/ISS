using System.Threading.Tasks;
using BusinessLogicCore.Interfaces;
using BusinessLogicCore.MapperProfiles;
using Models;
using ScientificDatabase.Repositories.UserRepository;

namespace BusinessLogicCore.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IMapperProvider _mapperProvider;

        public UserService(UserRepository userRepository, IMapperProvider mapperProvider)
        {
            _userRepository = userRepository;
            _mapperProvider = mapperProvider;
        }

        public User GetUserAsync(string login)
        {
            var user = _userRepository.GetUserAsync(login);
            var mappedUser = _mapperProvider.CreateMapByProfile<ScientificDatabase.Models.User, User, BaseProfile>(user);
            return mappedUser;
        }
    }
}