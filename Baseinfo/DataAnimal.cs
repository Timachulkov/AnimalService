using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseinfo
{
    internal class DataAnimal
    {
        List<Animal> animalsSaved;
        List<Account> personSaved;
        List<Sex> sexSaved;
        List<Type> typesSaved;
        internal DataAnimal()
        {
            Update();
        }
        internal void Update()
        {
            using (baseinfoContext db = new baseinfoContext())
            {
                db.Animals.Load();
                db.Accounts.Load();
                db.Types.Load();
                db.Sexes.Load();
                animalsSaved = db.Animals.ToList();
                personSaved = db.Accounts.ToList();
                sexSaved = db.Sexes.ToList();
                typesSaved = db.Types.ToList();

            }
        }
        internal List<Animal> GetAnimalPerson(int personID) => animalsSaved.Where(o => o.Person == personID).ToList();
        internal List<Animal> GetAnimal(int animalID) => animalsSaved.Where(o => o.AnimalsId == animalID).ToList();
        internal List<Animal> GetAnimals() => animalsSaved;
        internal List<Sex> GetSexs() => sexSaved;
        internal List<Type> GetTypes() => typesSaved;
        internal List<Account> GetAccounts() => personSaved;
    }
}
