using student_management.DAO;
using student_management.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace student_management
{
    public partial class Main_Form_Student : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
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
            lblTitle.Text = "Lịch học của " + student.account + " (" + student.name + ")";
            lblName.Text = student.name;
            dtgrvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            makeYear();
            makeDateWeekOfYear();
            makeSchedule();
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
            }
            else
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
                dtgrvData.Columns.Add(date.ToString("dd/MM/yyyy"), date.ToString("dd/MM/yyyy"));
            }

            var studentSchedule = from schedule in db.Schedules
                                  join attended in db.Attendances on schedule.id equals attended.schedule_id
                                  where attended.student_code == student.code && schedule.date_time >= startDate && schedule.date_time <= endDate
                                  select new
                                  {
                                      schedule.id,
                                      schedule.location_id,
                                      schedule.date_time,
                                      schedule.class_id,
                                      schedule.subject_code,
                                      schedule.slot,
                                      attended.student_code,
                                      attended.attended,
                                  };
                                  
            string[] slots = { "Ca 1", "Ca 2", "Ca 3", "Ca 4" };
            dtgrvData.RowCount = 4;
            foreach (var slot in slots)
            {
                int slotss = Array.IndexOf(slots, slot) + 1;
                DataGridViewRow headerRow = dtgrvData.Rows[slotss - 1];
                headerRow.HeaderCell.Value = slot;
                foreach (DateTime date in Enumerable.Range(0, 7).Select(i => startDate.AddDays(i)))
                {
                    int dayOfWeekIndex = (int)date.DayOfWeek - 1;
                    var schedule = studentSchedule.FirstOrDefault(s => s.date_time.Date == date.Date && s.slot == slotss);
                    if (schedule != null)
                        dtgrvData.Rows[slotss - 1].Cells[dayOfWeekIndex].Value = schedule.subject_code + "- tại " + schedule.location_id + "\n(" + isAttended(schedule.attended) + ")";
                }
            }
        }

        private string isAttended(int attended)
        {
            switch (attended)
            {
                case 0:
                    return "Chưa tham gia";
                case 1:
                    return "Đã tham gia";
                default:
                    return "Chưa học";
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

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeDateWeekOfYear();
            makeSchedule();
        }

        private void cbDateOfWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            makeSchedule();
        }
    }
}
