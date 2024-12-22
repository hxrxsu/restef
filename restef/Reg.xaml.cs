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
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            NavigationService.Navigate(new Auth());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if(string.IsNullOrEmpty(TB_Name.Text) || string.IsNullOrEmpty(TB_Email.Text) || string.IsNullOrEmpty(TB_Adress.Text) || string.IsNullOrEmpty(TB_Login.Text) || string.IsNullOrEmpty(TB_Pass.Text))
                {
                    MessageBox.Show("Заполните все данныые!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    User _newUser = new User()
                    {
                        Name = TB_Name.Text,
                        Email = TB_Email.Text,
                        Adress = TB_Adress.Text,
                        Login = TB_Login.Text,
                        Password = TB_Pass.Text,
                    };

                    MessageBox.Show("Вы успешно зарегистрировались");
                    db.Users.Add(_newUser);
                    db.SaveChanges();
                }
            }
        }

        private void TB_Name_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Name.Text = "";
        }

        private void TB_Email_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Email.Text = "";
        }

        private void TB_Adress_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Adress.Text = "";
        }

        private void TB_Login_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Login.Text = "";
        }

        private void TB_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            TB_Pass.Text = "";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
