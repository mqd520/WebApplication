using System.Diagnostics;
using System.Net.Sockets;

using Microsoft.AspNetCore.Mvc;

using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            {
                using TcpClient tcpClient = new TcpClient();
                try
                {
                    tcpClient.Connect("localhost", 4001);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                if (tcpClient.Connected)
                {
                    _logger.LogInformation("Connect Success!");
                }
            }

            {
                using var hc = new HttpClient();
                hc.BaseAddress = new Uri("http://localhost:4001");
                try
                {
                    var content = hc.GetStringAsync("/Action/Index").Result;
                    _logger.LogInformation("http://localhost:4001 is ok!");
                    _logger.LogInformation(content);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
