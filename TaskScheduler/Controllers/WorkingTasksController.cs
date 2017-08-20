using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskScheduler.Models;


namespace TaskScheduler.Controllers
{
    [Authorize]
    public class WorkingTasksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/WorkingTasks
        public IEnumerable<WorkingTask> GetWorkingTasks()
        {
            var userId = User.Identity.GetUserId();
            var userSuppliedId = new SqlParameter("@PostId", userId);

            string sqlQuery = @"select t1.Id, t1.Description, t1.IsActive, (t2.Name +' '+ t2.Surname) as Assign, t1.Visibility, t1.TaskName, DATEADD(HOUR,2,t1.StartDate) as StartDate, DATEADD(HOUR,2,t1.EndDate) as EndDate, t1.Users_Id as Users_Id from dbo.WorkingTasks as t1 left join dbo.AspNetUsers as t2 on (t1.Assign=t2.Id) left join dbo.AspNetUsers as t3 on (t1.Assign=t3.Id) where t1.Visibility='All' or t1.Assign=@PostId or t1.Users_Id=@PostId";
            var Results = db.Database.SqlQuery<WorkingTask>(sqlQuery, userSuppliedId).ToList();

            return Results;
            
        }

        // GET: api/WorkingTasks/5
        public WorkingTask Get(int id)
        {
            return db.WorkingTasks.Find(id);
        }

        // PUT: api/WorkingTasks/5

        public HttpResponseMessage Put(WorkingTask model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, model);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }



        // POST: api/WorkingTasks
        [ResponseType(typeof(WorkingTask))]
        public IHttpActionResult PostWorkingTask(WorkingTask workingTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.WorkingTasks.Add(workingTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workingTask.Id }, workingTask);
        }

        // DELETE: api/WorkingTasks/5
        [ResponseType(typeof(WorkingTask))]
        public IHttpActionResult Delete(int id)
        {
            WorkingTask workingTask = db.WorkingTasks.Find(id);
            if (workingTask == null)
            {
                return NotFound();
            }

            db.WorkingTasks.Remove(workingTask);
            db.SaveChanges();

            return Ok(workingTask);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkingTaskExists(int id)
        {
            return db.WorkingTasks.Count(e => e.Id == id) > 0;
        }
    }
}