using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Baseinfo
{
    public partial class Account
    {
        public Account()
        {
            Animals = new HashSet<Animal>();
        }

        public int UserId { get; set; }
        [Index(IsUnique = true)]
        public string Username { get; set; } = null!;
        [Index(IsUnique = true)]
        public string Password { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }

    }
}
