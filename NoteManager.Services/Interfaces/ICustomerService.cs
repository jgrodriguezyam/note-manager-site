using NoteManager.DTO.Customers;

namespace NoteManager.Services.Interfaces
{
    public interface ICustomerService
    {
        FindCustomersResponse Find(FindCustomersRequest request);
        void Create(CustomerRequest request);
        void Update(CustomerRequest request);
        CustomerResponse Get(int id);
        void Delete(int id);
    }
}