namespace API.Entities
{
    public class AppReport
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Description { get; set; }
        public int Place { get; set; }
        public DateTime Date { get; set; }
        public int Score { get; set; }
    }
}