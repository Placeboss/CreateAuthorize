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
using System.Windows.Shapes;

namespace CreateAuthorize
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        DBContainer db = new DBContainer();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationClick(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || lastName.Text == "" || firstName.Text == "" || middleName.Text == "")
            {
                MessageBox.Show("Empty Fields");
                return;
            }
            if (db.Users.Select(item=>item.Login).Contains(login.Text)) 
            {
                MessageBox.Show("login does not exists");
                return;
            }
            User newUser = new User()
            {
                Login = login.Text,
                Password = password.Password,
                FirstName = firstName.Text,
                MiddleName = middleName.Text,
                LastName = lastName.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Registered");
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow aw = new AuthorizationWindow();
            aw.Show();
            this.Close();
        }
    }
}
