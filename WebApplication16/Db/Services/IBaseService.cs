namespace WebApplication16.Db.Services
{
    public interface IBaseService<T> where T : class, new()
    {
        IList<T> GetList();
    }
}
