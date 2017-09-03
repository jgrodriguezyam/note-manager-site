using System.Web.Mvc;
using FastMapper;
using NoteManager.DTO.Companies;
using NoteManager.DTO.Customers;
using NoteManager.Infrastructure.Attributes;
using NoteManager.Infrastructure.Enums;
using NoteManager.Models.Companies;
using NoteManager.Models.Customers;
using NoteManager.Models.Prints;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    [Authenticate]
    public class PrintController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICompanyService _companyService;

        public PrintController(ICustomerService customerService, ICompanyService companyService)
        {
            _customerService = customerService;
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult Print()
        {
            return View(EAction.Print.ToString());
        }

        [HttpGet]
        public PartialViewResult _Form(Print print)
        {
            return PartialView(print);
        }

        [HttpPost]
        public ActionResult PrintSheet(PrintSheet printSheet)
        {
            var customerResponse = _customerService.Get(printSheet.CustomerId);
            var customer = TypeAdapter.Adapt<CustomerResponse, Customer>(customerResponse);
            var companyResponse = _companyService.Get(printSheet.CompanyId);
            var company = TypeAdapter.Adapt<CompanyResponse, Company>(companyResponse);
            var folio = _companyService.GetFolio(printSheet.CompanyId).Folio;

            var print = new Print();
            print.Customer = customer;
            print.Company = company;
            print.Date = printSheet.Date;
            print.Price = printSheet.Price;
            print.Folio = folio;

            return View(EAction.PrintSheet.ToString(), print);
        }
    }
}