using HelloApp;
using Microsoft.AspNetCore.Mvc;
using ShortLink.Models;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Windows;

namespace ShortLink.Controllers
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
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Link> links = new List<Link>();
                links = db.Links.ToList();
                return View("Index", links);
                
            }

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
        public IActionResult CreateLinkShort()
        {



            return View();
        }

        [HttpPost]
        public IActionResult AddLink(string FullName)
        {


            using (ApplicationContext db = new ApplicationContext())
            {
                Link link = new Link() { FullName = FullName, CreateDate = DateTime.Today.ToString("d"), ShortLink = Link.GetShortLink(), Transition = 0 };
                db.Links.Add(link);
                db.SaveChanges();
                return Redirect($"/");
            }
           
        }

        [HttpGet("/{link}")]
        public IActionResult ConnectShortLink(string link)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Link> links = new List<Link>();
                links = db.Links.ToList() ;
                foreach (var element in links)
                {
                    if (element.ShortLink == $"https://localhost:7125/{link}")
                    {
                        db.Links.Where(x => x.ShortLink == $"https://localhost:7125/{link}").First().Transition++;
                        db.SaveChanges();
                        return Redirect($"https://{element.FullName}");
                       
                    }
                }

               return View();
            }
        }
    }
}