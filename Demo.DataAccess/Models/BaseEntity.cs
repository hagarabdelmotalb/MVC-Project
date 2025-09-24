
namespace Demo.DataAccess.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //User Id
        public DateTime? CreatedAt { get; set; }
        public int ModifiedBy { get; set; } //User Id
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } //Soft Delete

    }
}
