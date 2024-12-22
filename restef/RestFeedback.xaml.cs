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
    /// Interaction logic for RestFeedback.xaml
    /// </summary>
    public partial class RestFeedback : Page
    {
        User _currentUserData;
        public RestFeedback(User _currentUser)
        {
            InitializeComponent();

            _currentUserData = _currentUser;

            LoadFeedbacks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var _currentUserDataInfo = db.Users.FirstOrDefault(u => u.Id == _currentUserData.Id);
                _currentUserDataInfo.Feedback = TB_Feedback.Text;
                db.SaveChanges();
                LoadFeedbacks();
            }
        }
        private void LoadFeedbacks()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var feedbacks = db.Users.Where(u => u.Feedback != null).Select(u => new { u.Name, u.Feedback });
                foreach (var feedback in feedbacks)
                {
                    LB_AllFeedbacks.Items.Add($"{feedback.Name}: {feedback.Feedback}");
                }
            }
        }
    }
}
