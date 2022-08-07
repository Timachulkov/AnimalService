using System;
using System.Collections.Generic;

namespace Baseinfo
{
    public partial class Sex
    {
        public Sex()
        {
            Animals = new HashSet<Animal>();
        }

        public int SexId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
