using NoteManager.DTO.Companies;
using NoteManager.Infrastructure.Client;
using NoteManager.Infrastructure.Constants;
using NoteManager.Services.Interfaces;

namespace NoteManager.Services.Implements
{
    public class CompanyService : ICompanyService
    {
        public FindCompaniesResponse Find(FindCompaniesRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Companies);
            return Request.Filter<FindCompaniesResponse>(uri, request);
        }

        public void Create(CompanyRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Companies);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(CompanyRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Companies);
            Request.Put(uri, request);
        }

        public CompanyResponse Get(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Companies, id);
            return Request.Get<CompanyResponse>(uri);
        }

        public void Delete(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Companies, id);
            Request.Delete(uri);
        }
    }
}