using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class Gender
    {
        public Gender()
        {
            Actors = new HashSet<Actor>();
        }

        public int GenderId { get; set; }
        public string Gender1 { get; set; } = null!;

        public virtual ICollection<Actor> Actors { get; set; }
    }
}
