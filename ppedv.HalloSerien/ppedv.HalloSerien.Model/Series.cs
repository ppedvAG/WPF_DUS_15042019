using System.Collections.Generic;

namespace ppedv.HalloSerien.Model
{
    public class Series : Entity
    {
        public string Title { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; } = new HashSet<Episode>();
    }
}
