using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class ActorMovieMapping
    {
        public int ActorMovieMappingId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Actor Actor { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
