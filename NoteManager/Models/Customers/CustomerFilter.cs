using NoteManager.Models.Bases;

namespace NoteManager.Models.Customers
{
    public class CustomerFilter : SortingAndPagination
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int GenderType { get; set; }
        public string Colony { get; set; }
        public string Municipality { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
    }
}