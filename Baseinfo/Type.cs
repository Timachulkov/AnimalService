using System;
using System.Collections.Generic;

namespace Baseinfo
{
    public partial class Type
    {
        public int TypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Animal Animal { get; set; } = null!;
    }
}
