using WebApplication4.Db.Repository;

namespace WebApplication4.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Fun1()
        {
            _userRepository.Fun1();
            return "UserService.Fun1();";
        }
    }
}
