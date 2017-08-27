using System.Collections.Generic;
using System.Web.Mvc;
using FastMapper;
using NoteManager.DTO.Customers;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.JsonResults;
using NoteManager.Models.Customers;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var customer = new Customer();
            return View(EAction.New.ToString(), customer);
        }

        [HttpPost]
        public JsonResult Create(Customer customer)
        {
            var customerRequest = TypeAdapter.Adapt<Customer, CustomerRequest>(customer);
            _customerService.Create(customerRequest);
            return new JsonFactory().Success(GlobalConstants.SavedSuccessfully);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customerResponse = _customerService.Get(id);
            var customer = TypeAdapter.Adapt<CustomerResponse, Customer>(customerResponse);
            return View(EAction.Edit.ToString(), customer);
        }

        [HttpPost]
        public JsonResult Update(Customer customer)
        {
            var customerRequest = TypeAdapter.Adapt<Customer, CustomerRequest>(customer);
            _customerService.Update(customerRequest);
            return new JsonFactory().Success(GlobalConstants.SavedSuccessfully);
        }

        [HttpGet]
        public PartialViewResult _Form()
        {
            return PartialView();
        }

        [HttpGet]
        public JsonResult Filter(CustomerFilter filter)
        {
            var findCustomersRequest = TypeAdapter.Adapt<CustomerFilter, FindCustomersRequest>(filter);
            var findCustomersResponse = _customerService.Find(findCustomersRequest);
            return new JsonFactory().Success(findCustomersResponse.Customers, findCustomersResponse.TotalRecords);
        }

        [HttpGet]
        public JsonResult GridFilter(CustomerFilter filter)
        {
            var findCustomersRequest = TypeAdapter.Adapt<CustomerFilter, FindCustomersRequest>(filter);
            var findCustomersResponse = _customerService.Find(findCustomersRequest);
            var customerGridViews = TypeAdapter.Adapt<List<CustomerGridView>>(findCustomersResponse.Customers);
            return new JsonFactory().Success(customerGridViews, findCustomersResponse.TotalRecords);
        }
    }
}