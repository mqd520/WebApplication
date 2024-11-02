using SqlSugar;

namespace WebApplication16.Db.Entity
{
    [SugarTable("categories")]
    public class CategoryEntity
    {
        [SugarColumn(IsPrimaryKey = true)]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[] Picture { get; set; } = null!;

    }
}
