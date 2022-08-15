using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovieMappings = new HashSet<ActorMovieMapping>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public int ProducerId { get; set; }
        public int PosterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Poster Poster { get; set; } = null!;
        public virtual Producer Producer { get; set; } = null!;
        public virtual ICollection<ActorMovieMapping> ActorMovieMappings { get; set; }
    }
}
