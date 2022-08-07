using System;
using System.Collections.Generic;

namespace Baseinfo
{
    public partial class Type
    {
        public Type()
        {
            Animals = new HashSet<Animal>();
        }

        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
