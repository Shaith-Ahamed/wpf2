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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public User user {  get; private set; } 
        public UserWindow(User user1)
        {
            InitializeComponent();

            user = user1;
            // Bind the product properties to the UI fields
            NameTextbox.Text = user.UserName;
            EmailTextbox.Text = user.Email;
            PasswordTextbox.Text = user.Password;
        }

        private void save_user(object sender, RoutedEventArgs e)
        {
            try
            {
                user.UserName = NameTextbox.Text;
                user.Email = EmailTextbox.Text;
                user.Password = PasswordTextbox.Text;
                DialogResult = true;
                Close();
            }

            catch {
                MessageBox.Show("Error in Input Please try again");
                    DialogResult = false;
                   Close();    




            }


        }

        private void cancel_save(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();

        }
    }
}
