using System;
using System.Collections.Generic;

namespace Baseinfo
{
    public partial class Account
    {
        public Account()
        {
            Animals = new HashSet<Animal>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Animal> Animals { get; set; }

       // public override string ToString()
       // {
       //     return Convert.ToString(Username);
       // }
    }
}
