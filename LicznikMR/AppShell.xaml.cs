using LicznikMR.Views;
namespace LicznikMR
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(CounterPage), typeof(CounterPage));
        }
    }
}
