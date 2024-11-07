namespace E_Learning.PL.ViewModels
{
    public class TeacherVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public string? ImageName { get; set; }
        public string Field { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //public bool StillWorked { get; set; }
    }
}
