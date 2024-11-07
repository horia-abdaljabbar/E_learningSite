using AutoMapper;
using E_Learning.DAL.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.PL.Controllers
{
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
            return View();
        }
    }
}
