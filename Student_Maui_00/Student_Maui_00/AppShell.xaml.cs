using Student_Maui_00.Views;
namespace Student_Maui_00
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentPage), typeof(StudentPage));
            Routing.RegisterRoute(nameof(AddStudentPage), typeof(AddStudentPage));
            Routing.RegisterRoute(nameof(EditStudentPage), typeof(EditStudentPage));
           
        }
    }
}
