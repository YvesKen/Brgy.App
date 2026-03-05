using System;
using System.Windows.Forms;
using Brgy.Domain;
using Brgy.Service;
using MaterialSkin.Controls;

namespace Brgy.App
{
    public partial class LogForm : MaterialForm
    {
        private readonly AuthService _authService = new AuthService();

        public LogForm() { InitializeComponent(); }

        private void materialButton1_Click(object sender, EventArgs e) 
        {
            Account user = _authService.VerifyUser(txtUser.Text, txtPass.Text);

            if (user != null)
            {
                new PublicDashboard(user.IsOfficial).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials!");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void backBtn1_Click(object sender, EventArgs e)
        {
            new Entry().Show(); // Redirect to Login
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}