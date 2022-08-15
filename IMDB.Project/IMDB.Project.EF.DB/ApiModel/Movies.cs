using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Project.EF.DB.ApiModel
{
    public class Movies
    {
        public Movies()
        {
            ActorIds = new List<int>();
        }
        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public int ProducerId { get; set; }
        public int PosterId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<int> ActorIds { get; set; }
    }
}
