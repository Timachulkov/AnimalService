using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для registrate.xaml
    /// </summary>
    public partial class registrate : Page
    {
        public registrate()
        {
            InitializeComponent();
        }

        internal void RegistrateButton_Click(object sender, RoutedEventArgs e)
        {
            string pageName = NameTextbox.Text, pagePassword = PasswordTextBox.Text;
            User user = new(pageName, pagePassword);
            if (user.Registrate())
            {
                WorkPage p = new WorkPage(user);
                this.NavigationService.Navigate(p);
            }
            else
            {
                NameError.Visibility = Visibility.Visible;
                //MessageBox.Show("Такое имя пользователя уже существует");
            }
        }
    }
}
