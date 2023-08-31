using student_management.Model;
using student_management.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace student_management
{
    public partial class Main_Form_Teacher : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        Form_Attendance form_Attendance;
        Teacher teacher { get; set; }

        public Main_Form_Teacher(Teacher teacher)
        {
            InitializeComponent();
            this.teacher = teacher;
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {

        }

        private void Main_Form_Teacher_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Lịch giảng của " + teacher.account + " (" + teacher.name + ")";
            lblName.Text = teacher.name;
            makeYear();
            makeDateWeekOfYear();
            makeSchedule();
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

            var teacherSchedule = db.Schedules
                .Where(s => s.teacher_code.Equals(teacher.code) && s.date_time >= startDate && s.date_time <= endDate)
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

        private void dtgrvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var value = dtgrvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value != null)
                {
                    string slot = dtgrvData.Rows[e.RowIndex].HeaderCell.Value.ToString().Split(' ')[1];
                    string date = dtgrvData.Columns[e.ColumnIndex].HeaderText;
                    form_Attendance = new Form_Attendance(date + "_" + slot);
                    form_Attendance.ShowDialog();
                }
            }
        }
    }
}
