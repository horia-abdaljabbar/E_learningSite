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
    public class TeachersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TeachersController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var teachers = context.Teachers.ToList();
            var showTeachersVM = mapper.Map<IEnumerable<ShowTeachersVM>>(teachers);
            return View(showTeachersVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TeacherFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");

            var teacher = mapper.Map<Teacher>(viewModel);
            context.Add(teacher);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

         [HttpGet]
        public IActionResult Details(int id)
        {
            var teacher = context.Teachers.Find(id);
            if (teacher is null)
            {
                return NotFound();
            }

            var teacherM = mapper.Map<TeacherDetailsVM>(teacher);
            return View(teacherM);
        }

        public IActionResult Edit(int id)
        {
            var teacher = context.Teachers.Find(id);
            if (teacher is null)
            {
                return NotFound();
            }

            var teacherM = mapper.Map<TeacherFormVM>(teacher);
            return View(teacherM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(TeacherFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var teacher = context.Teachers.Find(viewModel.Id);
            if (teacher is null)
            {
                return NotFound();
            }
            viewModel.ImageName = FilesSettings.UploadFile(viewModel.Image, "images");
            var teacherM = mapper.Map(viewModel, teacher);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var teacher = context.Teachers.Find(id);
            if (teacher is null)
            {
                return NotFound();
            }
            FilesSettings.DeleteFile(teacher.ImageName, "images");

            var teacherM = mapper.Map<ShowTeachersVM>(teacher);
            return View(teacherM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = context.Teachers.Find(id);
            if (teacher is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Teachers.Remove(teacher);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
