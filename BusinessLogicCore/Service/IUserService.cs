using Models;

namespace BusinessLogicCore.Service
{
    public interface IUserService
    {
        User GetUserAsync(string login);
    }
}