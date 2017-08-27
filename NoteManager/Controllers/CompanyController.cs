using System.Collections.Generic;
using System.Web.Mvc;
using FastMapper;
using NoteManager.DTO.Companies;
using NoteManager.Infrastructure.Attributes;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.JsonResults;
using NoteManager.Models.Companies;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    [Authenticate]
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var company = new Company();
            return View(EAction.New.ToString(), company);
        }

        [HttpPost]
        public JsonResult Create(Company company)
        {
            var companyRequest = TypeAdapter.Adapt<Company, CompanyRequest>(company);
            _companyService.Create(companyRequest);
            return new JsonFactory().Success(MessageConstants.SavedSuccessfully);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var companyResponse = _companyService.Get(id);
            var company = TypeAdapter.Adapt<CompanyResponse, Company>(companyResponse);
            return View(EAction.Edit.ToString(), company);
        }

        [HttpPost]
        public JsonResult Update(Company company)
        {
            var companyRequest = TypeAdapter.Adapt<Company, CompanyRequest>(company);
            _companyService.Update(companyRequest);
            return new JsonFactory().Success(MessageConstants.SavedSuccessfully);
        }

        [HttpGet]
        public PartialViewResult _Form()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult Filter(CompanyFilter filter)
        {
            var findCompaniesRequest = TypeAdapter.Adapt<CompanyFilter, FindCompaniesRequest>(filter);
            var findCompaniesResponse = _companyService.Find(findCompaniesRequest);
            return new JsonFactory().Success(findCompaniesResponse.Companies, findCompaniesResponse.TotalRecords);
        }

        [HttpGet]
        public JsonResult GridFilter(CompanyFilter filter)
        {
            var findCompaniesRequest = TypeAdapter.Adapt<CompanyFilter, FindCompaniesRequest>(filter);
            var findCompaniesResponse = _companyService.Find(findCompaniesRequest);
            var companyGridViews = TypeAdapter.Adapt<List<CompanyGridView>>(findCompaniesResponse.Companies);
            return new JsonFactory().Success(companyGridViews, findCompaniesResponse.TotalRecords);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            _companyService.Delete(id);
            return new JsonFactory().Success(MessageConstants.DeletedSuccessfully);
        }
    }
}