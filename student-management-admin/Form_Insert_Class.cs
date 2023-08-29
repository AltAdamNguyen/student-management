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
        Main_Form_Admin main_Form;

        List<string> listStudent = new List<string>();
        string search { get; set; }
        bool isUpdate { get; set; }

        public Form_Insert_Class(string search, bool isUpdate, Main_Form_Admin main_Form)
        {
            InitializeComponent();
            this.search = search;
            this.isUpdate = isUpdate;
            this.main_Form = main_Form;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = txtCode.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(id))
            {
                lblValidateCode.Text = "Mã lớp học là bắt buộc";
            }
            else
            {
                lblValidateCode.Text = "";
            }

            if (string.IsNullOrEmpty(name))
            {
                lblValidateName.Text = "Tên lớp học là bắt buộc";
            }
            else
            {
                lblValidateName.Text = "";
            }


            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name))
            {
                if (isUpdate)
                {
                    Class @class = db.Classes.Single(c => c.id.Equals(id));
                    @class.name = name;

                    var queryCS = db.Class_Students.Where(cs => cs.class_id.Equals(id));
                    db.Class_Students.DeleteAllOnSubmit(queryCS);

                    List<Class_Student> class_Students = listStudent.Select(s => new Class_Student
                    {
                        id = id + "_" + s,
                        class_id = id,
                        student_code = s
                    }).ToList();

                    db.Class_Students.InsertAllOnSubmit(class_Students);
                }
                else
                {
                    var query = db.Classes.SingleOrDefault(c => c.id.Equals(id));
                    if (query == null)
                    {
                        Class @class = new Class();
                        @class.id = id;
                        @class.name = name;

                        db.Classes.InsertOnSubmit(@class);

                        List<Class_Student> class_Students = listStudent.Select(s => new Class_Student
                        {
                            id = id + "_" + s,
                            class_id = id,
                            student_code = s
                        }).ToList();

                        db.Class_Students.InsertAllOnSubmit(class_Students);
                    }
                    else
                    {
                        MessageBox.Show("Lớp học đã tồn tại.");
                    }
                }

                string desMes = "Thêm thành công !!!";

                if (isUpdate)
                {
                    desMes = "Cập nhật thành công !!!";
                }

                try
                {
                    db.SubmitChanges();

                    DialogResult dialogResult = MessageBox.Show(desMes, "", MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            getDataStudent(search);
        }

        private void Form_Insert_Class_Load(object sender, EventArgs e)
        {
            getDataStudent(search);
            if (isUpdate)
            {
                btnAddStudent.Visible = true;
                txtCode.ReadOnly = true;
                lblTitle.Text = "Cập nhật thông tin lớp học";
                btnAdd.Text = "Cập nhật";

                Class @class = db.Classes.Single(c => c.id.Equals(this.search));
                txtCode.Text = @class.id;
                txtName.Text = @class.name;

                var query = db.Class_Students.Where(cs => cs.class_id.Equals(this.search));
                foreach (var cs in query)
                {
                    listStudent.Add(cs.student_code);
                }

                lblStudentCount.Text = "Số lượng sinh viên: " + listStudent.Count;
            }

        }

        private void getDataStudent(string search)
        {

            DataTable table = new DataTable();
            table.DefaultView.AllowNew = false;
            table.DefaultView.AllowDelete = false;

            table.Columns.Add("Chọn", typeof(bool));
            table.Columns.Add("Mã SV", typeof(string));
            table.Columns.Add("Tên SV", typeof(string));

            table.Columns[1].ReadOnly = true;
            table.Columns[2].ReadOnly = true;

            if (isUpdate)
            {

                var query = from student in db.Students
                            join classStudent in db.Class_Students
                            on student.code equals classStudent.student_code
                            where classStudent.class_id == this.search
                            select new
                            {
                                student.code,
                                student.name
                            };
                foreach (var student in query)
                {
                    table.Rows.Add(true, student.code, student.name);
                }
            }
            else
            {
                var query = from student in db.Students
                            join classStudent in db.Class_Students
                            on student.code equals classStudent.student_code into gj
                            from subClassStudent in gj.DefaultIfEmpty()
                            where subClassStudent == null
                            select new
                            {
                                student.code,
                                student.name
                            };

                foreach (var student in query)
                {
                    bool isSelect = listStudent.Contains(student.code);
                    table.Rows.Add(isSelect, student.code, student.name);
                }
            }

            dtgvStudent.DataSource = table;
        }

        private void dtgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                {
                    bool selectValue = Convert.ToBoolean(dtgvStudent.Rows[e.RowIndex].Cells[0].Value);
                    string code = dtgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                    if (!selectValue)
                    {
                        dtgvStudent.Rows[e.RowIndex].Cells[0].Value = true;
                        listStudent.Add(code);
                    }
                    else
                    {
                        dtgvStudent.Rows[e.RowIndex].Cells[0].Value = false;
                        listStudent.Remove(code);
                    }
                    dtgvStudent.Refresh();
                    lblStudentCount.Text = "Số lượng sinh viên: " + listStudent.Count;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Insert_Class_FormClosed(object sender, FormClosedEventArgs e)
        {
            main_Form.DataGridViewRefresh();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {

        }
    }
}
