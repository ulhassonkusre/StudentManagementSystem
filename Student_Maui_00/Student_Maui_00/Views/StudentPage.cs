using StudentManagementSystem1.Models;
using StudentService = StudentManagementSystem1.Service.StudentService;

using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;


namespace Student_Maui_00.Views;

public class StudentPage : ContentPage
{
    private ListView studentListView;
    List<Student> students;
    private SearchBar searchBar;

    public StudentPage()
    {
        BackgroundColor = Colors.LightCyan;

       
        NavigationPage.SetHasBackButton(this, false);
        students = StudentService.GetStudents();

        searchBar = new SearchBar
        {
            Placeholder = "Search...", PlaceholderColor = Colors.SteelBlue,
            BackgroundColor = Colors.Transparent, Margin = 10,
            FontSize = 20, Background = Colors.Transparent,
        };
        searchBar.TextChanged += SearchStudents;
        ToolbarItems.Add(new ToolbarItem("+Add", null, () => AddButton_Clicked()));






        //===============================
        var titleLabel = new Label
        {
            Text = "Our Student",
            FontSize = 25,
            TextColor = Colors.White,
            FontAttributes = FontAttributes.Bold,
            FontFamily = null
        };


        var titleView = new StackLayout
        {
            Children = { titleLabel },
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };


        NavigationPage.SetTitleView(this, titleView);

        //=======================================================

        studentListView = new ListView
        {
            ItemTemplate = new DataTemplate(() =>
            {

                var firstNameLabel = new Label { HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(10, 0, 0, 0), FontSize = 17 , FontAttributes = FontAttributes.Bold};
                firstNameLabel.SetBinding(Label.TextProperty, "FirstName");

                var lastNameLabel = new Label { VerticalOptions = LayoutOptions.Start, Margin = new Thickness(10, 0, 0, 0), FontSize = 17,FontAttributes = FontAttributes.Bold };
                lastNameLabel.SetBinding(Label.TextProperty, "LastName");

                var ageLabel = new Label { Margin = new Thickness(20, 0, 0, 0), FontSize = 17, FontAttributes = FontAttributes.Bold };
                ageLabel.SetBinding(Label.TextProperty, "Age");

                var genderLabel = new Label { HorizontalOptions = LayoutOptions.End, Margin = new Thickness(0, 0, 10, 0), FontSize = 17, FontAttributes = FontAttributes.Bold };
                genderLabel.SetBinding(Label.TextProperty, "Gender");

                var classLabel = new Label { HorizontalOptions = LayoutOptions.End, Margin = new Thickness(0, 0, 10, 0), FontSize = 17, FontAttributes = FontAttributes.Bold };
                classLabel.SetBinding(Label.TextProperty, "Class");

                var grid = new Grid
                {

                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Star },
                        new ColumnDefinition { Width = GridLength.Auto },
                        new ColumnDefinition { Width = GridLength.Star }
                    }

                };

                StackLayout name = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { firstNameLabel, lastNameLabel },
                };

                grid.Add(name, 0, 0);
                grid.Add(ageLabel, 0, 1);
                grid.Add(genderLabel, 2, 0);
                grid.Add(classLabel, 2, 1);

                return new ViewCell { View = grid };

            }),
            SeparatorVisibility = SeparatorVisibility.Default,
        };



        studentListView.ItemTapped += OnItemDoubleTapped;
        Frame contentFrame = new Frame
        {
            BackgroundColor = Colors.LightCyan,
            BorderColor = Colors.Black,
            Padding = new Thickness(10),
            Margin = new Thickness(20),
            HasShadow = true,
           
           
            Content = new StackLayout
            {
                Children = {
                    searchBar,
                    studentListView
                }
            }

        };
        Content = contentFrame;

            }
        
    
    protected override void OnAppearing()
    {
        base.OnAppearing();
       

        RefreshStudentList();
       
    }

    public void RefreshStudentList()
    {

        var students = StudentService.GetStudents();

        if (studentListView != null && students != null)
        {
            studentListView.ItemsSource = students;
        }
        if (students.Any())
            studentListView.SelectedItem = students[0];




    }

    
    private int lastTappedIndex = -1;
    private DateTime lastTappedTime = DateTime.MinValue;
    private async void OnItemDoubleTapped(object sender, EventArgs e)
    {
        var currentTime = DateTime.Now;
        var tappedIndex = studentListView.TemplatedItems.GetGlobalIndexOfItem(sender as Element);

        if (tappedIndex == lastTappedIndex && (currentTime - lastTappedTime).TotalMilliseconds < 300)
        {
            if (studentListView.SelectedItem is Student student)
            {
                await Navigation.PushAsync(new EditStudentPage(student));
            }
        }

        lastTappedIndex = tappedIndex;
        lastTappedTime = currentTime;
    }
    public async void AddButton_Clicked()
    {
        await Navigation.PushAsync(new AddStudentPage());
       
    }
    private void SearchStudents(object? sender, TextChangedEventArgs e)
    {
       

        List<Student> filteredList = students.Where(s =>
            s.FirstName.ToLower().Contains(searchBar.Text.ToLower()) ||
            s.LastName.ToLower().Contains(searchBar.Text.ToLower()) ||
            s.Age.ToString().Contains(searchBar.Text)
        ).ToList();

        studentListView.ItemsSource = filteredList;
    }
  
  





}