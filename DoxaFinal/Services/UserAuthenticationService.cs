using DoxaFinal.Models;

namespace DoxaFinal.Services
{
    public interface IUserAuthenticationService
    {
        bool Authenticate(User user, out int userId);
    }
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly UserRepository _repository;
        public UserAuthenticationService(UserRepository repository)
        {
            _repository = repository;
        }
        public bool Authenticate(User user, out int userId)
        {
            userId = 0;
            var users = _repository.GetUsers();
            var authenticateUser = users.FirstOrDefault(u => 
                u.Email == user.Email && u.Password == user.Password);
            if (authenticateUser != null)
            {
                userId=authenticateUser.Id;
                return true;
            }
            return false;
        }
    }
}
