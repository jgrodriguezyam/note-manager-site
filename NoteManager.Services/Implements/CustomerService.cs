using NoteManager.DTO.Customers;
using NoteManager.Infrastructure.Client;
using NoteManager.Infrastructure.Constants;
using NoteManager.Services.Interfaces;

namespace NoteManager.Services.Implements
{
    public class CustomerService : ICustomerService
    {
        public FindCustomersResponse Find(FindCustomersRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Customers);
            return Request.Filter<FindCustomersResponse>(uri, request);
        }

        public void Create(CustomerRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Customers);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(CustomerRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Customers);
            Request.Put(uri, request);
        }

        public CustomerResponse Get(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Customers, id);
            return Request.Get<CustomerResponse>(uri);
        }

        public void Delete(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Customers, id);
            Request.Delete(uri);
        }
    }
}