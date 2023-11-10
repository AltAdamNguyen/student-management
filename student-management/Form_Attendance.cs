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
    public partial class Form_Attendance : Form
    {
        DataClassesDataContext db = new DataClassesDataContext();
        string schedule_id { get; set; }
        
        List<string> students = new List<string>();
        public Form_Attendance(string id)
        {
            InitializeComponent();
            schedule_id = id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Attendance> attendances = db.Attendances.Where(a => a.schedule_id.Equals(schedule_id)).ToList();
            int length = attendances.Count;

            for (int i = 0; i < length; i++)
            {
                Attendance attendance = attendances[i];
                if (students.Contains(attendances[i].student_code))
                {
                    attendance.attended = 1;
                }
                else
                {
                    attendance.attended = 0;
                }
            }

            try
            {
                db.SubmitChanges();

                DialogResult dialogResult = MessageBox.Show("Điểm danh thành công", "", MessageBoxButtons.OK);
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Attendance_Load(object sender, EventArgs e)
        {
            var query = from a in db.Attendances
                        join s in db.Students on a.student_code equals s.code
                        where a.schedule_id == schedule_id
                        select new
                        {
                            code = s.code,
                            name = s.name,
                            attended = a.attended
                        };

            DataTable dataTable = new DataTable();
            dataTable.DefaultView.AllowDelete = false;
            dataTable.DefaultView.AllowNew = false;

            dataTable.Columns.Add("Mã SV", typeof(string));
            dataTable.Columns.Add("Tên SV", typeof(string));
            dataTable.Columns.Add("Điểm danh", typeof(bool));

            dataTable.Columns["Mã SV"].ReadOnly = true;
            dataTable.Columns["Tên SV"].ReadOnly = true;

            foreach (var student in query)
            {
                bool isAttended = student.attended == 1;
                dataTable.Rows.Add(student.code, student.name, isAttended);
            }

            dtgvAttend.DataSource = dataTable;
        }

        private void dtgvAttend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                bool isCheck = (bool)dtgvAttend.Rows[e.RowIndex].Cells[2].Value;
                string code = dtgvAttend.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (!isCheck)
                {
                    students.Add(code);
                }
                else
                {
                    students.Remove(code);
                }
            }
        }
    }
}
