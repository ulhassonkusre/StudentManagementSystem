using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class EditStudentPage : Form
    {
        Student student;

        public EditStudentPage(Student student)
        {
            InitializeComponent();
            this.student = student;
            ReceivedData(student);
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this student record?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                StudentService.DeleteStudent(student.Id);
                StudentPage sp = new StudentPage();
                sp.Show();
                this.Hide();
            }

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            StudentPage sp = new StudentPage();
            sp.Show();
            this.Hide();
        }

        private void ReceivedData(Student student)
        {
            FirstName_textBox.Text = student.FirstName;
            LastName_textBox.Text = student.LastName;
            Gender_comboBox.Text = student.Gender;
            Age_textBox.Text = student.Age.ToString();
            Class_textBox.Text = student.Class;
            Address_textBox.Text = student.Address;
            dateTimePicker1.Value = student.DateOfBirth;
        }

        private void EditStudentPage_Load(object sender, EventArgs e)
        {

        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            if (ValidateForm())
            {
                student.Id = st.Id;
                student.FirstName = FirstName_textBox.Text.Trim();
                student.LastName = LastName_textBox.Text.Trim();
                student.Gender = Gender_comboBox.Text.Trim();
                student.DateOfBirth = dateTimePicker1.Value.Date;
                student.Age = int.Parse(Age_textBox.Text.Trim());
                student.Class = Class_textBox.Text.Trim();
                student.Address = Address_textBox.Text.Trim();
                dateTimePicker1.Value = student.DateOfBirth.Date;
            }


            StudentService.UpdateStudent(student.Id, student);
            StudentPage sp = new StudentPage();
            sp.Show();
            this.Hide();
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
                // Reset DateTimePicker if age is not provided
                dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            }
            else
            {
                // Calculate birth date based on provided age
                if (int.TryParse(Age_textBox.Text, out int age))
                {
                    DateTime birthDate = DateTime.Now.AddYears(-age);
                    dateTimePicker1.ValueChanged -= dateTimePicker1_ValueChanged;
                    dateTimePicker1.Value = birthDate;
                    dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
                }

                // Validate age input
                if (!Regex.IsMatch(Age_textBox.Text, "^[0-9]*$"))
                {
                    label104.ForeColor = Color.Red;
                    Age_textBox.Text = string.Empty;
                }
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
            else
            {
                label104.Visible = false;
            }

            if (DateTime.Now.Month < dateTimePicker1.Value.Month || (DateTime.Now.Month == dateTimePicker1.Value.Month && DateTime.Now.Day < dateTimePicker1.Value.Day))
            {
                age--;
            }

            Age_textBox.Text = age.ToString();
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
    }
}
