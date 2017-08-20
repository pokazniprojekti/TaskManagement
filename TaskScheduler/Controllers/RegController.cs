using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace TaskScheduler.Controllers
{
    public class RegController : ApiController
    {
        public string GetId()
        {

            var UserId= User.Identity.GetUserId();
            return UserId;
        }
    }
}
