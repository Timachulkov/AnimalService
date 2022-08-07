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
    /// Логика взаимодействия для login.xaml
    /// </summary>
    public partial class login : Page
    {
        public login()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("registrate.xaml", UriKind.Relative));
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string pageName = NameTextbox.Text, pagePassword = PasswordTextBox.Text;
            User user = new User(pageName, pagePassword);
            if (user.Login())
            {
                this.NavigationService.Navigate(new Uri("WorkPage.xaml", UriKind.Relative));
            }
            else
            {
                //NameError.Visibility = Visibility.Visible;
                MessageBox.Show("Неправильное имя или пароль");
            }
        }
    }
}
