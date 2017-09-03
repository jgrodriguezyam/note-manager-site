using NoteManager.DTO.Companies;

namespace NoteManager.Services.Interfaces
{
    public interface ICompanyService
    {
        FindCompaniesResponse Find(FindCompaniesRequest request);
        void Create(CompanyRequest request);
        void Update(CompanyRequest request);
        CompanyResponse Get(int id);
        void Delete(int id);
        GetFolioResponse GetFolio(int companyId);
    }
}