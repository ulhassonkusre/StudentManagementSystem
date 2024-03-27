
using Microsoft.Maui.Controls;
using Microsoft.Extensions.Logging.Abstractions;
using StudentManagementSystem1.Models;
using StudentManagementSystem1.Service;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Student_Maui_00.Views;

public class AddStudentPage : ContentPage
{
    Label Error1, Error2, Error3, Error4, Error5;
    Entry FirstNameEntry, LastNameEntry, AgeEntry, ClassEntry; Editor AddressEntry;
    Picker picker;
    DatePicker dateOfBirthEntry; 
    public AddStudentPage()
    {
       
        BackgroundColor = Colors.LightCyan;
        
        //===============================
        var titleLabel = new Label
        {
            Text = "Add Student",
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

        Label FirstNameLabel = new Label
        {
            Margin = new Thickness(15, 20, 0, 0),
            Text = "First Name",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Start,
        };

        Label starLabel1 = new Label
        {
            Margin = new Thickness(0, 15, 0, 0),
            Text = "*",
            TextColor = Colors.Red,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            VerticalOptions = LayoutOptions.Start,
        };



        FirstNameEntry = new Entry
        {
            Margin = new Thickness(15, -5, 0, 0),
            MaxLength = 15,
            FontSize = 17,
            WidthRequest = 300,
            Placeholder = "Please Enter Last Name",
            PlaceholderColor = Colors.Black,
            HorizontalOptions = LayoutOptions.StartAndExpand,

        };


        StackLayout FirstNameLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { FirstNameLabel, starLabel1 },
        };

        Content = new StackLayout
        {
            Children = { FirstNameLayout }
        };
        //=========================================================================

        Label LastNameLabel = new Label
        {
            Margin = new Thickness(15, 10, 0, 0),
            Text = "Last Name",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Start,
        };
        Label starLabel2 = new Label
        {
            Margin = new Thickness(0, 5, 0, 0),
            Text = "*",
            TextColor = Colors.Red,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            VerticalOptions = LayoutOptions.Start
        };
        LastNameEntry = new Entry
        {
            Margin = new Thickness(15, -5, 0, 0),
            MaxLength = 15,
            FontSize = 17,
            WidthRequest = 300,
            PlaceholderColor = Colors.Black,
            Placeholder = "Please Enter Last Name",
            HorizontalOptions = LayoutOptions.StartAndExpand,
        };

        StackLayout lastNameLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { LastNameLabel, starLabel2 },
        };

        Content = new StackLayout
        {
            Children = { lastNameLayout }
        };

        //=========================================================================

        Label GenderLabel = new Label
        {
            Margin = new Thickness(15, 10, 0, 0),
            Text = "Gender",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };

        Label starLabel3 = new Label
        {
            Margin = new Thickness(0, 5, 0, 0),
            Text = "*",
            TextColor = Colors.Red,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            VerticalOptions = LayoutOptions.Start
        };
        var Gender = new List<string>();
        Gender.Add("Please Select Gender");
        Gender.Add("Male");
        Gender.Add("Female");
        Gender.Add("Other");


        picker = new Picker
        {
            FontSize = 17,
            TextColor = Colors.Black,
            WidthRequest = 300,
            Margin = new Thickness(15, -5, 0, 0),
            HorizontalOptions = LayoutOptions.StartAndExpand,
        };


