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
        Form_Insert_Class form_Insert_Class;
        String txtSelect { get; set; }

        public Student student { get; set; }
        public Teacher teacher { get; set; }

        public Main_Form_Admin(string nameAdmin)
        {
            InitializeComponent();

            lblName.Text = nameAdmin;

            txtSelect = "student";
            
            lblTitle.Text = "Danh sách sinh viên";
            hideLocation();
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
            hideLocation();
            clearDataGrip();
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
            hideLocation();
            clearDataGrip();
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
            } else if (txtSelect.Equals("class"))
            {
                form_Insert_Class = new Form_Insert_Class(null, this);
                form_Insert_Class.ShowDialog();
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
            clearDataGrip();
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
            hideLocation();
            clearDataGrip();
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
            makeSchedule();
            dtgvBuilding.DataSource = db.Buildings.Select(b => new
            {
                Mã_Toà_Nhà = b.id,
                Tên_Toà_Nhà = b.name,
            });
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            txtSelect = "class";
            lblTitle.Text = "Danh sách lớp học";
            hideLocation();
            clearDataGrip();
            dtgrvData.DataSource = from cls in db.Classes
                        join classTeacher in db.Class_Teachers on cls.id equals classTeacher.class_id
                        join teacher in db.Teachers on classTeacher.teacher_code equals teacher.code
                        join classStudent in db.Class_Students on cls.id equals classStudent.class_id into studentGroup
                        select new
                        {
                            Mã_Lớp = cls.id,
                            Tên_Lớp = cls.name,
                            Mã_GV = teacher.code,
                            Tên_GV = teacher.name,
                            SL_SV = studentGroup.Count()
                        };
        }

        private void makeSchedule()
        {
            dtgrvData.DataSource = null;
            dtgrvData.ColumnCount = 7;
            dtgrvData.RowCount = 4;

            dtgrvData.Columns[0].HeaderText = "Thứ 2";
            dtgrvData.Columns[1].HeaderText = "Thứ 3";
            dtgrvData.Columns[2].HeaderText = "Thứ 4";
            dtgrvData.Columns[3].HeaderText = "Thứ 5";
            dtgrvData.Columns[4].HeaderText = "Thứ 6";
            dtgrvData.Columns[5].HeaderText = "Thứ 7";
            dtgrvData.Columns[6].HeaderText = "Chủ nhật";

            dtgrvData.Rows[0].HeaderCell.Value = "Ca 1";
            dtgrvData.Rows[1].HeaderCell.Value = "Ca 2";
            dtgrvData.Rows[2].HeaderCell.Value = "Ca 3";
            dtgrvData.Rows[3].HeaderCell.Value = "Ca 4";
        }

        private void clearDataGrip()
        {
            dtgrvData.DataSource = null;
            dtgrvData.Columns.Clear();
            dtgrvData.Rows.Clear();
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            showLocation();
        }

        private void showLocation()
        {
            pnActivity.Visible = false;
            pnLocation.Visible = true;
        }

        private void hideLocation()
        {
            pnActivity.Visible = true;
            pnLocation.Visible = false;
        }

        private void dtgvBuilding_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                int id_buiding = Convert.ToInt32(dtgvBuilding.Rows[e.RowIndex].Cells[0].Value);
                //btnAddClassroom.Enabled = true;
                dtgvClassroom.DataSource = from l in db.Locations
                                           join b in db.Buildings on l.building_id equals b.id
                                           join c in db.Classrooms on l.classroom_id equals c.id
                                           where l.building_id == id_buiding
                                           select new
                                           {
                                               Mã_Phòng_Học = c.id,
                                               Tên_Phòng_Học = c.name
                                           };
            } else
            {
            }
        }

        private void Main_Form_Admin_Load(object sender, EventArgs e)
        {
        }

        private void btnAddBuilding_Click(object sender, EventArgs e)
        {
            txtSelect = "building";
            //form_Insert_Location = new Form_Insert_Location(0, false, txtSelect, this);
            //form_Insert_Location.ShowDialog();
        }

        private void btnAddClassroom_Click(object sender, EventArgs e)
        {
            txtSelect = "classroom";
            //form_Insert_Location = new Form_Insert_Location(0, false, txtSelect, this);
            //form_Insert_Location.ShowDialog();
        }

        private void dtgvBuilding_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtSelect = "building";
                int id_buiding = Convert.ToInt32(dtgvBuilding.Rows[e.RowIndex].Cells[0].Value);
                //form_Insert_Location = new Form_Insert_Location(id_buiding, true, txtSelect, this);
                //form_Insert_Location.ShowDialog();
            }
        }

        private void dtgvClassroom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtSelect = "classroom";
                int id_class = Convert.ToInt32(dtgvBuilding.Rows[e.RowIndex].Cells[0].Value);
                //form_Insert_Location = new Form_Insert_Location(id_class, true, txtSelect, this);
                //form_Insert_Location.ShowDialog();
            }
        }
    }
}
