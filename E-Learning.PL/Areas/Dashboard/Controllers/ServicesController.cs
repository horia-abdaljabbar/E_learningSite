using AutoMapper;
using E_Learning.DAL.Data;
using E_Learning.DAL.Models;
using E_Learning.PL.Areas.Dashboard.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.PL.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]

    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ServicesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var services = context.Services.ToList();
            var showServicesVM = mapper.Map<IEnumerable<ShowServicesVM>>(services);
            return View(showServicesVM);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceFormVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var service = mapper.Map<Service>(viewModel);
            context.Add(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }

            var serviceM = mapper.Map<ServiceDetailsVM>(service);
            return View(serviceM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return NotFound();
            }

            var serviceM = mapper.Map<ShowServicesVM>(service);
            return View(serviceM);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var service = context.Services.Find(id);
            if (service is null)
            {
                return RedirectToAction(nameof(Index));
            }

            context.Services.Remove(service);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
