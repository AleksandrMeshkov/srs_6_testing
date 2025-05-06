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
using srs_6_testing.Models;

namespace srs_6_testing
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private Users _user;
        private StudentEntities _context;
        public MenuWindow(Users user)
        {
            InitializeComponent();
            _user = user;
            _context = Helper.GetContext();
            LoadUsersData();
        }


        private void LoadUsersData()
        {
            // Загружаем только нужные поля из базы данных
            var users = _context.Users
                .Select(u => new
                {
                    u.UsersID,
                    u.Surname,
                    u.Name,
                    u.Patronymic
                })
                .ToList();

            UsersDataGrid.ItemsSource = users;
        }

    }
}
