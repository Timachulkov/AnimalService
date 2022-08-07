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
        public WorkPage()
        {
            InitializeComponent();

            using (baseinfoContext db = new baseinfoContext())
            {
               
                //db.Animals.ToList();

                db.Animals.Load();
                db.Accounts.Load();
                db.Types.Load();
                db.Sexes.Load();
                animals_table.ItemsSource = db.Animals.Local.ToBindingList();
                personColumn.ItemsSource = db.Accounts.Local.ToBindingList();
                sexColumn.ItemsSource = db.Sexes.Local.ToBindingList();
                typeColumn.ItemsSource = db.Types.Local.ToBindingList();

            }
        }
            private void animals_table_Loaded(object sender, RoutedEventArgs e)
            {

            }

            private void DataGridComboBoxColumn_SourceUpdated(object sender, DataTransferEventArgs e)
            {

            }
        
    }
}
