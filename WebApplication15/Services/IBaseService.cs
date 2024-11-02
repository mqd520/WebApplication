namespace WebApplication15.Services
{
    public interface IBaseService<T> where T : class, new()
    {
        IList<T> GetList();

        IList<T> GetPageList(int page, int pageSize, out int total);
    }
}
