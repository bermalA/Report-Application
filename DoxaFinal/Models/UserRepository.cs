namespace DoxaFinal.Models
{
    public class UserRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void AddUser(User user) 
        {
            _databaseContext.Users.Add(user);
            _databaseContext.SaveChanges();
        }
        public List<User> GetUsers()
        {
            return _databaseContext.Users.ToList();
        }
    }
}
