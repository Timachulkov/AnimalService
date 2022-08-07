using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baseinfo
{
    public partial class Animal
    {
        public int AnimalsId { get; set; }
        [Index(IsUnique = true)]
        public string Name { get; set; } = null!;
        [Index(IsUnique = true)]
        public DateOnly DateBorn { get; set; }
        public int Type { get; set; }
        public int Sex { get; set; }
        public int Person { get; set; }

        public virtual Type TypeNavigation { get; set; } = null!;
        public virtual Account PersonNavigation { get; set; } = null!;
        public virtual Sex SexNavigation { get; set; } = null!;

    }
}
