using System.Collections.Generic;
using System.Web.Http;

namespace TaskScheduler.Controllers
{
    public class VisibleController : ApiController
    {
        public IEnumerable<System.Web.Mvc.SelectListItem> Get()
        {
            List<System.Web.Mvc.SelectListItem> visible = new List<System.Web.Mvc.SelectListItem>
            {
                new System.Web.Mvc.SelectListItem { Text = "All", Value="All" },
                new System.Web.Mvc.SelectListItem { Text = "Just me", Value="Just Me" },

            };

            return visible;
        }
    }
}
