using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MvcTraining.Data;
using MvcTraining.Entities;

namespace MvcTraining.Controllers
{
    public class EditPersonController : Controller
    {
        private readonly Lazy<ApplicationDbContext> _db;

        protected ApplicationDbContext DbContext
        {
            get { return _db.Value; }
        }
        public EditPersonController()
        {

            _db = new Lazy<ApplicationDbContext>(()=>HttpContext.GetOwinContext().Get<ApplicationDbContext>());
        }
        public async Task<ActionResult> Index()
        {
            return View(await DbContext.People.ToListAsync());
        }

        public async Task<ActionResult> Edit(long id)
        {
            var person = await GetPerson(id);
            return View(person);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, Person model)
        {
            var person = await GetPerson(id);
            person.GivenName = model.GivenName;
            person.LastName = model.LastName;
            person.Gender = model.Gender;           
            await DbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private async Task<Person> GetPerson(long id)
        {
            return await DbContext.People.SingleAsync(p => p.Id == id);
        }
    }
}