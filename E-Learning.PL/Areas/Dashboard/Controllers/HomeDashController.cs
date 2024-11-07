using AutoMapper;
using E_Learning.DAL.Data;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Learning.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,superAdmin")]
    [Area("Dashboard")]
    public class HomeDashController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public HomeDashController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var categories = context.Categories.ToList(); // Assuming you have a Users table
            var courses = context.Courses.ToList(); // Assuming you have a Courses table
            var teachers = context.Teachers.ToList(); // Assuming you have a Users table
            var services = context.Services.ToList(); // Assuming you have a Courses table

            int numberOfCat = context.Categories.Count();
            int numberOfCourses = context.Courses.Count();
            int numberOfTeachers = context.Teachers.Count();
            int numberOfService = context.Services.Count();

            // You can pass the counts to the view if needed or use them here
            ViewBag.CatCount = numberOfCat;
            ViewBag.CourseCount = numberOfCourses;
            ViewBag.TeacherCount = numberOfTeachers;
            ViewBag.ServiceCount = numberOfService;

            // Create the view model
            var viewModel = new IndexVM
            {
                Categories = categories,
                Courses = courses,
                Teachers=teachers,
                Services=services

            };

            // Pass the view model to the view
            return View(viewModel);
        }
    }
}
