using WebApplication4.Interceptors;

namespace WebApplication4.Db.Repository.Implements
{
    public class UserRepository : IUserRepository
    {
        [UseDbTran]
        public void Fun1()
        {
            Console.WriteLine("UserRepository.Fun1();");
        }
    }
}
