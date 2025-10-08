namespace Demo.BLL.DTOS.DepartmentDTOS
{
    public class DepartmentDto
    {
        public int DepId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateOnly DateOfCreation { get; set; }
    }
}
