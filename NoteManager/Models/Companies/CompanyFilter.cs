using NoteManager.Models.Bases;

namespace NoteManager.Models.Companies
{
    public class CompanyFilter : SortingAndPagination
    {
        public string Name { get; set; }
        public string Colony { get; set; }
        public string City { get; set; }
    }
}