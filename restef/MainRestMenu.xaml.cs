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
    /// Interaction logic for MainRestMenu.xaml
    /// </summary>
    public partial class MainRestMenu : Page
    {
        bool _isFirstClicked = false;

        public MainRestMenu(User _currentUser)
        {
            InitializeComponent();

            _currentUserData = _currentUser;
        }

        User _currentUserData;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (parentWindow != null)
            {
                parentWindow.WindowState = WindowState.Minimized;
                parentWindow.WindowStyle = WindowStyle.None;
                parentWindow.Topmost = true;
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);

            if (!_isFirstClicked)
            {
                _isFirstClicked = true;

                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Maximized;
                    parentWindow.WindowStyle = WindowStyle.None;
                    parentWindow.Topmost = true;
                }
            }
            else
            {
                _isFirstClicked = false;
                if (parentWindow != null)
                {
                    parentWindow.WindowState = WindowState.Normal;
                    parentWindow.WindowStyle = WindowStyle.None;
                    parentWindow.Topmost = true;
                }
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RestFrame.Visibility = Visibility.Visible;
            BN_Back.Visibility = Visibility.Visible;

            RestFrame.Navigate(new RestOrders(_currentUserData));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BN_Back.Visibility = Visibility.Collapsed;

            RestFrame.Visibility = Visibility.Collapsed;
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            RestFrame.Visibility = Visibility.Visible;
            BN_Back.Visibility = Visibility.Visible;

            RestFrame.Navigate(new RestFeedback(_currentUserData));
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }

        private void Image_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            RestFrame.Visibility = Visibility.Visible;
            BN_Back.Visibility = Visibility.Visible;

            RestFrame.Navigate(new RestInfo());
        }
    }
}
