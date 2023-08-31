using student_management_admin.DAO;
using student_management_admin.Helper;
using student_management_admin.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        Form_Insert_Schedule form_Insert_Schedule;

        String txtSelect { get; set; }
        string txtSelectBuilding { get; set; }

        public Student student { get; set; }
        public Teacher teacher { get; set; }

        public Main_Form_Admin(string nameAdmin)
        {
            InitializeComponent();

            lblName.Text = nameAdmin;          
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
            txtSearch.Text = "";
            lblTitle.Text = "Danh sách sinh viên";
            showLocation(false);
            showCBTeacher(false);
            showDateTime(false);
            clearDataGrip();
            var query = db.Students
                .Select(s => new
                {
                    Mã_SV = s.code,
                    Tên = s.name,
                    Giới_tính = s.gender ? "Nam" : "Nữ",
                    Tài_khoản = s.account,
                    Email = s.email,
                    Trạng_thái = s.active
                });
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
            txtSearch.Text = "";
            lblTitle.Text = "Danh sách giảng viên";
            showLocation(false);
            showCBTeacher(false);
            showDateTime(false);
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
            } else if (txtSelect.Equals("schedule"))
            {
                form_Insert_Schedule = new Form_Insert_Schedule();
                form_Insert_Schedule.ShowDialog();
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
                            Mô_Tả = s.descript,
                            Số_Tuần = s.duration
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
                if (!txtSelect.Equals("schedule"))
                {
                    string code = dtgrvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (txtSelect.Equals("student") || txtSelect.Equals("teacher"))
                    {
                        form_Insert = new Form_Insert_User(txtSelect, code, true, this);
                        form_Insert.ShowDialog();
                    }
                    else if (txtSelect.Equals("subject"))
                    {
                        form_Insert_Subject = new Form_Insert_Subject(code, true, this);
                        form_Insert_Subject.ShowDialog();
                    }
                    else if (txtSelect.Equals("class"))
                    {
                        form_Insert_Class = new Form_Insert_Class(code, true, this);
                        form_Insert_Class.ShowDialog();
                    }
                }
            }
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            txtSelect = "subject";
            txtSearch.Text = "";
            lblTitle.Text = "Danh sách môn học";
            showLocation(false);
            showCBTeacher(false);
            showDateTime(false);
            clearDataGrip();
            dtgrvData.DataSource = db.Subjects
                .Select(s => new
                {
                    Mã_Môn = s.code,
                    Tên = s.name,
                    Mô_Tả = s.descript,
                    Số_Tuần = s.duration
                });
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            txtSelect = "schedule";
            showLocation(false);
            showCBTeacher(true);
            showDateTime(true);

            cbTeacher.DataSource = db.Teachers
                .Where(t => t.active == true)
                .Select(t => new
                {
                    Display = t.name + " (" + t.account + ")",
                    Value = t.code
                });
            cbTeacher.DisplayMember = "Display";
            cbTeacher.ValueMember = "Value";

            makeSchedule();
        }

        private void btnClass_Click(object sender, EventArgs e)
        {
            txtSelect = "class";
            txtSearch.Text = "";
            lblTitle.Text = "Danh sách lớp học";
            showLocation(false);
            showCBTeacher(false);
            showDateTime(false);
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

            DateTime startDate;
            if (cbDateOfWeek.SelectedValue != null)
            {
                try
                {
                    startDate = (DateTime)cbDateOfWeek.SelectedValue;
                }
                catch (Exception _)
                {
                    WeekItem week = (WeekItem)cbDateOfWeek.SelectedValue;
                    startDate = week.startDate;
                }
            } else
            {
                DateTime selectedDate = DateTime.Now;
                if ((int)selectedDate.DayOfWeek != 1)
                {
                    startDate = selectedDate;
                }
                else
                {
                    startDate = selectedDate.AddDays(-(int)selectedDate.DayOfWeek);
                }
            }

            DateTime endDate = startDate.AddDays(6);

            dtgrvData.Columns.Clear();
            dtgrvData.Rows.Clear();
            dtgrvData.AutoGenerateColumns = false;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dtgrvData.Columns.Add(date.ToShortDateString(), date.ToShortDateString());
            }

            var teacherSchedule = db.Schedules
                .Where(s => s.teacher_code.Equals(cbTeacher.SelectedValue) && s.date_time >= startDate && s.date_time <= endDate)
                .ToList();

            string[] slots = { "Ca 1", "Ca 2", "Ca 3", "Ca 4" };
            dtgrvData.RowCount = 4;

            foreach (var slot in slots)
            {
                int slotss = Array.IndexOf(slots, slot) + 1;
                dtgrvData.Rows[slotss - 1].HeaderCell.Value = slot;

                foreach (DateTime date in Enumerable.Range(0, 7).Select(i => startDate.AddDays(i)))
                {
                    int dayOfWeekIndex = (int)date.DayOfWeek - 1; 
                    var schedule = teacherSchedule.FirstOrDefault(s => s.date_time.Date == date.Date && s.slot == slotss);
                    if (schedule != null)
                        dtgrvData.Rows[slotss - 1].Cells[dayOfWeekIndex].Value = schedule.subject_code + "- tại " + schedule.location_id;
                }
            }
        }

        private void clearDataGrip()
        {
            dtgrvData.DataSource = null;
            dtgrvData.Columns.Clear();
            dtgrvData.Rows.Clear();
            dtgrvData.AutoGenerateColumns = true;
        }

        private void showDateTime(bool isShow)
        {
            if (isShow)
            {
                cbYear.Visible = true;
                cbDateOfWeek.Visible = true;
            }
            else
            {
                cbYear.Visible = false;
                cbDateOfWeek.Visible = false;
            }
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            showLocation(true);
            showDateTime(false);
            makeDataLocation("building");

        }

        private void showLocation(bool isShow)
        {
            if (isShow)
            {
                pnActivity.Hide();
                pnLocation.Show();
                pnLocation.BringToFront();
            }
            else
            {
                pnActivity.Show();
                pnLocation.Hide();
                pnActivity.BringToFront();
            }
        }

        private void showCBTeacher(bool isShow)
        {
            if (isShow)
            {
                txtSearch.Visible = false;
                btnSearch.Visible = false;
                lblTitleTeacher.Visible = true;
                cbTeacher.Visible = true;
            }
            else
            {
                txtSearch.Visible = true;
                btnSearch.Visible = true;
                lblTitleTeacher.Visible = false;
                cbTeacher.Visible = false;
            }
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

        private void makeDateWeekOfYear()
        {
            DateTime currentDate = DateTime.Now;
            int selectYear = Convert.ToInt32(cbYear.SelectedItem);  
            int currentWeek;
            if (selectYear == currentDate.Year)
            {
                currentWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(currentDate, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
            else
            {
                currentWeek = 1;
            }
            List<WeekItem> weekItems = new List<WeekItem>();

            for (int week = 1; week <= 52; week++)
            {
                DateTime startDate = getStartDateOfWeek(selectYear, week);
                DateTime endDate = startDate.AddDays(6);

                string weekText = $"Tuần {week} ({startDate.ToString("dd/MM/yyyy")} - {endDate.ToString("dd/MM/yyyy")})";
                weekItems.Add(new WeekItem
                {
                    weekText = weekText,
                    startDate = startDate
                });
            }

            cbDateOfWeek.DataSource = weekItems;
            cbDateOfWeek.DisplayMember = "weekText";
            cbDateOfWeek.ValueMember = "startDate";
            cbDateOfWeek.SelectedIndex = currentWeek - 1;
        }

        private void makeYear()
        {
            int currentYear = DateTime.Now.Year;
            for (int year = currentYear - 10; year <= currentYear + 10; year++)
            {
                cbYear.Items.Add(year.ToString());
            }

            cbYear.SelectedItem = currentYear.ToString();
        }

        private DateTime getStartDateOfWeek(int year, int weekNumber)
        {
            int getYear;
            if (year != 0)
                getYear = year;
            else
                getYear = DateTime.Now.Year;
            DateTime jan1 = new DateTime(getYear, 1, 1);
            int daysOffset = (int)DayOfWeek.Monday - (int)jan1.DayOfWeek + 7;

            DateTime firstMonday = jan1.AddDays(daysOffset);
            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(firstMonday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                weekNumber -= 1;
            }

            return firstMonday.AddDays(7 * (weekNumber - 1));
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

        private void Main_Form_Admin_Load(object sender, EventArgs e)
        {
            btnAddClass.Enabled = false;
            makeYear();
            makeDateWeekOfYear();
            txtSelect = "student";

            lblTitle.Text = "Danh sách sinh viên";
            showLocation(false);
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

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbYear.IsHandleCreated && cbYear.Focused)
            {
                makeDateWeekOfYear();
                makeSchedule();
            }
        }

        private void cbDateOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDateOfWeek.IsHandleCreated && cbDateOfWeek.Focused)
            {
                makeSchedule();
            }
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeacher.IsHandleCreated && cbTeacher.Focused)
                makeSchedule();
        }
    }
}
