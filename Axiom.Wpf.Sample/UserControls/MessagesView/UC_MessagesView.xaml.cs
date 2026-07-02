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
    /// Interaction logic for UC_MessagesView.xaml
    /// </summary>
    public partial class UC_MessagesView : UserControl
    {
        static int nextID = 21;

        public UC_MessagesView()
        {
            InitializeComponent();

            StateStore<MainState>.Default.Bind(UserSelectors.SelectSelectedUser).Select(x => x.Messages).BindToCollection(spMessages.Children, (msg) => msg.Key, (msg) => new UC_MessageItem(msg.Key));
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            string msg = tbMessage.Text;
            nextID = nextID + 2;
            Task.Run(async () => await MockAPI.SendMessage(StateStore<MainState>.Default.GetValue(x => x.SelectedUser), new MessageState
            {
                Id = nextID,
                FromThisUser = true,
                IsSend = false,
                Message = msg
            }));
        }

        bool autoScroll = true;
        private void svMessage_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // User scroll event : set or unset auto-scroll mode
            if (e.ExtentHeightChange == 0)
            {   // Content unchanged : user scroll event
                if (svMessage.VerticalOffset == svMessage.ScrollableHeight)
                {   // Scroll bar is in bottom
                    // Set auto-scroll mode
                    autoScroll = true;
                }
                else
                {   // Scroll bar isn't in bottom
                    // Unset auto-scroll mode
                    autoScroll = false;
                }
            }

            // Content scroll event : auto-scroll eventually
            if (autoScroll && e.ExtentHeightChange != 0)
            {   // Content changed and auto-scroll mode set
                // Autoscroll
                svMessage.ScrollToVerticalOffset(svMessage.ExtentHeight);
            }
        }
    }
}
