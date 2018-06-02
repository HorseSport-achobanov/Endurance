namespace Endurance.Web.Trial.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;

    using global::Services.Common.Contracts;
    using Data.Trial.Models;
    using ViewModels;

    public class HomeController : Controller
    {
        private readonly IAutomapperService mapper;

        public HomeController(IAutomapperService mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var person = new Person()
            {
                FirstName = "Alex",
                LastName = "Chobanov",
                Age = 24
            };

            var personQuerable = new EnumerableQuery<Person>(new List<Person>() { person });
            var model = mapper.MapCollection<PersonViewModel>(personQuerable).FirstOrDefault();
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
