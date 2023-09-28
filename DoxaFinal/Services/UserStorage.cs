using DoxaFinal.Models;

namespace DoxaFinal.Services
{
    public interface IUserStorage
    {
        string SaveUser(User user);
    }
    public class UserStorage : IUserStorage
    {
        private readonly UserRepository _userRepository;
        
        public UserStorage (UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       public string SaveUser(User user)
        {
            bool emailExists =  _userRepository.GetUsers().Any(x=>x.Email == user.Email);

            if (emailExists)
            {
                return "Email adresi kullanımda.";
            }
            _userRepository.AddUser(user);

            return null;
        }
    }
}
