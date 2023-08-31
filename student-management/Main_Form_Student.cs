using student_management.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student_management
{
    public partial class Main_Form_Student : Form
    {
        Student student { get; set; }

        public Main_Form_Student(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login_Form = new Login_Form();
            login_Form.Show();
        }

        private void Main_Form_Student_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Lịch học của " + student.account + "(" + student.name + ")";
            makeSchedule();
        }

        private void makeSchedule()
        {
            dtgvSchedule.DataSource = null;
            dtgvSchedule.ColumnCount = 7;
            dtgvSchedule.RowCount = 4;

            dtgvSchedule.Columns[0].HeaderText = "Thứ 2";
            dtgvSchedule.Columns[1].HeaderText = "Thứ 3";
            dtgvSchedule.Columns[2].HeaderText = "Thứ 4";
            dtgvSchedule.Columns[3].HeaderText = "Thứ 5";
            dtgvSchedule.Columns[4].HeaderText = "Thứ 6";
            dtgvSchedule.Columns[5].HeaderText = "Thứ 7";
            dtgvSchedule.Columns[6].HeaderText = "Chủ nhật";

            dtgvSchedule.Rows[0].HeaderCell.Value = "Ca 1";
            dtgvSchedule.Rows[1].HeaderCell.Value = "Ca 2";
            dtgvSchedule.Rows[2].HeaderCell.Value = "Ca 3";
            dtgvSchedule.Rows[3].HeaderCell.Value = "Ca 4";
        }
    }
}
