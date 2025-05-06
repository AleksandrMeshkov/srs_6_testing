using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using srs_6_testing.Models;

namespace srs_6_testing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

        }

        public string login1 { get; set; }
        public string password1 { get; set; }

      

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            login1 = txtLogin.Text.Trim();
            password1 = txtPassword.Text.Trim();

            var db = Helper.GetContext();
            var user = db.Users.Where(x => x.Name == login1 && x.Password == password1).FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Здраствуйте" + user.Name.ToString());
                MenuWindow menuWindow = new MenuWindow(user);
                menuWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Вы ввели логин или пароль неверно!");
                
            }
        }

        public void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            RegWindow rw = new RegWindow();
            rw.Show();
            this.Close();

        }
    }
}
