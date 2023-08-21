using student_management_admin.DAO;
using student_management_admin.Helper;
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
    public partial class Main_Form_Admin : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();
        Form_Insert_User form_Insert;
        Form_Insert_Subject form_Insert_Subject;
        String txtSelect { get; set; }

        public Student student { get; set; }
        public Teacher teacher { get; set; }

        public Main_Form_Admin(string nameAdmin)
        {
            InitializeComponent();
            lblName.Text = nameAdmin;

            txtSelect = "student";
            
            lblTitle.Text = "Danh sách sinh viên";
            dtgrvData.DataSource = db.Students
                .Select(s => new
                {
                    Mã_SV = s.code,
                    Tên = s.name,
                    Giới_tính = s.gender ? "Nam" : "Nữ",
                    Tài_khoản = s.account,
                    Email = s.email,
                    Trạng_thái = s.active
                });
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form_Admin login_Form = new Login_Form_Admin();
            login_Form.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            txtSelect = "student";
            lblTitle.Text = "Danh sách sinh viên";
            dtgrvData.DataSource = db.Students
                .Select(s => new
                {
                    Mã_SV = s.code,
                    Tên = s.name,
                    Giới_tính = s.gender ? "Nam" : "Nữ",
                    Tài_khoản = s.account,
                    Email = s.email,
                    Trạng_thái = s.active
                });
        }

        private void btnTeacher_Click(object sender, EventArgs e)
        {
            txtSelect = "teacher";
            lblTitle.Text = "Danh sách giảng viên";
            dtgrvData.DataSource = db.Teachers
                .Select(s => new
                {
                    Mã_GV = s.code,
                    Tên = s.name,
                    Giới_tính = s.gender ? "Nam" : "Nữ",
                    Tài_Khoản = s.account,
                    Email = s.email,
                    Trạng_thái = s.active
                });
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtSelect.Equals("subject"))
            {
                form_Insert_Subject = new Form_Insert_Subject("", false, this);
                form_Insert_Subject.ShowDialog();
            } else if (txtSelect.Equals("student") || txtSelect.Equals("teacher"))
            {
                form_Insert = new Form_Insert_User(txtSelect, "", false, this);
                form_Insert.ShowDialog();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text.Trim().ToLower();
            switch (txtSelect)
            {
                case "student":
                    getDataStudent(search);
                    break;
                case "teacher":
                    getDataTeacher(search);
                    break;
                case "subject":
                    getDataSubject(search);
                    break;
            }
        }

        private void getDataStudent(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                dtgrvData.DataSource = db.Students
                        .Select(s => new
                        {
                            Mã_SV = s.code,
                            Tên = s.name,
                            Giới_tính = s.gender ? "Nam" : "Nữ",
                            Tài_khoản = s.account,
                            Email = s.email,
                            Trạng_thái = s.active
                        })
                        .Where(s => s.Mã_SV.Contains(search) ||  s.Tên.ToLower().Contains(search) || s.Email.ToLower().Contains(search));
            }
            else
            {
                dtgrvData.DataSource = db.Students
                        .Select(s => new
                        {
                            Mã_SV = s.code,
                            Tên = s.name,
                            Giới_tính = s.gender ? "Nam" : "Nữ",
                            Tài_khoản = s.account,
                            Email = s.email,
                            Trạng_thái = s.active
                        });
            }
        }

        private void getDataTeacher(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                dtgrvData.DataSource = db.Teachers
                        .Select(s => new
                        {
                            Mã_GV = s.code,
                            Tên = s.name,
                            Giới_tính = s.gender ? "Nam" : "Nữ",
                            Tài_Khoản = s.account,
                            Email = s.email,
                            Trạng_thái = s.active
                        })
                        .Where(s => s.Tên.ToLower().Contains(search) || s.Email.ToLower().Contains(search));
            }
            else
            {
                dtgrvData.DataSource = db.Teachers
                        .Select(s => new
                        {
                            Mã_GV = s.code,
                            Tên = s.name,
                            Giới_tính = s.gender ? "Nam" : "Nữ",
                            Tài_Khoản = s.account,
                            Email = s.email,
                            Trạng_thái = s.active
                        });
            }
        }

        private void getDataSubject(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                dtgrvData.DataSource = db.Subjects
                    .Select(s => new
                    {
                        Mã_Môn = s.code,
                        Tên = s.name,
                        Mô_Tả = s.descript
                    })
                    .Where(s => s.Mã_Môn.Contains(search) || s.Tên.Contains(search));
            } else
            {
                dtgrvData.DataSource = db.Subjects
                    .Select(s => new
                    {
                        Mã_Môn = s.code,
                        Tên = s.name,
                        Mô_Tả = s.descript
                    });
            }
        }

        public void DataGridViewRefresh()
        {
            switch(txtSelect)
            {
                case "student":
                    dtgrvData.DataSource = db.Students
                            .Select(s => new
                            {
                                Mã_SV = s.code,
                                Tên = s.name,
                                Giới_tính = s.gender ? "Nam" : "Nữ",
                                Tài_khoản = s.account,
                                Email = s.email,
                                Trạng_thái = s.active
                            });
                    dtgrvData.Refresh();
                    break;
                case "teacher":
                    dtgrvData.DataSource = db.Teachers
                            .Select(s => new
                            {
                                Mã_GV = s.code,
                                Tên = s.name,
                                Giới_tính = s.gender ? "Nam" : "Nữ",
                                Tài_Khoản = s.account,
                                Email = s.email,
                                Trạng_thái = s.active
                            });
                    break;
                case "subject":
                    dtgrvData.DataSource = db.Subjects
                        .Select(s => new
                        {
                            Mã_Môn = s.code,
                            Tên = s.name,
                            Mô_Tả = s.descript
                        });
                    break;
            }
        }

        private void dtgrvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string code = dtgrvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (txtSelect.Equals("student") || txtSelect.Equals("teacher"))
                {
                    form_Insert = new Form_Insert_User(txtSelect, code, true, this);
                    form_Insert.ShowDialog();
                } else if (txtSelect.Equals("subject"))
                {
                    form_Insert_Subject = new Form_Insert_Subject(code, true, this);
                    form_Insert_Subject.ShowDialog();
                }
            }
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            txtSelect = "subject";
            lblTitle.Text = "Danh sách môn học";
            dtgrvData.DataSource = db.Subjects
                .Select(s => new
                {
                    Mã_Môn = s.code,
                    Tên = s.name,
                    Mô_Tả = s.descript
                });
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            dtgrvData.Visible = false;
        }
    }
}
