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
using srs_6_testing.Models;

namespace srs_6_testing
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        public string login1 { get; set; }
        public string password1 { get; set; }
        public string name1 { get; set; }
        public string surname1 { get; set; }
        public string otchestvo1 { get; set; }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            login1 = txtLogin.Text.Trim();
            password1 = txtPassword.Text.Trim();
            name1 = txtName.Text.Trim();
            surname1 = txtSurname.Text.Trim();
            otchestvo1 = txtPatronymic.Text.Trim();

            
            
            if (string.IsNullOrEmpty(login1) || string.IsNullOrEmpty(password1))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            var db = Helper.GetContext();
            {
                if (db.Users.Any(x => x.Login == login1))  
                {
                    MessageBox.Show("Пользователь с таким логином уже существует.");
                    return;
                }

                var newUser = new Users
                {
                    Name = name1,
                    Surname = surname1,
                    Patronymic = otchestvo1,
                    Password = password1,
                    Login = login1

                };

                db.Users.Add(newUser);

                db.SaveChanges();

                MessageBox.Show("Пользователь успешно добавлен!");

                MenuWindow menuWindow = new MenuWindow(newUser);
                menuWindow.Show();
                this.Close();
            }
        }
    }
}
