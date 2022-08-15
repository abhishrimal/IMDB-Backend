using System;
using System.Collections.Generic;

namespace IMDB.Project.EF.DB
{
    public partial class Producer
    {
        public Producer()
        {
            Movies = new HashSet<Movie>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; } = null!;
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? CompanyName { get; set; }
        public int GenderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
