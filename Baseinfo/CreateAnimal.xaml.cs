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
using System.Windows.Shapes;

namespace Baseinfo
{
    /// <summary>
    /// Логика взаимодействия для CreateAnimal.xaml
    /// </summary>
    public partial class CreateAnimal : Window
    {
        User userCreater;
        public CreateAnimal()
        {
            InitializeComponent();
            using (baseinfoContext db = new baseinfoContext())
            {
                db.Animals.Load();
                db.Types.Load();
                db.Sexes.Load();
                db.Accounts.Load();
                typeCombobox.ItemsSource = db.Types.Local.ToBindingList();
                SexCombobox.ItemsSource = db.Sexes.Local.ToBindingList();
            }
        }
        public CreateAnimal(User user) : this()
        {
            userCreater = user;
        }

        private void CreateNew_Click(object sender, RoutedEventArgs e)
        {
            DateOnly localDate = DateOnly.FromDateTime(DateAnimal.SelectedDate.Value);
            string localName = nameTextbox.Text;
            
            int localSex, localType, person = userCreater.ToID();
            Type typeSelected = (Type)typeCombobox.SelectedValue;
            localType = typeSelected.TypeId;
            Sex sexSelected = (Sex)SexCombobox.SelectedValue;
            localSex = sexSelected.SexId;
            RegistrateAnimal(localName, localDate, localSex, localType, person);
        }
        private bool RegistrateAnimal(string localName, DateOnly localDateBorn, int localSex, int localType,int Personid)
        {
            using (baseinfoContext db = new baseinfoContext())
            {
                if (db.Animals.Any(o => o.Name == Name)) return false;
                Animal newAnimal = new Animal { Name = localName, DateBorn = localDateBorn, Person = Personid, Sex = localSex, Type = localType};
                // добавляем их в бд
                db.Animals.AddAsync(newAnimal);
                db.SaveChangesAsync().Wait(1000);
                return true;
            }
            
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
