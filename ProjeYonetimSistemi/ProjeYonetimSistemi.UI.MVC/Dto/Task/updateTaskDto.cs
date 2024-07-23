namespace ProjeYonetimSistemi.UI.MVC.Dto.Task
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public string TaskName { get; set; }
        public List<string> TeamMembers { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Progress { get; set; }
        public string Status { get; set; }
    }
}
