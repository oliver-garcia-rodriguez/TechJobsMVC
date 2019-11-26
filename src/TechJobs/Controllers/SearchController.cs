using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        public IActionResult Results(string searchType, string searchTerm)
        {
            ViewBag.columns = ListController.columnChoices;

            List<Dictionary<string, string>> jobs;

            if (searchType.Equals("all"))
            {
                if (searchTerm != null)
                {
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                }
                else
                {
                    ViewBag.jobs = JobData.FindAll();
                }
            }
            else
            {
                if (searchTerm != null)
                {
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
                else
                {
                    ViewBag.jobs = JobData.FindAll();
                }
            }
            return View("index");
        }

    }
}
