namespace IMDB.Project.EF.DB.ApiModel
{
    public class MovieHomePage
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public int ProducerId { get; set; }
        public int PosterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string ProducerName { get; set; }
        public List<Actor> Actors { get; set; }
        public byte[]? DisplayPoster { get; set; }

        public MovieHomePage()
        {
            Actors = new List<Actor>();
        }
    }
}
