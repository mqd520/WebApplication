using WebApplication24.Db.Entity;

namespace WebApplication24.Db
{
    public static class UserHelper
    {
        public static readonly IList<UserInfoEntity> Users = new List<UserInfoEntity>();

        static UserHelper()
        {
            Users.Add(new UserInfoEntity
            {
                Id = 1001,
                UserName = "Username1001",
                Email = "1001",
                Password = "123456",
                Name = "Name1001"
            });
            Users.Add(new UserInfoEntity
            {
                Id = 1002,
                UserName = "Username1002",
                Email = "1002",
                Password = "123456",
                Name = "Name1002"
            });
            Users.Add(new UserInfoEntity
            {
                Id = 1003,
                UserName = "Username1003",
                Email = "1003",
                Password = "123456",
                Name = "Name1003"
            });
        }
    }
}
