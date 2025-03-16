using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UsersDbContext _db = new UsersDbContext();
        private List<User> allUsers; // Store all users for searching


        private void LoadData()

        {
            allUsers = _db.Users.ToList(); // Load all users from the database

            Usergrid.ItemsSource = _db.Users.ToList();
        }
        public MainWindow()
        {
            InitializeComponent();
            //LoadData();
           
           ;
            //the below code for to check searchbox functionality works when all users is listed otherwise not
            if (Usergrid == null)
            {
                MessageBox.Show("Usergrid is null! Check XAML or when LoadData() is called.");
            }
            else
            {
                Dispatcher.InvokeAsync(() => LoadData());
            }


        }



        // ..For seach box placeholder , it is not defined by default in the extrenstion or libaries
        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchTextBox.Text == "Search here...")
            {
                SearchTextBox.Text = string.Empty; // Clear the placeholder
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Black); // Change text color
            }
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                SearchTextBox.Text = "Search here..."; // Reset the placeholder
                SearchTextBox.Foreground = new SolidColorBrush(Colors.Gray); // Change text color to gray
            }
        }


        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Usergrid == null || allUsers == null)
            {
               
                return;
            }

            string searchText = SearchTextBox.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText) && searchText != "search here...")
            {
                var filteredUsers = allUsers.Where(u => u.UserName.ToLower().Contains(searchText)).ToList();
                Usergrid.ItemsSource = filteredUsers;
            }
            else
            {
                Usergrid.ItemsSource = allUsers; // Reset to original list
            }
        }

        private void Add_user(object sender, RoutedEventArgs e)
        {
            User user1 = new User();
            //{
            //    UserName = "Shaith",
            //    Email = "",

            //    Password = "1234557",
            //};

            UserWindow uWindow = new UserWindow(user1);
            if (uWindow.ShowDialog() == true)
            {
                _db.Users.Add(user1);
                _db.SaveChanges();
                LoadData();
            }



            //_db.Users.Add(user1);  // Add the new user to the DbSet
            //_db.SaveChanges();     // Save changes to the database
            //LoadData();            // Refresh the DataGrid
        }

        private void remove_user(object sender, RoutedEventArgs e)
        {
            if (Usergrid.SelectedItem is User u)
            {
                _db.Users.Remove(u);

                _db.SaveChanges();
                LoadData();

            }
        }

        private void edit_user(object sender, RoutedEventArgs e)
        {
            if (Usergrid.SelectedItem is User u)
            {
                User editUser = new User();
                editUser.UserName = u.UserName;
                editUser.Password = u.Password;
                editUser.Email = u.Email;

                UserWindow userWindow = new UserWindow(editUser);

                if (userWindow.ShowDialog() == true)
                {
                    u.UserName = editUser.UserName;
                    u.Password = editUser.Password;
                    u.Email = editUser.Email;

                    _db.Users.Update(u);
                    _db.SaveChanges();
                    LoadData();




                }

            }




            //...

        }

    }

}