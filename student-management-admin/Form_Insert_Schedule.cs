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
    public partial class Form_Insert_Schedule : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();

        private List<KeyValuePair<DateTime, int>> selectedSlots = new List<KeyValuePair<DateTime, int>>();

        public Form_Insert_Schedule()
        {
            InitializeComponent();
        }

        private void Form_Insert_Schedule_Load(object sender, EventArgs e)
        {
            var queryTeacher = db.Teachers
                .Where(t => t.active == true)
                .Select(t => new
                {
                    Display = t.name + " (" + t.account + ")",
                    Value = t.code
                });

            cbTeacher.DataSource = queryTeacher;
            cbTeacher.DisplayMember = "Display";
            cbTeacher.ValueMember = "Value";
            cbTeacher.SelectedIndex = 0;

            cbClass.DataSource = db.Classes;
            cbClass.DisplayMember = "name";
            cbClass.ValueMember = "id";
            cbClass.SelectedIndex = 0;

            cbSubject.DataSource = db.Subjects
                .Select(s => new
                {
                    Display = s.name + " (" + s.code + ")",
                    Value = s.code
                });
            cbSubject.DisplayMember = "Display";
            cbSubject.ValueMember = "Value";
            cbSubject.SelectedIndex = 0;

            cbBuilding.DataSource = db.Buildings;
            cbBuilding.DisplayMember = "name";
            cbBuilding.ValueMember = "id";
            cbBuilding.SelectedIndex = 0;

            changeClassRoom();
            cbClassroom.SelectedIndex = 0;

            panel2.AutoScroll = true;

            generateSlotCheckboxes(getavailableSlots());
        }

        private void cbTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeacher.SelectedValue != null 
                && cbSubject.SelectedValue != null 
                && cbClass.SelectedValue != null
                && cbBuilding.SelectedValue != null
                && cbClassroom.SelectedValue != null)
            {
                selectedSlots.Clear();
                panel2.Controls.Clear();
                generateSlotCheckboxes(getavailableSlots());
            }
        }

        private void cbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeacher.SelectedValue != null
                && cbSubject.SelectedValue != null
                && cbClass.SelectedValue != null
                && cbBuilding.SelectedValue != null
                && cbClassroom.SelectedValue != null)
            {
                selectedSlots.Clear();
                panel2.Controls.Clear();
                generateSlotCheckboxes(getavailableSlots());
            }
        }

        private void cbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTeacher.SelectedValue != null
                && cbSubject.SelectedValue != null
                && cbClass.SelectedValue != null
                && cbBuilding.SelectedValue != null
                && cbClassroom.SelectedValue != null)
            {
                selectedSlots.Clear();
                panel2.Controls.Clear();
                generateSlotCheckboxes(getavailableSlots());
            }
        }

        private List<KeyValuePair<DateTime, List<int>>> getavailableSlots()
        {
            string excludedSubjectCode = cbSubject.SelectedValue.ToString();
            string excludedTeacherCode = cbTeacher.SelectedValue.ToString();
            string excludedClassId = cbClass.SelectedValue.ToString();

            string excludedBuildId = cbBuilding.SelectedValue.ToString();
            string exClidedClassroomId = cbClassroom.SelectedValue.ToString();

            Location excludedLocation = db.Locations.Single(l => l.building_id.Equals(excludedBuildId) && l.classroom_id.Equals(exClidedClassroomId));

            DateTime currentDate = DateTime.Now.Date;
            DateTime nextMonday = currentDate.AddDays((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek).AddDays(7);

            List<KeyValuePair<DateTime, List<int>>> result = new List<KeyValuePair<DateTime, List<int>>>();

            for (int k = 0; k < 5; k++)
            {
                DateTime slot = nextMonday.AddDays(k);
                List<int> availableSlots = new List<int>();
                for (int i = 0; i < 4; i++)
                {
                    bool isSlotAvailable = !db.Schedules.Any(schedule =>
                        schedule.date_time.Date.Equals(slot.Date)
                        && schedule.slot == i + 1
                        && !schedule.date_time.DayOfWeek.Equals(DayOfWeek.Saturday)
                        && !schedule.date_time.DayOfWeek.Equals(DayOfWeek.Sunday)
                        && schedule.class_id == excludedClassId
                        && schedule.subject_code == excludedSubjectCode
                        && schedule.teacher_code == excludedTeacherCode
                        && schedule.location_id == excludedLocation.id
                    );

                    if (isSlotAvailable)
                    {
                        availableSlots.Add(i);
                    }
                }

                KeyValuePair<DateTime, List<int>> slotAvai = new KeyValuePair<DateTime, List<int>>(slot, availableSlots);
                result.Add(slotAvai);
            }

            return result;
        }

        private void generateSlotCheckboxes(List<KeyValuePair<DateTime, List<int>>> availableSlots)
        {
            const int checkboxHeight = 20;
            const int margin = 15;

            int topOffset = margin;

            foreach (var slot in availableSlots)
            {
                GroupBox groupBox = new GroupBox();
                groupBox.Text = Function.convertToDateOfWeek(slot.Key);
                groupBox.AutoSize = true;
                groupBox.Top = topOffset;

                foreach (var value in slot.Value)
                {
                    CheckBox checkBox = new CheckBox();
                    checkBox.Text = $"Ca {value + 1}";
                    checkBox.Tag = new KeyValuePair<DateTime, int>(slot.Key, value +1);
                    checkBox.AutoSize = true;
                    checkBox.Height = checkboxHeight;
                    checkBox.Top = margin + (groupBox.Controls.Count * (checkboxHeight + margin));
                    checkBox.Left = margin;
                    checkBox.CheckedChanged += SlotCheckbox_CheckedChanged;

                    groupBox.Controls.Add(checkBox);
                }

                panel2.Controls.Add(groupBox);
                topOffset += groupBox.Height + margin;
            }
        }

        private void SlotCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            KeyValuePair<DateTime, int> slot = (KeyValuePair<DateTime, int>)checkBox.Tag;

            if (checkBox.Checked)
            {
                selectedSlots.Add(slot);
            }
            else
            {
                selectedSlots.Remove(slot);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string subjectCode = cbSubject.SelectedValue.ToString();
            string teacherCode = cbTeacher.SelectedValue.ToString();
            string classId = cbClass.SelectedValue.ToString();

            string buildingId = cbBuilding.SelectedValue.ToString();
            string classroomId = cbClassroom.SelectedValue.ToString();

            Location location = db.Locations.Single(l => l.building_id.Equals(buildingId) && l.classroom_id.Equals(classroomId));
            Subject subject = db.Subjects.Single(s => s.code.Equals(subjectCode));
            var class_Students = db.Class_Students.Where(cs => cs.class_id.Equals(classId));

            List<Schedule> schedules = new List<Schedule>();
            List<Attendance> attendances = new List<Attendance>();

            for(int i = 0; i < subject.duration; i++)
            {
                foreach (var slot in selectedSlots)
                {
                    DateTime date = slot.Key.AddDays(7 * i);
                    Schedule schedule = new Schedule
                    {
                        id = date.ToString("dd/MM/yyyy") + "_" + slot.Value,
                        class_id = classId,
                        teacher_code = teacherCode,
                        subject_code = subjectCode,
                        date_time = date,
                        slot = slot.Value,
                        location_id = location.id
                    };
                    schedules.Add(schedule);
                }
            }

            foreach(var schedule in schedules)
            {
                foreach(var student in class_Students)
                {
                    Attendance attendance = new Attendance
                    {
                        id = schedule.id + "_" + student.student_code,
                        schedule_id = schedule.id,
                        student_code = student.student_code,
                        attended = -1
                    };
                    attendances.Add(attendance);
                }
            }

            db.Schedules.InsertAllOnSubmit(schedules);
            db.Attendances.InsertAllOnSubmit(attendances);

            try
            {
                db.SubmitChanges();

                DialogResult dialogResult = MessageBox.Show("Thêm thành công !!!", "", MessageBoxButtons.OK);
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

        private void changeClassRoom()
        {
            cbClassroom.DataSource = from l in db.Locations
                                     join b in db.Buildings on l.building_id equals b.id
                                     join c in db.Classrooms on l.classroom_id equals c.id
                                     where l.building_id == cbBuilding.SelectedValue
                                     select new
                                     {
                                         id = c.id,
                                         name = c.name
                                     };
            cbClassroom.DisplayMember = "name";
            cbClassroom.ValueMember = "id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbBuilding_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeClassRoom();
        }
    }
}
