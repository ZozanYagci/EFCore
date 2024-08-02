namespace EfCore.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
