using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using TaskScheduler.Models;

namespace TaskScheduler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddTask()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Calendar()
        {
            return View();
        }



        public ActionResult GetEventsData()
        {

            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                var userId = User.Identity.GetUserId();
                var userSuppliedId = new SqlParameter("@PostId", userId);

                string sqlQuery = @"select t1.Id, t1.Description, t1.IsActive, (t2.Name +' '+ t2.Surname) as Assign, t1.Visibility, t1.TaskName, DATEADD(HOUR,2,t1.StartDate) as StartDate, DATEADD(HOUR,2,t1.EndDate) as EndDate, t1.Users_Id as Users_Id from dbo.WorkingTasks as t1 left join dbo.AspNetUsers as t2 on (t1.Assign=t2.Id) left join dbo.AspNetUsers as t3 on (t1.Assign=t3.Id) where t1.Assign=@PostId order by t1.StartDate";
                var Results = db.Database.SqlQuery<WorkingTask>(sqlQuery, userSuppliedId).ToList();
                var events = Results.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }


    }
}