
using Student_Maui_00.Views;

namespace Student_Maui_00
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        
              // MainPage = new AppShell();
            MainPage = new NavigationPage(new StudentPage());

        }
        
    }
}
