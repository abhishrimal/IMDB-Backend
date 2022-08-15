using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class Poster
    {
        public Poster()
        {
            Movies = new HashSet<Movie>();
        }

        public int PosterId { get; set; }
        public byte[]? DisplayPoster { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
