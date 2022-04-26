using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Authentication;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [BasicAuthentication]
    public class HomeController : Controller
    {
        private readonly ITenderRepository _tenderRepository;

        public HomeController(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _tenderRepository.GetTendersFromWebService();
                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}