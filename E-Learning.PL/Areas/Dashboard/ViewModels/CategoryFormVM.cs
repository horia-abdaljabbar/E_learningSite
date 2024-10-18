namespace E_Learning.PL.Areas.Dashboard.ViewModels
{
    public class CategoryFormVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public bool IsFinished { get; set; }

        public int NumOfCourses { get; set; }
    }
}
