using Models.User;
using System.Threading.Tasks;

namespace BusinessLogicCore.Service
{
    public interface IUserService
    {
        UserDto ValidateUserAsync(ValidateUserDto validateUser);
        Task RegisterUserAsync(RegisterUserDto registerUser);
    }
}