        picker.ItemsSource = Gender;
        picker.SelectedIndex = 0;
        StackLayout GenderLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { GenderLabel, starLabel3 },
        };

        Content = new StackLayout
        {
            Children = { GenderLayout }
        };

        //=========================================================================

        Label DateOfBirthLabel = new Label
        {
            Margin = new Thickness(15, 10, 0, 0),
            Text = "Date Of Birth",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };
        Label starLabel4 = new Label
        {
            Margin = new Thickness(0, 5, 0, 0),
            Text = "*",
            TextColor = Colors.Red,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            VerticalOptions = LayoutOptions.Start
        };

        dateOfBirthEntry = new DatePicker
        {
            Format = "dd-MM-yyyy",
            MinimumDate = new DateTime(1924, 1, 1),
            MaximumDate = new DateTime(2024, 12, 31),
            Margin = new Thickness(15, -5, 0, 0),
            FontSize = 16,
            TextColor = Colors.Black,
            WidthRequest = 300,
            FontFamily = null,
            HorizontalOptions = LayoutOptions.StartAndExpand,

        };


        StackLayout DateOfBirthLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { DateOfBirthLabel, starLabel4 },
        };

        Content = new StackLayout
        {
            Children = { DateOfBirthLayout }
        };
        Label AgeLabel = new Label
        {
            Margin = new Thickness(15, 10, 0, 0),
            Text = "Age",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
        };
        Label starLabel5 = new Label
        {
            Margin = new Thickness(0, 5, 0, 0),
            Text = "*",
            TextColor = Colors.Red,
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            VerticalOptions = LayoutOptions.Start
        };

        //=========================================================================


        AgeEntry = new Entry

        {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Keyboard = Keyboard.Numeric,
            Placeholder = "Please Enter Age",
            FontSize = 18,
            TextColor = Colors.Black,
            PlaceholderColor = Colors.Black,
            WidthRequest = 300,
            Margin = new Thickness(15, -5, 0, 0),

        };
        StackLayout AgeLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { AgeLabel, starLabel5 },
        };

        Content = new StackLayout
        {
            Children = { AgeLayout }
        };
        Label ClassLabel = new Label
        {
            Margin = new Thickness(15, 15, 0, 0),
            Text = "Class",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Start,
        };

        //=========================================================================

        ClassEntry = new Entry
        {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Margin = new Thickness(15, -5, 0, 0),
            MaxLength = 15,
            FontSize = 17,
            WidthRequest = 300,
            Placeholder = "Please Enter Class",
            PlaceholderColor = Colors.Black,

        };

        StackLayout ClassLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { ClassLabel },
        };

        Content = new StackLayout
        {
            Children = { ClassLayout }
        };
        Label AddressLabel = new Label
        {
            Margin = new Thickness(15, 20, 0, 0),
            Text = "Address",
            FontSize = 18,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.StartAndExpand,
        };

        //=========================================================================

        AddressEntry = new Editor
        {
            Margin = new Thickness(15, -5, 0, 0),

            FontSize = 17,
            WidthRequest = 300,
            Placeholder = "Please Enter Address",
            PlaceholderColor = Colors.Black,
            HorizontalOptions = LayoutOptions.StartAndExpand,
        };

        StackLayout AddressLayout = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Children = { AddressLabel },
        };

        Content = new StackLayout
        {
            Children = { AddressLayout }
        };

        //Button SaveButton = new Button
        //{
        //    Text = "Save",
        //    TextColor = Colors.White,
        //    FontAttributes = FontAttributes.Bold,
        //    FontSize = 20,
        //    VerticalOptions = LayoutOptions.EndAndExpand,
        //    Margin = new Thickness(0, 40, 0, 0),
        //    WidthRequest = 300,
        //    Background = Colors.SteelBlue
        //};

        //SaveButton.Clicked += (sender, e) => SaveButton_Clicked();



        ToolbarItems.Add(new ToolbarItem("Save", null, () => SaveButton_Clicked()));


        //============================================= Error  ===============================================
        Error1 = new Label { FontSize = 15, Opacity = 0, TextColor = Colors.Red, Text = "This Field is required.", HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(15, -10, 0, 0) };
        Error2 = new Label { Opacity = 0, FontSize = 15, TextColor = Colors.Red, Text = "This Field is required.", HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(15, -10, 0, 0) };
        Error3 = new Label { Opacity = 0, FontSize = 15, TextColor = Colors.Red, Text = "This Field is required.", HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(15, -10, 0, 0) };
        Error4 = new Label { Opacity = 0, FontSize = 15, TextColor = Colors.Red, Text = "This Field is required.", HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(15, -10, 0, 0) };
        Error5 = new Label { Opacity = 0, FontSize = 15, TextColor = Colors.Red, Text = "This Field is required.", HorizontalOptions = LayoutOptions.Start, Margin = new Thickness(15, -10, 0, 0) };

        //=========================================================

        dateOfBirthEntry.DateSelected += (sender, e) =>
        {
            Console.WriteLine("Date selected: " + e.NewDate.ToString());
            int age = DateTime.Today.Year - e.NewDate.Year;
            AgeEntry.Text = age > 0 ? age.ToString() : string.Empty;
        };
        //datePicker.DateSelected += OnDateSelected;

        AgeEntry.TextChanged += (sender, e) =>
        {
            Keyboard k = Keyboard.Numeric;
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {

                dateOfBirthEntry.Date = DateTime.Today;
            }
            else if (int.TryParse(e.NewTextValue, out int age))
            {

                DateTime dateOfBirth = DateTime.Today.AddYears(-age);
                dateOfBirthEntry.Date = dateOfBirth;
            }
        };

        //=====================================================================

        async void SaveButton_Clicked()
        {
            if (ValidateForm())
            {
                if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
                {
                    Error1.Text = "This Field is required.";
                    Error1.Opacity = 1;
                    return;
                }
                else if (!FirstNameEntry.Text.Replace(" ", "").All(c => char.IsLetter(c)) || FirstNameEntry.Text.Replace(" ", "").Length < 3 || FirstNameEntry.Text.Replace(" ", "").Length > 15)
                {
                    Error1.Text = "First Name should be between 3 and 15.";
                    Error1.Opacity = 1;
                    return;
                }
                else
                {
                    Error1.Opacity = 0;
                }
                if (string.IsNullOrWhiteSpace(LastNameEntry.Text))
                {
                    Error2.Text = "This Field is required.";
                    Error2.Opacity = 1;
                    return;
                }
                else if (!LastNameEntry.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || LastNameEntry.Text.Length < 2 || LastNameEntry.Text.Length > 18 || LastNameEntry.Text.Contains("  ") || LastNameEntry.Text.Replace(" ", "").Length < 2)
                {
                    Error2.Text = "Last Name should be between 2 and 18.";
                    Error2.Opacity = 1;
                    return;
                }
                else
                {
                    Error2.Opacity = 0;
                }
                if (picker.SelectedIndex == 0)
                {
                    Error3.Text = "This Field is required.";
                    Error3.Opacity = 1;
                    return;
                }
                else
                {
                    Error2.Opacity = 0;
                }
                if (string.IsNullOrWhiteSpace(AgeEntry.Text))
                {
                    Error5.Text = "This Field is required.";
                    Error5.Opacity = 1;
                    return;
                }
                else if (!int.TryParse(AgeEntry.Text, out int age) || age < 5 || age > 99)
                {
                    Error5.Text = "Age must be between 5 and 99.";
                    Error5.Opacity = 1;
                    return;
                }
                else
                {
                    Error5.Opacity = 0;
                }

                Student student = new Student
                {
                    FirstName = Regex.Replace(FirstNameEntry.Text.Trim(), @"\s+ ", " "),
                    LastName = Regex.Replace(LastNameEntry.Text.Trim(), @"\s+ ", " "),
                    Gender = (string)picker.SelectedItem,
                    DateOfBirth = dateOfBirthEntry.Date,
                    Age = int.Parse(AgeEntry.Text),
                    Class = ClassEntry.Text,
                    Address = AddressEntry.Text
                };
                StudentService.AddStudent(student);
                await Navigation.PushAsync(new StudentPage());
                           }

        }

        //====================================================================================
        Frame contentFrame = new Frame
        {
            BackgroundColor = Colors.LightCyan,
            BorderColor = Colors.Black,
            Padding = new Thickness(10),
            Margin = new Thickness(20),
            HasShadow = true,
         
            Content = new VerticalStackLayout
            {
                Children =
                {
                    FirstNameLayout,FirstNameEntry,Error1,
                    lastNameLayout,LastNameEntry,Error2,
                     GenderLayout,picker,Error3,
                   DateOfBirthLayout,dateOfBirthEntry,Error4,
                    AgeLayout,AgeEntry,Error5,
                    ClassLayout,ClassEntry,
                   AddressLayout,AddressEntry, 
                }
            }
        };
        Content = contentFrame;
    



    //Content = new VerticalStackLayout
    //{
    //    Children = { FirstNameLayout,FirstNameEntry,Error1,
    //               lastNameLayout,LastNameEntry, Error2,
    //               GenderLayout,picker,Error3,
    //               DateOfBirthLayout,dateOfBirthEntry,Error4,
    //                AgeLayout,AgeEntry,Error5,
    //                ClassLayout,ClassEntry,
    //               AddressLayout,AddressEntry, SaveButton
    //    }
    //};

    //=================================================================

    FirstNameEntry.TextChanged += (sender, e) =>
        {
            var newText = Regex.Replace(FirstNameEntry.Text, @"[^a-zA-Z\s]+$", "");
            if (newText != FirstNameEntry.Text)
            {
                FirstNameEntry.Text = newText;
            }

            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
            {
                Error1.Text = "This Field is required.";
                Error1.Opacity = 1;
            }
            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text)||!FirstNameEntry.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || FirstNameEntry.Text.Length < 3 || FirstNameEntry.Text.Length > 15 || FirstNameEntry.Text.Contains("  ") || FirstNameEntry.Text.Replace(" ", "").Length < 3)
            {
                Error1.Text = "First Name should be between 3 and 15.";
                Error1.Opacity = 1;
                return;
            }
            else
            {
                Error1.Opacity = 0;
            }
        };
        LastNameEntry.TextChanged += (sender, e) =>
        {
            var newText = Regex.Replace(LastNameEntry.Text, @"[^a-zA-Z\s]+$", "");
            if (newText != LastNameEntry.Text)
            {
                LastNameEntry.Text = newText;
            }
            if (string.IsNullOrWhiteSpace(LastNameEntry.Text))
            {
                Error2.Text = "This Field is required.";
                Error2.Opacity = 1;
            }
            else if (!LastNameEntry.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || LastNameEntry.Text.Length < 2 || LastNameEntry.Text.Length > 18 || LastNameEntry.Text.Contains("  ") || LastNameEntry.Text.Replace(" ", "").Length < 2)
            {
                Error2.Text = "Last Name should be between 2 and 18.";
                Error2.Opacity = 1;
            }
            else
            {
                Error2.Opacity = 0;
            }
        };
        picker.SelectedIndexChanged += (sender, e) =>
            {
                if (picker.SelectedIndex == 0)
                {
                    Error3.Opacity = 1;
                    bool flag = true;
                    return;
                }
                else
                {
                    Error3.Opacity = 0;

                    return;
                }
            };
        dateOfBirthEntry.PropertyChanged += (sender, e) =>
        {
            if (e.PropertyName == nameof(dateOfBirthEntry.Date))
            {
                if (dateOfBirthEntry.Date == DateTime.Today)
                {
                    Error4.Text = "This Field is required.";
                    Error4.Opacity = 1;
                }
                else
                {
                    Error4.Opacity = 0;
                }
            }
        };
        AgeEntry.TextChanged += (sender, e) =>
        {
            if (string.IsNullOrWhiteSpace(AgeEntry.Text))
            {
                Error5.Text = "This Field is required.";
                Error5.Opacity = 1;
            }
            else if (!int.TryParse(AgeEntry.Text, out int age) || age < 5 || age > 99)
            {
                Error5.Text = "Age must be between 5 and 99.";
                Error5.Opacity = 1;
            }
            else
            {
                Error5.Opacity = 0;
            }
        };

        //================================================================================

        async void  CancelButton_Clicked()
        {
            await Navigation.PushAsync(new StudentPage());
            Navigation.RemovePage(this);
        }
    }

    //==========================================================================================
        bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(FirstNameEntry.Text))
            {

                Error1.Opacity = 1;
                
            }
            else
            {

                Error1.Opacity = 0;
            }

            if (string.IsNullOrWhiteSpace(LastNameEntry.Text))
            {

                Error2.Opacity = 1;

            }
            else
            {

                Error2.Opacity = 0;
            }
            if (picker.SelectedIndex == 0)
            {

                Error3.Opacity = 1;

            }
            else
            {

                Error3.Opacity = 0;
            }

            if (string.IsNullOrWhiteSpace(AgeEntry.Text))
            {

                Error4.Opacity = 1;

                Error5.Opacity = 1;

            }
            else
            {
                Error4.Opacity = 0;
                Error5.Opacity = 0;

            }
            return true;

        }
    //===============================================================================
}
       


