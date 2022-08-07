using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseinfo
{
    internal class User
    {
        string Name { get; set;}
        string Password { get; set;}

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
        public bool Registrate()
        {
            using (baseinfoContext db = new baseinfoContext())
            {
                //try
                //{
                    if (db.Accounts.Any(o => o.Username == Name)) return false; 
                    Account newUser = new Account { Username = Name, Password = Password };
                    // добавляем их в бд
                    db.Accounts.AddAsync(newUser);
                    db.SaveChangesAsync().Wait(1000);
                    return true;
                //}
                //catch(Exception)
                //{
                //    return false;
                //}
            }
        }
        public bool Login()
        {
            using (baseinfoContext db = new baseinfoContext())
            {
                if (db.Accounts.Any(o => o.Username == Name && o.Password == Password)) return true;
                return false;
            }
        }
    }
}
