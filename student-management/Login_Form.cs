using student_management.Helper;
using student_management.DAO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace student_management
{
    public partial class Login_Form : Form
    {
        public Login_Form()
        {
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            rBtnStudent.Checked = true;
            lblValidateEmail.Visible = false;
            lblValidatePassword.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim().ToLower();
            string rawPass = txtPassword.Text;
            if (string.IsNullOrEmpty(email))
            {
                lblValidateEmail.Text = "Email là bắt buộc";
                lblValidateEmail.Visible = true;
            } else
            {
                lblValidateEmail.Visible = false;
            }

            if (string.IsNullOrEmpty(rawPass))
            {
                lblValidatePassword.Text = "Mật khẩu là bắt buộc";
                lblValidatePassword.Visible = true;
            } else
            {
                lblValidatePassword.Visible = false;
            }

            if (string.IsNullOrEmpty(email))
            {
                lblValidateEmail.Text = "Email phải phù hợp với định dạng: abc@abc.com";
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            } else if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(rawPass))
            {
                DataClassesDataContext db = new DataClassesDataContext();
                if (rBtnTeacher.Checked)
                {
                    var result = db.Teachers
                        .Where(teacher => (teacher.email.Equals(email) || teacher.account.Equals(email)) && teacher.password.Equals(rawPass) && teacher.active == true)
                        .FirstOrDefault();

                    if (result == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại", "Lỗi đăng nhập");
                    }
                    else
                    {
                        this.Hide();
                        Main_Form_Teacher mainForm = new Main_Form_Teacher(result);
                        mainForm.Show();
                    }
                } else
                {
                    var result = db.Students
                        .Where(student => (student.email.Equals(email) || student.account.Equals(email)) && student.password.Equals(rawPass) && student.active == true)
                        .FirstOrDefault();

                    if (result == null)
                    {
                        MessageBox.Show("Tài khoản không tồn tại", "Lỗi đăng nhập");
                    }
                    else if (!result.active)
                    {
                        MessageBox.Show("Tài khoản bị vô hiệu hoá. Vui lòng liên hệ admin", "Lỗi đăng nhập");
                    }
                    else
                    {
                        this.Hide();
                        Main_Form_Student mainForm = new Main_Form_Student(result);
                        mainForm.Show();
                    }
                }
            }
        }
    }
}
