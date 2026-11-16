namespace CITA255Final
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("gameDesc", typeof(GameDescription));
            Routing.RegisterRoute("addGame", typeof(AddGamePage));
        }
    }
}
