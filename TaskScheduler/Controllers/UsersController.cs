using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using TaskScheduler.Models;

namespace TaskScheduler.Controllers
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<System.Web.Mvc.SelectListItem> Get()
        {
            /*
            List<System.Web.Mvc.SelectListItem> employees = new List<System.Web.Mvc.SelectListItem>
            {
                new System.Web.Mvc.SelectListItem { Text = "Robert Ivancic", Value="5f44ee39-34d7-4169-8f8b-ff13689a9e9a" },
                new System.Web.Mvc.SelectListItem { Text = "Mladen Miler", Value="e7931bdb-a82a-44e2-a537-71483c7ef60e" },
               
            };

            return employees;
            */
            List<System.Web.Mvc.SelectListItem> employees = new List<System.Web.Mvc.SelectListItem>();
            var lm = db.Users;
            foreach (var temp in lm)
            {
                employees.Add(new SelectListItem() { Text = temp.Name + ' ' +temp.Surname, Value = temp.Id });
            }
            return employees;

        }
        

    }
}
