using Models.User;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(ValidateUserDto validateUser);
        Task RegisterUserAsync(RegisterUserDto registerUser);
    }
}