using Axiom.State;
using Axiom.Wpf.Extensions;
using Axiom.Wpf.Sample.State;
using Axiom.Wpf.Sample.State.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace Axiom.Wpf.Sample.UserControls.UserItem
{
    /// <summary>
    /// Interaction logic for UC_UserItem.xaml
    /// </summary>
    public partial class UC_UserItem : UserControl
    {
        public int UserId { get; }

        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(UC_UserItem), new PropertyMetadata(""));

        //public static readonly DependencyProperty UserSuffixProperty =
        //    DependencyProperty.Register("UserSuffix", typeof(string), typeof(UC_UserItem), new PropertyMetadata(""));

        public UC_UserItem(int userId)
        {
            UserId = userId;

            InitializeComponent();

            StateStore<MainState>.Default.Bind(UserSelectors.SelectUserViaId(userId)).Select(x => x.UserName).BindToDependencyProperty(this, UserNameProperty);
            StateStore<MainState>.Default.Bind(UserSelectors.SelectUserViaId(userId)).Select(x => x.UserSuffix).BindToDependencyProperty(lSuffix, Label.ContentProperty);

            Task.Run(async () =>
            {
                await Task.Delay(new Random().Next(1000));
                while (true)
                {
                    StateStore<MainState>.Default.Dispatch(UserActions.SetUserSuffixAction, UserId, ((List<string>)["XD", ":)", "=D", ":|"]).ElementAt(new Random().Next(4)));
                    await Task.Delay(1000);
                }
            });
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StateStore<MainState>.Default.Dispatch(MainActions.SetSelectedUser, UserId);
        }
    }
}
