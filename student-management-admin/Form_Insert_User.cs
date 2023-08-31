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
    public partial class Form_Insert_User : Form
    {
        AdminClassesDataContext db = new AdminClassesDataContext();
        Main_Form_Admin main_Form;
        string txtSelect { get; set;}
        string txtUserCode { get; set; }
        bool updateData { get; set; }


        public Form_Insert_User(string role, string userCode, bool isUpdate, Main_Form_Admin mainForm)
        {
            InitializeComponent();       
            txtSelect = role;
            main_Form = mainForm;
            updateData = isUpdate;
            txtUserCode = userCode;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text.Trim();
            string name = txtName.Text.Trim();
            bool gender = isGender();
            string acc = txtAccount.Text;
            string email = txtEmail.Text.ToLower();
            string pass = "123456aA@";

            if (string.IsNullOrEmpty(code))
            {
                switch(txtSelect)
                {
                    case "student":
                        lblValidateCode.Text = "Mã sinh viên không được trống";
                        break;
                    case "teacher":
                        lblValidateCode.Text = "Mã giảng viên không được trống";
                        break;
                }
            } else
            {
                lblValidateCode.Text = "";
            }

            if (string.IsNullOrEmpty(name))
            {
                lblValidateName.Text = "Họ và tên không được trống";
            }
            else
            {
                lblValidateName.Text = "";
            }

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name))
            {
                if(Function.validateEmail(email))
                {
                    switch (txtSelect)
                    {
                        case "student":

                            if (updateData)
                            {
                                DialogResult result = MessageBox.Show("Bạn có muốn thay đổi thông tin " + code, "Cập nhật thông tin", MessageBoxButtons.YesNoCancel);
                                if (result == DialogResult.Yes)
                                {
                                    Student s = db.Students.Single(stu => stu.code.Equals(code));
                                    s.name = name;
                                    s.account = acc;
                                    s.email = email;
                                    s.gender = gender;
                                    s.active = isActive();
                                }
                            }else
                            {
                                var student = db.Students.Where(stu => stu.code.Equals(code)).FirstOrDefault();
                                if (student != null)
                                {
                                    MessageBox.Show("Sinh viên này đã tồn tại", "Thêm thông tin");
                                }
                                else
                                {
                                    Student s = new Student();
                                    s.code = code;
                                    s.name = name;
                                    s.gender = gender;
                                    s.account = acc;
                                    s.email = email;
                                    s.password = pass;
                                    s.active = true;

                                    db.Students.InsertOnSubmit(s);

                                }
                            }

                            break;
                        case "teacher":
                            if (updateData)
                            {
                                DialogResult result = MessageBox.Show("Bạn có muốn thay đổi thông tin " + code, "Cập nhật thông tin", MessageBoxButtons.YesNoCancel);
                                if (result == DialogResult.Yes)
                                {
                                    Teacher t = db.Teachers.Single(tea => tea.code.Equals(code));
                                    t.name = name;
                                    t.account = acc;
                                    t.email = email;
                                    t.gender = gender;
                                    t.active = isActive();
                                }
                            }
                            else
                            {
                                var student = db.Students.Where(stu => stu.code.Equals(code)).FirstOrDefault();
                                if (student != null)
                                {
                                    MessageBox.Show("Giảng viên này đã tồn tại", "Thêm thông tin");
                                }
                                else
                                {
                                    Teacher t = new Teacher();
                                    t.code = code;
                                    t.name = name;
                                    t.gender = gender;
                                    t.account = acc;
                                    t.email = email;
                                    t.password = pass;
                                    t.active = true;

                                    db.Teachers.InsertOnSubmit(t);

                                }
                            }

                            break;
                    }
                    try
                    {
                        db.SubmitChanges();
                        string title = "Thêm thông tin";
                        string des = "Thêm thông tin thành công !!!";
                        if (updateData)
                        {
                            title = "Cập nhật thông tin";
                            des = "Cập nhật thông tin thành công !!!";
                        }
                        DialogResult result = MessageBox.Show(des, title, MessageBoxButtons.OK);
                        if (result == DialogResult.OK)
                        {
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại thông tin", updateData ? "Cập nhật thông tin" : "Thêm thông tin");
                        Console.WriteLine(ex.Message);
                    }
                } else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại thông tin",updateData ? "Cập nhật thông tin" : "Thêm thông tin");
                }
            }

        }

        private bool isGender()
        {
            bool check = true;
            if (rBtnFemale.Checked)
            {
                check = false;
            }
            return check;
        }

        private bool isActive()
        {
            bool check = true;
            if (rBtnInActive.Checked)
            {
                check = false;
            }
            return check;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refillAccAndEmail()
        {
            string name = txtName.Text;
            string code = txtCode.Text;
            
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(code))
            {
                txtAccount.Text = Function.convertName(name) + code;
                txtEmail.Text = Function.convertName(name) + code + "@email.com";
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            refillAccAndEmail();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            refillAccAndEmail();
        }

        private void Form_Insert_Data_FormClosed(object sender, FormClosedEventArgs e)
        {
            main_Form.DataGridViewRefresh();
        }

        private void Form_Insert_Data_Load(object sender, EventArgs e)
        {
            if (!updateData)
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtAccount.Text = "";
                txtEmail.Text = "";
                pnStatus.Visible = false;
                rBtnMale.Checked = true;
            } else
            {
                btnAdd.Text = "Cập nhật";
                lblPassword.Visible = false;
                pnStatus.Visible = true;
                txtCode.ReadOnly = true;
                switch (txtSelect)
                {
                    case "student":
                        Student student = db.Students.Single(s => s.code.Equals(txtUserCode));
                        txtCode.Text = student.code;
                        txtName.Text = student.name;

                        if (student.gender)
                        {
                            rBtnMale.Checked = true;
                        }
                        else
                        {
                            rBtnFemale.Checked = true;
                        }

                        txtAccount.Text = student.account;
                        txtEmail.Text = student.email;

                        rBtnActive.Text = "Đang học";
                        rBtnInActive.Text = "Dừng học";
                        if (student.active)
                        {
                            rBtnActive.Checked = true;
                        }
                        else
                        {
                            rBtnInActive.Checked = true;
                        }
                        break;
                    case "teacher":
                        Teacher teacher = db.Teachers.Single(t => t.code.Equals(txtUserCode));
                        txtCode.Text = teacher.code;
                        txtName.Text = teacher.name;

                        if (teacher.gender)
                        {
                            rBtnMale.Checked = true;
                        }
                        else
                        {
                            rBtnFemale.Checked = true;
                        }

                        txtAccount.Text = teacher.account;
                        txtEmail.Text = teacher.email;
                        rBtnActive.Text = "Làm việc";
                        rBtnInActive.Text = "Nghỉ việc";
                        if (teacher.active)
                        {
                            rBtnActive.Checked = true;
                        }
                        else
                        {
                            rBtnInActive.Checked = true;
                        }
                        break;
                }
            }

            switch (txtSelect)
            {
                case "student":
                    if (updateData)
                    {
                        lblTitle.Text = "Cập nhật thông tin sinh viên";
                    }
                    else
                    {
                        lblTitle.Text = "Thêm thông tin sinh viên";
                    }
                    lblCode.Text = "Mã sinh viên";
                    break;
                case "teacher":
                    if (updateData)
                    {
                        lblTitle.Text = "Cập nhật thông tin giảng viên";
                    }
                    else
                    {
                        lblTitle.Text = "Thêm thông tin giảng viên";
                    }
                    lblCode.Text = "Mã giảng viên";
                    break;
            }
        }
    }
}
