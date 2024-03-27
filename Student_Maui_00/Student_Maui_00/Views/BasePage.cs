using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls;
using Microsoft.Maui.HotReload;



namespace Student_Maui_00.Views;

public abstract class BasePage : ContentPage
{
    public abstract void Build();

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Build();
#if DEBUG
        MauiHotReloadHelper.IsEnabled = true;
#endif

    }
}