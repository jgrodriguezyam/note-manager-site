using NoteManager.Models.Companies;
using NoteManager.Models.Customers;

namespace NoteManager.Models.Prints
{
    public class Print
    {
        public Customer Customer { get; set; } 
        public Company Company { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
        public int Folio { get; set; }
    }
}