using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            string pass = txtPassword.Text;
            if (string.IsNullOrEmpty(email))
            {
                lblValidateEmail.Text = "Email là bắt buộc";
                lblValidateEmail.Visible = true;
            } else
            {
                lblValidateEmail.Visible = false;
            }

            if (string.IsNullOrEmpty(pass))
            {
                lblValidatePassword.Text = "Mật khẩu là bắt buộc";
                lblValidatePassword.Visible = true;
            } else
            {
                lblValidatePassword.Visible = false;
            }

            if (!string.IsNullOrEmpty(email) && !validateEmail(email))
            {
                lblValidateEmail.Text = "Email phải phù hợp với định dạng: abc@abc.com";
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            } else if (!string.IsNullOrEmpty(email) && string.IsNullOrEmpty(pass) && !validateEmail(email))
            {

            }
        }

        private bool validateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regex = new Regex(pattern);
            bool isValid = regex.IsMatch(email);

            return isValid;
        }

        private void txtEmail_Validated(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            if (string.IsNullOrEmpty(email) && !validateEmail(email))
            {
                lblValidateEmail.Visible = true;
                txtEmail.Focus();
            }
        }
    }
}
