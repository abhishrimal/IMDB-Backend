using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class Actor
    {
        public Actor()
        {
            ActorMovieMappings = new HashSet<ActorMovieMapping>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Gender Gender { get; set; } = null!;
        public virtual ICollection<ActorMovieMapping> ActorMovieMappings { get; set; }
    }
}
