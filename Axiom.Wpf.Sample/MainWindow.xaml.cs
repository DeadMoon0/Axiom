using Axiom.State;
using Axiom.Wpf.Extensions;
using Axiom.Wpf.Sample.State;
using Axiom.Wpf.Sample.State.Users;
using Axiom.Wpf.Sample.State.Users.Messages;
using Axiom.Wpf.Sample.UserControls.UserItem;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Axiom.Wpf.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            StateStore<MainState>.Create()
                .AddReducer(new MainReducer())
                .AddReducer(new UserReducer())
                .AddReducer(new MessageReducer())
                .AddEffects(new UserEffects())
                .UseSynchronizationContext(SynchronizationContext.Current!)
                .BuildAndMakeDefault();

            InitializeComponent();

            StateStore<MainState>.Default.Bind(x => x.AppTitle).Subscribe(title => this.Title = title);
            StateStore<MainState>.Default.Bind(x => x.Users).BindToCollection(spUsers.Children, (user) => user.Id, (user) => new UC_UserItem(user.Id));
            StateStore<MainState>.Default.Bind(x => x.SelectedUser).Select(x => x == -1).ToggleVisibility(tbSAU, messageView);

            Task.Run(async () =>
            {
                while (true)
                {
                    StateStore<MainState>.Default.Dispatch(MainActions.SetTitleAction, "Axiom Sample App [" + DateTime.Now.ToLongTimeString() + "]");
                    await Task.Delay(100);
                }
            });

            StateStore<MainState>.Default.Dispatch(UserActions.LoadUserAction);

            Task.Run(async () => await MockAIP.ReceiveMessages());
        }
    }
}