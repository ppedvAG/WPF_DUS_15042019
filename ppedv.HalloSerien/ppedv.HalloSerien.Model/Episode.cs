using System;
using System.Collections.Generic;

namespace ppedv.HalloSerien.Model
{
    public class Episode : Entity
    {
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public TimeSpan Length { get; set; }
        public int Season { get; set; }

        public virtual Person Director { get; set; }
        public virtual ICollection<Person> Actors { get; set; } = new HashSet<Person>();
        public virtual Series Series { get; set; }
    }
}
