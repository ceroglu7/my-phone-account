using System;
using System.Windows.Forms;

namespace MyPhoneAccount
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        
        MainForm mainform = new MainForm();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "cihane" && password == "1234")
            {
                mainform.Show();
                this.Hide();
            }
            else if (true)
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (keyData == Keys.Enter)
            {
                if (username == "cihane" && password == "1234")
                {
                    mainform.Show();
                    this.Hide();
                }
                else if (true)
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void LoginForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
