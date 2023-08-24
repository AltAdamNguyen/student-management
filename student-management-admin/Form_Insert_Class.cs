using student_management_admin.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student_management_admin
{
    public partial class Form_Insert_Class : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();
        List<string> listStudent = new List<string>();
        string search { get; set; }

        public Form_Insert_Class(string search, Main_Form_Admin main_Form)
        {
            InitializeComponent();
            this.search = search;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            getDataStudent(search);
        }

        private void Form_Insert_Class_Load(object sender, EventArgs e)
        {
            getDataStudent(search);

        }

        private void getDataStudent(string search)
        {
            var query = db.Students
                .Where(s => s.active == true && (search == null || s.account.Contains(search)));

            List<Student> students = query.ToList();

            DataTable table = new DataTable();
            table.DefaultView.AllowNew = false;
            table.DefaultView.AllowDelete = false;

            table.Columns.Add("Chọn", typeof(bool));
            table.Columns.Add("Mã SV", typeof(string));
            table.Columns.Add("Tên SV", typeof(string));

            table.Columns[1].ReadOnly = true;
            table.Columns[2].ReadOnly = true;

            foreach (var student in students)
            {
                bool isSelect = listStudent.Contains(student.code);
                table.Rows.Add(isSelect, student.code, student.name);
            }

            dtgvStudent.DataSource = table;
        }

        private void dtgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    bool selectValue = Convert.ToBoolean(dtgvStudent.Rows[e.RowIndex].Cells[0].Value);
                    string code = dtgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (!selectValue)
                    {
                        listStudent.Add(code);
                    } else
                    {
                        listStudent.Remove(code);
                    }
                    Console.WriteLine(listStudent.Count);
                }
            }
        }
    }
}
