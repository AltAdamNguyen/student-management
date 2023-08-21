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
    public partial class Form_Insert_Subject : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();
        Main_Form_Admin main_Form;
        bool updateData { get; set; }
        string txtSubCode { get; set; }

        public Form_Insert_Subject(string code, bool isUpdate, Main_Form_Admin mainForm)
        {
            InitializeComponent();
            main_Form = mainForm;
            updateData = isUpdate;
            txtSubCode = code;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            string des = txtDes.Text;

            if (string.IsNullOrEmpty(code))
            {
                lblCode.Text = "Mã môn không được trống";
            }
            else
            {
                lblValidateCode.Text = "";
            }

            if (string.IsNullOrEmpty(name))
            {
                lblValidateName.Text = "Tên môn không được trống";
            }
            else
            {
                lblValidateName.Text = "";
            }

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name))
            {
                if (updateData)
                {
                    Subject subject = db.Subjects.Single(s => s.code.Equals(code));
                    subject.name = name;
                    subject.descript = des;
                } else
                {
                    var result = db.Subjects.Where(s => s.code.Equals(code)).FirstOrDefault();
                    if (result == null)
                    {

                        Subject subject = new Subject();
                        subject.code = code;
                        subject.name = name;
                        subject.descript = des;

                        db.Subjects.InsertOnSubmit(subject);

                    }
                    else
                    {
                        MessageBox.Show("Môn học đã tồn tại", "Thêm môn học");
                    }
                }
                string title = "Thêm môn học";
                string desMes = "Thêm môn học thành công !!!";
                if (updateData)
                {
                    title = "Cập nhật môn học";
                    des = "Cập nhật môn học thành công !!!";
                }
                try
                {
                    db.SubmitChanges();

                    DialogResult dialogResult = MessageBox.Show(desMes, title, MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin", title);
                    Console.WriteLine(ex);
                }
                
            }
        }

        private void Form_Insert_Subject_FormClosed(object sender, FormClosedEventArgs e)
        {
            main_Form.DataGridViewRefresh();
        }

        private void Form_Insert_Subject_Load(object sender, EventArgs e)
        {
            if (updateData)
            {
                lblTitle.Text = "Cập nhật thông tin môn học";
                btnAdd.Text = "Cập nhật";
                txtCode.ReadOnly = true;
                txtName.Focus();

                Subject subject = db.Subjects.SingleOrDefault(s => s.code.Equals(txtSubCode));
                txtCode.Text = subject.code;
                txtName.Text = subject.name;
                txtDes.Text = subject.descript;
            }
        }
    }
}
