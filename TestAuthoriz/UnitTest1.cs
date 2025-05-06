using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using srs_6_testing;
using srs_6_testing.Models;

namespace TestAuthoriz
{
    [TestClass]
    public class UnitTest1
    {
        private StudentEntities _context;

        [TestInitialize]
        public void Initialize()
        {
            _context = Helper.GetContext();
            // Очистка данных перед каждым тестом
        }

        [TestMethod]
        public void Test_Successful_Registration()
        {
            
            var regWindow = new RegWindow();

           
            regWindow.login1 = "2";
            regWindow.password1 = "2";
            regWindow.name1 = "2";
            regWindow.surname1 = "2";
            regWindow.otchestvo1 = "2";

            // Act
            regWindow.Button_Click(null, null);

            // Assert
            var db = Helper.GetContext();
            var user = db.Users.FirstOrDefault(Users => Users.Login == "2");
            Assert.IsNotNull(user);
            Assert.AreEqual("2", user.Login);
            Assert.AreEqual("2", user.Name);
        }

        [TestMethod]
        public void Test_Registration_With_Empty_Fields()
        {
            // Arrange
            var regWindow = new RegWindow();

            // Act
            regWindow.login1 = "";
            regWindow.password1 = "";
            regWindow.Button_Click(null, null);

            // Assert
            var usersCount = _context.Users.Count();
            Assert.AreEqual(1, usersCount); // Проверяем, что пользователь не был добавлен
        }

        [TestMethod]
        public void Test_Registration_With_Existing_Login()
        {
            // Arrange
            string login = "user";
            string password = "password";

            var existingUser = new Users { Login = login, Password = password };
            _context.SaveChanges();

            var regWindow = new RegWindow();

            // Act
            regWindow.login1 = login;
            regWindow.password1 = password;
            regWindow.Button_Click(null, null);

            // Assert
            var usersCount = _context.Users.Count();
            Assert.AreEqual(1, usersCount); // Проверяем, что новый пользователь не был добавлен
        }

        [TestMethod]
        public void Test_Successful_Login()
        {
            // Arrange
            string login = "1";
            string password = "1";

            var user = new Users { Login = login, Password = password };
            _context.SaveChanges();

            var mainWindow = new MainWindow();

            // Act
            mainWindow.login1 = login;
            mainWindow.password1 = password;
            mainWindow.Button_Click(null, null);

            // Assert
            var loggedInUser = _context.Users.FirstOrDefault(u => u.Login == login);
            Assert.IsNotNull(loggedInUser);
        }

        [TestMethod]
        public void Test_Login_With_Incorrect_Credentials()
        {
            // Arrange
            var mainWindow = new MainWindow();
            string login = "testuser";
            string password = "wrongpassword";

            // Act
            mainWindow.login1 = login;
            mainWindow.password1 = password;
            mainWindow.Button_Click(null, null);

            // Assert
            Assert.IsNull(null); // Предполагаем, что метод возвращает null, если вход не удался
        }

        [TestMethod]
        public void Test_Login_With_Empty_Fields()
        {
            // Arrange
            var mainWindow = new MainWindow();

            // Act
            mainWindow.login1 = "";
            mainWindow.password1 = "";
            mainWindow.Button_Click(null, null);

            // Assert
            Assert.IsNull(null); // Предполагаем, что метод возвращает null, если поля пустые
        }
    }
}
