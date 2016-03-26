using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestNuevoTypeahead.Models;

namespace TestNuevoTypeahead.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CountryLookup()
        {
            var countries = new List<SearchTypeAheadEntity>
            {
                new SearchTypeAheadEntity {ShortCode = "US", Name = "United States"},
                new SearchTypeAheadEntity {ShortCode = "CA", Name = "Canada"},
                new SearchTypeAheadEntity {ShortCode = "AF", Name = "Afghanistan"},
                new SearchTypeAheadEntity {ShortCode = "AL", Name = "Albania"},
                new SearchTypeAheadEntity {ShortCode = "DZ", Name = "Algeria"},
                new SearchTypeAheadEntity {ShortCode = "DS", Name = "American Samoa"},
                new SearchTypeAheadEntity {ShortCode = "AD", Name = "Andorra"},
                new SearchTypeAheadEntity {ShortCode = "AO", Name = "Angola"},
                new SearchTypeAheadEntity {ShortCode = "AI", Name = "Anguilla"},
                new SearchTypeAheadEntity {ShortCode = "AQ", Name = "Antarctica"},
                new SearchTypeAheadEntity {ShortCode = "AG", Name = "Antigua and/or Barbuda"}
            };
           
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSearch(string query, string type)
        {
            var search = new Search();
            var assets = new List<Asset>{
                new Asset{ Code="1", Name="Telefonica"},
                new Asset{ Code="2", Name="Telemundo"},
                new Asset{ Code="3", Name="Adidas"},
                new Asset{ Code="4", Name="Telesiem"}
            };


            var users = new List<User>
            {
                new User{ Id="1", Name="raul"},
                new User{ Id="2", Name="ramiro"},
                new User{ Id="3", Name="rafael"},
                new User{ Id="4", Name="carlos"},
            };

            search.Assets = (from a in assets where query.Any(val => a.Name.Contains(val)) select a).ToList(); 
            search.Users = users;      

            return Json(search, JsonRequestBehavior.AllowGet);

        }
    }
}
