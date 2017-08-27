using FastMapper;
using NoteManager.DTO.Companies;
using NoteManager.DTO.Customers;
using NoteManager.DTO.Users;
using NoteManager.Models.Companies;
using NoteManager.Models.Customers;
using NoteManager.Models.Users;

namespace NoteManager.Mapper
{
    public static class FastMapperConfig
    {
        public static void Initialize()
        {
            #region User

            TypeAdapterConfig<UserResponse, User>
                .NewConfig();

            #endregion

            #region Customer

            TypeAdapterConfig<CustomerResponse, Customer>
                .NewConfig();

            TypeAdapterConfig<CustomerResponse, CustomerGridView>
                .NewConfig()
                .MapFrom(dest => dest.FullName, src => string.Format("{0} {1}", src.Name, src.LastName));

            #endregion

            #region Company

            TypeAdapterConfig<CompanyResponse, Company>
                .NewConfig();

            #endregion
        }
    }
}