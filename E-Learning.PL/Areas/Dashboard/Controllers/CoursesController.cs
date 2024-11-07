using AutoMapper;
using E_Learning.DAL.Data;
using E_Learning.DAL.Models;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using E_Learning.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,superAdmin")]
    [Area("Dashboard")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CoursesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            var showCoursesVM = mapper.Map<IEnumerable<ShowCoursesVM>>(courses);
            return View(showCoursesVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");
            var course = mapper.Map<Course>(viewModel);
            context.Add(course);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var course = context.Courses.Find(id);
            if (course is null)
            {
                return NotFound();
            }

            var courseM = mapper.Map<CourseDetails>(course);
            return View(courseM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var course = context.Courses.Find(id);
            if (course is null)
            {
                return NotFound();
            }
            FilesSettings.DeleteFile(course.ImageName,"images");
            var courseM = mapper.Map<ShowCoursesVM>(course);
            return View(courseM);
        }

        public IActionResult Edit(int id)
        {
            var course = context.Courses.Find(id);
            if (course is null)
            {
                return NotFound();
            }

            var courseM = mapper.Map<CourseFormVM>(course);
            return View(courseM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(CourseFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var course = context.Courses.Find(viewModel.Id);
            if (course is null)
            {
                return NotFound();
            }
            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");
            mapper.Map(viewModel, course);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = context.Courses.Find(id);
            if (course is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Courses.Remove(course);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
