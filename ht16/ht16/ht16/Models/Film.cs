namespace ht16.Models
{
    public class Film
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Film(int id, string title, string director, string genre, int year)
        {
            Id = id;
            Title = title;
            Director = director;
            Genre = genre;
            Year = year;
        }

        public Film()
        {
        }
    }
}
