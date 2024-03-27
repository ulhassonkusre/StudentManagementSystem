using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem1.Models;
using StudentManagementSystem1.Service;

namespace Student_WindowsV7._0
{
    public partial class AddStudentPage : Form
    {
        private Student student;
        public AddStudentPage()
        {
            InitializeComponent();
        }

        private void AddStudentPage_Load(object sender, EventArgs e)
        {

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            StudentPage sp = new StudentPage();
            sp.Show();
            this.Hide();

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            try
            {

                if (ValidateForm())
                {

                    DateTime birthDate = dateTimePicker1.Value.Date;

                    Student stu = new Student
                    {
                        FirstName = FirstName_textBox.Text.Trim(),
                        LastName = LastName_textBox.Text.Trim(),
                        Gender = Gender_comboBox.Text.Trim(),
                        Age = int.Parse(Age_textBox.Text.Trim()),
                        Class = Class_textBox.Text.Trim(),
                        Address = Address_textBox.Text.Trim(),
                        DateOfBirth = dateTimePicker1.Value,
                    };

                    StudentService.AddStudent(stu);


                    StudentPage sd = new StudentPage();


                    sd.Show();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(FirstName_textBox.Text) || string.IsNullOrWhiteSpace(LastName_textBox.Text)
                || string.IsNullOrWhiteSpace(Gender_comboBox.Text) || string.IsNullOrWhiteSpace(Age_textBox.Text))
            {
                if (string.IsNullOrWhiteSpace(FirstName_textBox.Text))
                {
                    label101.Text = "This Field is required";
                    label101.ForeColor = Color.Red;
                }
                else
                {

                    label101.Visible = false;
                }
                if (string.IsNullOrWhiteSpace(LastName_textBox.Text))
                {
                    label102.Text = "This Field is required";
                    label102.ForeColor = Color.Red;
                }
                else
                {

                    label102.Visible = false;
                }
                if (string.IsNullOrWhiteSpace(Gender_comboBox.Text))
                {
                    label103.Text = "This Field is required";
                    label103.ForeColor = Color.Red;

                }
                else
                {

                    label103.Visible = false;
                }

                if (string.IsNullOrWhiteSpace(Age_textBox.Text))
                {
                    label104.Text = "This Field is required";
                    label104.ForeColor = Color.Red;
                    label105.Text = "This Field is required";
                    label105.ForeColor = Color.Red;
                }
                else
                {

                    label104.Visible = false;
                    label105.Visible = false;

                }

            }

            string FirstNameTreamed = FirstName_textBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(FirstNameTreamed) || !FirstNameTreamed.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)) || FirstNameTreamed.Length < 3 || FirstNameTreamed.Length > 15
                || FirstNameTreamed.Contains("  ") || FirstNameTreamed.Replace(" ", "").Length < 3)
            {
                label101.Visible = true;

                if (string.IsNullOrWhiteSpace(FirstNameTreamed))
                {
                    label101.Text = "This Field is required";
                    label101.ForeColor = Color.Red;
                }
                else if (!FirstNameTreamed.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    label101.Text = "This Field is required";

                    label101.ForeColor = Color.Red;

                }

                else if (FirstNameTreamed.Contains("  "))
                {
                    label101.Text = "Consecutive spaces are not allowed";

                    label101.ForeColor = Color.Red;

                }

                else
                {
                    label101.Text = "Length should be between 3 and 15.";
                    label101.ForeColor = Color.Red;
                }
                return false;
            }

