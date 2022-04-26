using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebService1.Models;
using WebService1.Repositories;

namespace WebService1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ITenderRepository _xlsReaderRepository;
        public HomeController(ITenderRepository xlsReaderRepository)
        {
            _xlsReaderRepository = xlsReaderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _xlsReaderRepository.GetTendersFromXLS();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
