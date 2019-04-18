using System;
using System.Collections.Generic;

namespace ppedv.HalloSerien.Model
{
    public class Person : Entity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 

        public virtual ICollection<Episode> Directed { get; set; } = new HashSet<Episode>();
        public virtual ICollection<Episode> Acted { get; set; } = new HashSet<Episode>();

    }
}
