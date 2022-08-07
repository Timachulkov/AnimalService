using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Baseinfo
{
    public class User 
    {
        int ID { get; set; }
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
                    if (db.Accounts.Any(o => o.Username == Name)) return false; 
                    Account newUser = new Account { Username = Name, Password = Password };
                    // добавляем их в бд
                    db.Accounts.AddAsync(newUser);
                    db.SaveChangesAsync().Wait(1000);

                    ID = Getid(db);
                    return true;
            }
        }
        public bool Login()
        {
            using (baseinfoContext db = new baseinfoContext())
            {
                if (db.Accounts.Any(o => o.Username == Name && o.Password == Password))
                {
                    ID = Getid(db);
                    return true;
                }
                return false;
            }
        }
        protected int Getid(baseinfoContext db)
        {
            var idAccaunt = db.Accounts
                     .Where(b => b.Username == Name)
                     .FirstOrDefault();
            return idAccaunt.UserId;
        }
        public int ToID()
        {
            return ID;
        }
    }
}