            string LastNameTreamed = LastName_textBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(LastNameTreamed) || !LastNameTreamed.All(c => char.IsLetter(c) || LastNameTreamed.Contains(" ") || char.IsWhiteSpace(c)) || LastNameTreamed.Contains("  ") || LastNameTreamed.Length < 2 || LastNameTreamed.Length > 18
                    || LastNameTreamed.Contains("  ") || LastNameTreamed.Replace(" ", "").Length < 2)
            {
                label102.Visible = true;

                if (string.IsNullOrWhiteSpace(LastNameTreamed))
                {
                    label102.Text = "This Field is required";
                    label102.ForeColor = Color.Red;
                }
                if (!LastNameTreamed.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
                {
                    label102.ForeColor = Color.Red;
                }

                if (LastNameTreamed.Contains("  "))
                {
                    label102.Text = "Consecutive spaces are not allowed";

                    label102.ForeColor = Color.Red;

                }

                else
                {
                    label102.Text = "Length should be between 2 and 18.";
                    label102.ForeColor = Color.Red;
                }
                return false;
            }


            if (string.IsNullOrWhiteSpace(Gender_comboBox.Text) || (Gender_comboBox.Text != "Male" && Gender_comboBox.Text != "Female" && Gender_comboBox.Text != "Other"))
            {
                label103.Visible = true;

                if (string.IsNullOrWhiteSpace(Gender_comboBox.Text))
                {
                    label103.Text = "This Field is required";
                    label103.ForeColor = Color.Red;
                }
                else
                {
                    label103.Text = "Invalid Gender";
                    Gender_comboBox.Text = string.Empty;
                    label103.ForeColor = Color.Red;
                }
                return false;
            }


            DateTime Time1 = dateTimePicker1.Value.Date;
            if (!int.TryParse(Age_textBox.Text, out int age) || (age < 5 || age > 99) || age == 0 && dateTimePicker1.Value.Date >= Time1)
            {

                label105.Visible = true;
                if (age == 0 && dateTimePicker1.Value.Date >= Time1)
                {

                    label104.Text = "This Field is required";
                    label104.ForeColor = Color.Red;
                }
                else
                {
                    label105.Text = "Age should be between 5 and 99";
                    label105.ForeColor = Color.Red;
                }
                return false;
            }


            return true;
        }

        private void FirstName_textBox_TextChanged(object sender, EventArgs e)
        { 
            if (string.IsNullOrWhiteSpace(FirstName_textBox.Text))
            {
                label101.Text = "This Field is required";
                label101.ForeColor = Color.Red;

            }
            else
            {

                label101.Visible = false;
            }
            string FirstNameTreamed = FirstName_textBox.Text;

            // Remove any spaces from the input
            FirstNameTreamed = FirstNameTreamed.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(FirstNameTreamed) || !FirstNameTreamed.All(c => char.IsLetter(c)) || FirstNameTreamed.Length < 3 || FirstNameTreamed.Length > 15)
            {
                label101.Visible = true;

                if (string.IsNullOrWhiteSpace(FirstNameTreamed))
                {
                    label101.Text = "This Field is required";
                    label101.ForeColor = Color.Red;
                }

                else if (!FirstNameTreamed.All(c => char.IsLetter(c) || c == ' '))
                {

                    label101.ForeColor = Color.Red;
                }
                if (FirstNameTreamed.Length < 3 || FirstNameTreamed.Length > 15)
                {
                    label101.Text = "Length should be between 3 and 15.";
                    label101.ForeColor = Color.Red;
                }

                else { label101.Visible = false; }


                return;


            }
            else
                label101.Visible = false;
        }

        private void LastName_textBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastName_textBox.Text))
            {
                label102.Text = "This Field is required";
                label102.ForeColor = Color.Red;
            }
            else
            {

                label102.Visible = false;
            }
            string LastNameTreamed = LastName_textBox.Text;


            LastNameTreamed = LastNameTreamed.Replace(" ", "");

            if (string.IsNullOrWhiteSpace(LastNameTreamed) || !LastNameTreamed.All(c => char.IsLetter(c)) ||
                LastNameTreamed.Length < 2 || LastNameTreamed.Length > 18)
            {
                label102.Visible = true;

                if (string.IsNullOrWhiteSpace(LastNameTreamed))
                {
                    label102.Text = "This Field is required";
                    label102.ForeColor = Color.Red;
                }
                else if (!LastNameTreamed.All(c => char.IsLetter(c) || c == ' '))
                {

                    label102.ForeColor = Color.Red;
                }
                if (LastNameTreamed.Length < 2 || LastNameTreamed.Length > 18)
                {
                    label102.Text = "Length should be between 2 and 18.";
                    label102.ForeColor = Color.Red;

                }

                else { label101.Visible = false; }


                return;
            }
            else { label102.Visible = false; }
        }

        private void Gender_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Gender_comboBox.Text))
            {
                label103.Text = "This Field is required";
                label103.ForeColor = Color.Red;

            }
            else
            {

                label103.Visible = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int age = DateTime.Now.Year - dateTimePicker1.Value.Year;

            DateTime Time1 = dateTimePicker1.Value.Date;
            if (age == 0 && dateTimePicker1.Value.Date >= Time1)
            {

                label104.Text = "This Field is required";
                label104.ForeColor = Color.Red;
            }
            if (DateTime.Now.Month < dateTimePicker1.Value.Month || (DateTime.Now.Month == dateTimePicker1.Value.Month && DateTime.Now.Day < dateTimePicker1.Value.Day))
            {
                age--;
            }


            Age_textBox.Text = age.ToString();
            DateTime currentDate = DateTime.Now;
        }

        private void Age_textBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Age_textBox.Text))
            {
                label104.Text = "This Field is required";
                label104.ForeColor = Color.Red;
                label105.Text = "This Field is required";
                label105.ForeColor = Color.Red;
                label104.Visible = true;
                label105.Visible = true;
            }
            else
            {

                label104.Visible = false;
                label105.Visible = false;

            }
            if (string.IsNullOrWhiteSpace(Age_textBox.Text))
            {

                dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            }
            else
            {

                if (int.TryParse(Age_textBox.Text, out int age))
                {

                    DateTime birthDate = DateTime.Now.AddYears(-age);


                    dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
                    dateTimePicker1.Value = birthDate;
                    dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
                }

                if (!Regex.IsMatch(Age_textBox.Text, "^[0-9]*$"))
                {

                    label104.ForeColor = Color.Red;
                    Age_textBox.Text = string.Empty;
                }
            }
        }
    }
}
