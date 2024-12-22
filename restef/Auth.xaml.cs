using restef.Data;
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

namespace restef
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }

        private void TB_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Pass.Text = "";
        }

        private void TB_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Login.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                if(string.IsNullOrEmpty(TB_Login.Text) || string.IsNullOrEmpty(TB_Pass.Text))
                {
                    MessageBox.Show("Введите логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var _currentUser = db.Users.FirstOrDefault(u => u.Login == TB_Login.Text);

                    if (_currentUser != null)
                    {
                        MessageBox.Show("Авторизация выполнена успешно!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                        NavigationService.Navigate(new MainRestMenu(_currentUser));
                    }
                    else
                    {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
