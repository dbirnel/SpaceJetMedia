using Microsoft.AspNetCore.Mvc;
using SpaceJetMedia.Models;
using System.Diagnostics;

namespace SpaceJetMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetData([FromBody] string searchQuery)
        {
            IEnumerable<User> users = new List<User>();

            if(!string.IsNullOrEmpty(searchQuery))
            {
                users = _userRepository.SearchUsers(searchQuery);
            }
            return new JsonResult(users);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}