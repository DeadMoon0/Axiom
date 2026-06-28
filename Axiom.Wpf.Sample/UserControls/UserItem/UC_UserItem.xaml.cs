using Axiom.State;
using Axiom.Wpf.Extensions;
using Axiom.Wpf.Sample.State;
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

        public static readonly DependencyProperty UserSuffixProperty =
            DependencyProperty.Register("UserSuffix", typeof(string), typeof(UC_UserItem), new PropertyMetadata(""));

        public UC_UserItem(int userId)
        {
            UserId = userId;

            StateStore<MainState>.Default.Bind(x => x.Users[userId - 1].UserName).BindToDependencyProperty(this, UserNameProperty);
            StateStore<MainState>.Default.Bind(x => x.Users[userId - 1].UserSuffix).BindToDependencyProperty(this, UserSuffixProperty);

            InitializeComponent();
        }
    }
}
