using System.Collections.Generic;
using System.Web.Http;

namespace TaskScheduler.Controllers
{
    public class ActiveController : ApiController
    {

        public IEnumerable<System.Web.Mvc.SelectListItem> Get()
        {
            List<System.Web.Mvc.SelectListItem> active = new List<System.Web.Mvc.SelectListItem>
            {
                new System.Web.Mvc.SelectListItem { Text = "Active", Value="Active" },
                new System.Web.Mvc.SelectListItem { Text = "Finished", Value="Finished" },

            };

            return active;
        }

    }
}
