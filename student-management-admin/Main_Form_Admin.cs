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
        Form_Insert_Location form_Insert_Location;
        String txtSelect { get; set; }
        string txtSelectBuilding { get; set; }

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
                form_Insert_Class = new Form_Insert_Class(null, false, this);
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
                case "class":
                    dtgrvData.DataSource = from cls in db.Classes
                                           join classStudent in db.Class_Students on cls.id equals classStudent.class_id into studentGroup
                                           select new
                                           {
                                               Mã_Lớp = cls.id,
                                               Tên_Lớp = cls.name,
                                               SL_SV = studentGroup.Count()
                                           };
                    break;
                case "building":
                    makeDataLocation("building");
                    break;
                case "classroom":
                    makeDataLocation("classroom");
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
                } else if (txtSelect.Equals("class"))
                {
                    form_Insert_Class = new Form_Insert_Class(code, true, this);
                    form_Insert_Class.ShowDialog();
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
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            txtSelect = "class";
            lblTitle.Text = "Danh sách lớp học";
            hideLocation();
            clearDataGrip();
            dtgrvData.DataSource = from cls in db.Classes
                        join classStudent in db.Class_Students on cls.id equals classStudent.class_id into studentGroup
                        select new
                        {
                            Mã_Lớp = cls.id,
                            Tên_Lớp = cls.name,
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
            makeDataLocation("building");

        }

        private void showLocation()
        {
            pnActivity.Hide();
            pnLocation.Show();
            pnLocation.BringToFront();
        }

        private void hideLocation()
        {
            pnActivity.Show();
            pnLocation.Hide();
            pnActivity.BringToFront();
        }

        private void dtgvBuilding_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSelect = "building";
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string id_buiding = dtgvBuilding.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSelectBuilding = id_buiding;
                btnAddClass.Enabled = true;
                makeDataLocation("classroom");
            }
        }

        private void makeDataLocation(string select)
        {
            DataTable table = new DataTable();
            table.DefaultView.AllowDelete = false;
            table.DefaultView.AllowNew = false;
            table.DefaultView.AllowEdit = false;
            switch (select)
            {
                case "building":
                    table.Columns.Add("Mã toà nhà", typeof(string));
                    table.Columns.Add("Tên toà nhà", typeof(string));

                    var queryBuild = db.Buildings;
                    foreach (var build in queryBuild)
                    {
                        table.Rows.Add(build.id, build.name);
                    }

                    dtgvBuilding.DataSource = table;
                    break;
                case "classroom":
                    table.Columns.Add("Mã phòng học", typeof(string));
                    table.Columns.Add("Tên phòng học", typeof(string));

                    var queryClass = from l in db.Locations
                                     join b in db.Buildings on l.building_id equals b.id
                                     join c in db.Classrooms on l.classroom_id equals c.id
                                     where l.building_id == txtSelectBuilding
                                     select new 
                                     { 
                                         id = c.id,
                                         name = c.name
                                     };
                    foreach (var classroom in queryClass)
                    {
                        table.Rows.Add(classroom.id, classroom.name);
                    }

                    dtgvClassroom.DataSource = table;
                    break;
            }


        }

        private void Table_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            string id, name;
            if (e.Action == DataRowAction.Add)
            {
                switch (txtSelect)
                {
                    case "building":
                        id = e.Row["Mã toà nhà"].ToString();
                        name = e.Row["Tên toà nhà"].ToString();
                        var resultBuild = db.Buildings.SingleOrDefault(b => b.id.Equals(id));
                        if (resultBuild == null)
                        {
                            Building building = new Building();
                            building.id = id;
                            building.name = name;
                            db.Buildings.InsertOnSubmit(building);
                        } else
                        {
                            MessageBox.Show("Toà nhà đã tồn tại");
                        }

                        break;
                    case "classroom":
                        id = e.Row["Mã phòng học"].ToString();
                        name = e.Row["Tên phòng học"].ToString();
                        var resultClass = db.Locations.SingleOrDefault(l => l.building_id.Equals(txtSelectBuilding) && l.classroom_id.Equals(txtSelectBuilding + "_" + id));
                        if (resultClass == null)
                        {
                            Classroom classroom = new Classroom();
                            classroom.id = txtSelectBuilding + "_" + id;
                            classroom.name = name;
                            db.Classrooms.InsertOnSubmit(classroom);
                        } else
                        {
                            MessageBox.Show("Phòng học trong toà nhà " + txtSelectBuilding + " đã tồn tại");
                        }
                        break;
                }  
            } else if (e.Action == DataRowAction.Change)
            {
                switch (txtSelect)
                {
                    case "building":
                        break;
                    case "classroom":
                        break;
                }
            }
            db.SubmitChanges();
            
        }

        private void Main_Form_Admin_Load(object sender, EventArgs e)
        {
            btnAddClass.Enabled = false;
        }

        private void dtgvClassroom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSelect = "classroom";
        }

        private void btnAddBuild_Click(object sender, EventArgs e)
        {
            txtSelect = "building";
            form_Insert_Location = new Form_Insert_Location(null, null, false, txtSelect, this);
            form_Insert_Location.ShowDialog();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            txtSelect = "classroom";
            form_Insert_Location = new Form_Insert_Location(txtSelectBuilding, null, false, txtSelect, this);
            form_Insert_Location.ShowDialog();
        }

        private void dtgvBuilding_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string id = dtgvBuilding.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSelect = "building";
                form_Insert_Location = new Form_Insert_Location(null, id, true, txtSelect, this);
                form_Insert_Location.ShowDialog();
            }
        }

        private void dtgvClassroom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string id = dtgvClassroom.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtSelect = "classroom";
                form_Insert_Location = new Form_Insert_Location(txtSelectBuilding, id, true, txtSelect, this);
                form_Insert_Location.ShowDialog();
            }
        }
    }
}
