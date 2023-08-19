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
            lblValidateEmail.Visible = false;
            lblValidatePassword.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
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

            if (!string.IsNullOrEmpty(email) && !Function.validateEmail(email))
            {
                lblValidateEmail.Text = "Email phải phù hợp với định dạng: abc@abc.com";
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            } else if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(rawPass) && Function.validateEmail(email))
            {
                DataClassesDataContext db = new DataClassesDataContext();
                var result = db.Teachers.Where(teacher => teacher.email.Equals(email) && teacher.password.Equals(rawPass)).FirstOrDefault();
                var test = db.Teachers;
                if (result == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Lỗi đăng nhập");
                } else
                {
                    this.Hide();
                    Main_Form mainForm = new Main_Form();
                    mainForm.Show();
                }
                Console.WriteLine(result);
            }
        }


        private void txtEmail_Validated(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(email) && !Function.validateEmail(email))
            {
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            }
        }
    }
}
