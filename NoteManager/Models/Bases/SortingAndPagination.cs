namespace NoteManager.Models.Bases
{
    public class SortingAndPagination
    {
        public SortingAndPagination()
        {
            ItemsToShow = 0;
            Page = 0;
            Sort = string.Empty;
            SortBy = string.Empty;
        }

        public int ItemsToShow { get; set; }
        public int Page { get; set; }
        public string Sort { get; set; }
        public string SortBy { get; set; }
    }
}