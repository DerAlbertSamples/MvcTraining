using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MvcTraining.Entities;
using MvcTraining.Models;

namespace MvcTraining.Controllers
{
    public class EditCompanyController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            return View(await DbContext.Companies
                .Project()
                .To<IndexCompanyModel>().ToListAsync());
        }

        public ActionResult Create()
        {
            return View(new CreateCompanyModel());
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var company = Mapper.Map<Company>(model);
                DbContext.Companies.Add(company);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(long id)
        {
            var company = await GetCompanyAsync(id);
            return View(Mapper.Map<EditCompanyModel>(company));
        }

        private async Task<Company> GetCompanyAsync(long id)
        {
            var company = await DbContext.Companies.SingleAsync(c => c.Id == id);
            return company;
        }

        [HttpPost]
        public async Task<ActionResult> Edit(long id, EditCompanyModel model)
        {
            if (ModelState.IsValid)
            {
                var company = await GetCompanyAsync(id);
                Mapper.Map(model, company);
                await DbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<ActionResult> Details(long id)
        {
            var company = await GetCompanyAsync(id);
            return View(company);
        }
    }
}