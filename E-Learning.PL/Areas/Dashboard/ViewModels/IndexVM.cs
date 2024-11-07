using E_Learning.DAL.Models;

namespace E_Learning.PL.Areas.Dashboard.ViewModels
{
    public class IndexVM
    {
        public List<Category> Categories { get; set; }
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Service> Services { get; set; }


    }
}
