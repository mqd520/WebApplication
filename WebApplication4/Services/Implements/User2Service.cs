using WebApplication4.Db.Repository;

namespace WebApplication4.Services.Implements
{
    public class User2Service : IUser2Service
    {
        private readonly IUser2Repository _repository;

        public User2Service(IUser2Repository repository)
        {
            _repository = repository;
        }

        public string Fun1()
        {
            _repository.Fun1();
            return "User2Service.Fun1();";
        }
    }
}
