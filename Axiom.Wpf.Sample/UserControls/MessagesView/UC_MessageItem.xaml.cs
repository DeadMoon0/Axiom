using Axiom.State;
using Axiom.Wpf.Extensions;
using Axiom.Wpf.Sample.State;
using Axiom.Wpf.Sample.State.Users;
using Axiom.Wpf.Sample.State.Users.Messages;
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

namespace Axiom.Wpf.Sample.UserControls.MessagesView
{
    /// <summary>
    /// Interaction logic for UC_MessageItem.xaml
    /// </summary>
    public partial class UC_MessageItem : UserControl
    {
        public int MessageId { get; }

        public UC_MessageItem(int messageId)
        {
            MessageId = messageId;

            InitializeComponent();

            StateStore<MainState>.Default.Bind(UserSelectors.SelectSelectedUser.Then(MessageSelectors.SelectMessageViaId(MessageId))).Select(x => x.Message).BindToDependencyProperty(lText, Label.ContentProperty);
            StateStore<MainState>.Default.Bind(UserSelectors.SelectSelectedUser.Then(MessageSelectors.SelectMessageViaId(MessageId))).Select(x => x.FromThisUser ? HorizontalAlignment.Right : HorizontalAlignment.Left).BindToDependencyProperty(border, Border.HorizontalAlignmentProperty);
            StateStore<MainState>.Default.Bind(UserSelectors.SelectSelectedUser.Then(MessageSelectors.SelectMessageViaId(MessageId))).Select(x => x.IsSend ? 1 : 0.5).BindToDependencyProperty(border, Border.OpacityProperty);
        }
    }
}
