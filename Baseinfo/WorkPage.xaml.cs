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
        DataGrindStatus State;
        User workingUser;
        DataAnimal dataGrindAnimal = new DataAnimal();
        public WorkPage()
        {
            InitializeComponent();
            
        }
        public WorkPage(User user) : this() => workingUser = user;
        private void AddAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            CreateAnimal p = new CreateAnimal(workingUser);
            p.Show();
        }
        private void animals_table_Loaded(object sender, RoutedEventArgs e)
        {
            State = DataGrindStatus.FULL;
            animals_table.ItemsSource = dataGrindAnimal.GetAnimals();
            personColumn.ItemsSource = dataGrindAnimal.GetAccounts();
            sexColumn.ItemsSource = dataGrindAnimal.GetSexs();
            typeColumn.ItemsSource = dataGrindAnimal.GetTypes();
        }

        private void UserAnimal_Checked(object sender, RoutedEventArgs e)
        {
            animals_table.ItemsSource = dataGrindAnimal.GetAnimalPerson(workingUser.ToID());
            State = DataGrindStatus.SHOWBYPERSON;
            Search.Text = "";// Нужно переделать к общей системе контроля через статусы
        }

        private void UserAnimal_Unchecked(object sender, RoutedEventArgs e)
        {
            if(State == DataGrindStatus.SHOWBYPERSON)
            {
                animals_table.ItemsSource = dataGrindAnimal.GetAnimals();
                State = DataGrindStatus.FULL;
            }

        }
        
        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            UserAnimal.IsChecked = false;// Нужно переделать к общей системе контроля через статусы
            if (e.Key == Key.Enter)
            {
                if (Search.Text == "" && State == DataGrindStatus.SHOWIDANIMAL)
                {
                    animals_table.ItemsSource = dataGrindAnimal.GetAnimals();
                    State = DataGrindStatus.FULL;
                }
                else
                {
                    animals_table.ItemsSource = dataGrindAnimal.GetAnimal(Int32.Parse(Search.Text));
                    State = DataGrindStatus.SHOWIDANIMAL;
                }
            }
        }
    }
   
    enum DataGrindStatus
    {
        FULL,
        SHOWBYPERSON,
        SHOWIDANIMAL
    }
}
