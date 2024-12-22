using restef.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RestOrders.xaml
    /// </summary>
    public partial class RestOrders : Page
    {
        public RestOrders(User _currentUser)
        {
            InitializeComponent();

            UpdateTotalSum();

            _currentUserData = _currentUser;

            using (ApplicationContext db = new ApplicationContext())
            {
                var _currentUserDataInfo = db.Users.FirstOrDefault(u => u.Id == _currentUserData.Id);

                if (_currentUserDataInfo.Order != null)
                    foreach (var _orders in _currentUserDataInfo.Order)
                    {
                        LB_Orders.Items.Add(_orders);
                    }
            }
        }

        User _currentUserData;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                if (LB_Menu.SelectedItem != null)
                {
                    string _orderWithoutTrash = LB_Menu.SelectedItem.ToString().Substring(37);

                    var _currentUserDataInfo = db.Users.FirstOrDefault(u => u.Id == _currentUserData.Id);

                    if (_currentUserDataInfo != null)
                    {
                        if (_currentUserDataInfo.Order == null)
                        {
                            _currentUserDataInfo.Order = new List<string>();
                        }

                        LB_Orders.Items.Add($"{_orderWithoutTrash}");
                        _currentUserDataInfo.Order.Add($"{_orderWithoutTrash}");

                        db.SaveChanges();

                        MessageBox.Show("Успешно добавлен заказ");

                        UpdateTotalSum();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Выберите позицию из меню!");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var _currentUserDataInfo = db.Users.FirstOrDefault(u => u.Id == _currentUserData.Id);

                if (_currentUserDataInfo != null && _currentUserDataInfo.Order != null && LB_Orders.SelectedItem != null)
                {
                    string selectedOrder = LB_Orders.SelectedItem.ToString();

                    LB_Orders.Items.Remove(LB_Orders.SelectedItem);

                    _currentUserDataInfo.Order.Remove(selectedOrder);

                    db.SaveChanges();

                    UpdateTotalSum();

                    MessageBox.Show("Заказ успешно удален");
                }
                else
                {
                    MessageBox.Show("Выберите заказ для удаления");
                }
            }
        }
        private int ExtractAndSumNumbersFromOrders()
        {
            int totalSum = 0;
            string pattern = @"\d+";

            foreach (var item in LB_Orders.Items)
            {
                MatchCollection matches = Regex.Matches(item.ToString(), pattern);
                foreach (Match match in matches)
                {
                    totalSum += int.Parse(match.Value);
                }
            }

            return totalSum;
        }

        private void UpdateTotalSum()
        {
            int totalSum = ExtractAndSumNumbersFromOrders();
            LBL_Sum.Content = $"Общая сумма заказа - {totalSum} ₽";
        }
    }
}
