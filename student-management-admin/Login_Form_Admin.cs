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
    public partial class Login_Form_Admin : Form
    {
        public Login_Form_Admin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string rawPass = txtPassword.Text;
            if (string.IsNullOrEmpty(email))
            {
                lblValidateEmail.Text = "Email là bắt buộc";
                lblValidateEmail.Visible = true;
            }
            else
            {
                lblValidateEmail.Visible = false;
            }

            if (string.IsNullOrEmpty(rawPass))
            {
                lblValidatePassword.Text = "Mật khẩu là bắt buộc";
                lblValidatePassword.Visible = true;
            }
            else
            {
                lblValidatePassword.Visible = false;
            }

            if (!string.IsNullOrEmpty(email) && !Function.validateEmail(email))
            {
                lblValidateEmail.Text = "Email phải phù hợp với định dạng: abc@abc.com";
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            }
            else if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(rawPass) && Function.validateEmail(email))
            {
                AdminClassesDataContext db = new AdminClassesDataContext();
                var result = db.Admins
                    .Where(admin => admin.email.Equals(email) && admin.password.Equals(rawPass) && admin.active == true)
                    .FirstOrDefault();
                if (result == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại", "Lỗi đăng nhập");
                }
                else
                {
                    this.Hide();
                    Main_Form_Admin main_Form = new Main_Form_Admin(result.name);
                    main_Form.Show();
                }
            }
        }
    }
}
