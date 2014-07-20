using System;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MvcTraining.Data;

namespace MvcTraining.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly Lazy<ApplicationDbContext> _db;

        protected BaseController()
        {

            _db = new Lazy<ApplicationDbContext>(()=>HttpContext.GetOwinContext().Get<ApplicationDbContext>());
        }

        protected ApplicationDbContext DbContext
        {
            get { return _db.Value; }
        }
    }
}