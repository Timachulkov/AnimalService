using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Baseinfo
{
    /// <summary>
    /// Логика взаимодействия для WorkPage.xaml
    /// </summary>
    public partial class WorkPage : Page
    {
        User workingUser;
        DataGrindAnimal dataGrindAnimal = new DataGrindAnimal();
        public WorkPage()
        {
            InitializeComponent();
        }
        public WorkPage(User user) : this()
        {
            workingUser = user;
        }
        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAnimal p = new CreateAnimal(workingUser);
            p.Show();
        }
        private void animals_table_Loaded(object sender, RoutedEventArgs e)
        {
            animals_table.ItemsSource = dataGrindAnimal.GetAnimals();
            personColumn.ItemsSource = dataGrindAnimal.GetAccounts();
            sexColumn.ItemsSource = dataGrindAnimal.GetSexs();
            typeColumn.ItemsSource = dataGrindAnimal.GetTypes();
        }

        private void UserAnimal_Checked(object sender, RoutedEventArgs e)
        {
            animals_table.ItemsSource = dataGrindAnimal.AnimalPerson(workingUser.ToID());
        }
    

        private void UserAnimal_Unchecked(object sender, RoutedEventArgs e)
        {
            animals_table.ItemsSource = dataGrindAnimal.GetAnimals();
        }

    }
    internal class DataGrindAnimal
    {
        List<Animal> animalsSaved;
        List<Account> personSaved;
        List<Sex> sexSaved;
        List<Type> typesSaved;
        internal DataGrindAnimal()
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
        internal List<Animal> AnimalPerson(int personID)
        {
            return animalsSaved.Where(o => o.Person == personID).ToList();
        }
        internal List<Animal> GetAnimals()
        {
            return animalsSaved;
        }
        internal List<Sex> GetSexs()
        {
            return sexSaved;
        }
        internal List<Type> GetTypes()
        {
            return typesSaved;
        }
        internal List<Account> GetAccounts()
        {
            return personSaved;
        }
    }
}
