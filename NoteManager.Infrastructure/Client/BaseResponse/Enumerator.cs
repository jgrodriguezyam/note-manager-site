namespace NoteManager.Infrastructure.Client.BaseResponse
{
    public class Enumerator
    {
        public Enumerator()
        {
            Value = 0;
            Name = "";
        }

        public int Value { get; set; }
        public string Name { get; set; }
    }
}