using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication16.Db.Entity
{
    [Table("categories")]
    public class CategoryEntity
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public byte[] Picture { get; set; } = null!;

    }
}
