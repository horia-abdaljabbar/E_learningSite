namespace E_Learning.PL.Areas.Dashboard.ViewModels
{
    public class CategoryDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public string NumOfCourses { get; set; }
        public bool IsFinished { get; set; }
    }
}
