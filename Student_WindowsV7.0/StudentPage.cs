using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementSystem1.Models;
using StudentManagementSystem1.Service;

namespace Student_WindowsV7._0
{
    public partial class StudentPage : Form
    {
        private static List<Student> students;
        private Student student;


        public StudentPage()
        {
            InitializeComponent();
            students = StudentService.GetStudents();

            dataGridView.DataSource = students;
            dataGridView.Columns["Id"].Visible = false;
            dataGridView.Columns["Address"].Visible = false;
            dataGridView.Columns["DateOfBirth"].Visible = false;

            dataGridView.CellDoubleClick += dataGridView_CellDoubleClick;
        }

        private void StudentPage_Load(object sender, EventArgs e)
        {

        }

        private void Automatic(object sender, DataGridViewColumnEventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            AddStudentPage add = new AddStudentPage();
            add.Show();
            this.Hide();
        }

        private void Search_textBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = Search_textBox.Text;
            var filteredStudents = StudentService.SearchStudents(searchText);
            dataGridView.DataSource = filteredStudents;
        }

     
             private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.DataSource is List<Student> students && e.RowIndex >= 0 && e.RowIndex < students.Count)
    {
        Student selectedStudent = students[e.RowIndex]; 
          
      
        EditStudentPage editStudentPage = new EditStudentPage(selectedStudent);
        editStudentPage.Show();
        this.Hide();
    }


        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {

        }
    }
}
