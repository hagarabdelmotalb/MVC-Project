namespace Demo.BLL.DTOS
{
    public class DepartmentDetailsDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } //User Id
        public DateOnly? CreatedAt { get; set; }
        public int ModifiedBy { get; set; } //User Id
        public DateOnly? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; } //Soft Delete
        public string Name { get; set; } = string.Empty!;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }

    }
}
