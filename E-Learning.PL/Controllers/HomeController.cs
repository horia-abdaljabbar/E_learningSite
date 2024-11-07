using AutoMapper;
using E_Learning.DAL.Data;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using E_Learning.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Learning.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        private readonly ILogger<HomeController> _logger;

      

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult GetServices()
        {
            var services = context.Services.ToList();
            var serviceVM = mapper.Map<IEnumerable<ServiceVM>>(services);
            return View(serviceVM);
        }
        public IActionResult GetCategories()
        {

            var categories = context.Categories.ToList();
            var categoriesVM = mapper.Map<IEnumerable<CategoryVM>>(categories);
            return View(categoriesVM);
        }

        public IActionResult GetCourses()
        {

            var courses = context.Courses.ToList();
            var courseVM = mapper.Map<IEnumerable<CourseVM>>(courses);
            return View(courseVM);
        }

        public IActionResult GetTeachers()
        {

            var teachers = context.Teachers.ToList();
            var teacheVM = mapper.Map<IEnumerable<TeacherVM>>(teachers);
            return View(teacheVM);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
