namespace WebApplication14.Services.Implements
{
    [Autofac.Annotation.Component]
    public class UserService : IUserService
    {
        public virtual void Fun1()
        {
            Console.WriteLine("UserService.Fun1();");
        }
    }
}
