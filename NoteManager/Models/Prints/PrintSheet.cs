namespace NoteManager.Models.Prints
{
    public class PrintSheet
    {
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public string Date { get; set; }
        public decimal Price { get; set; }
    }
}