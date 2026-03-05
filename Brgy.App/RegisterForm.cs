using System;
using System.Windows.Forms;
using Brgy.Domain;
using Brgy.Service;
using MaterialSkin.Controls;

namespace Brgy.App
{
    public partial class RegisterForm : MaterialForm
    {
        public RegisterForm() { InitializeComponent(); }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtSecretCode.Text != "Honey123")
            {
                MessageBox.Show("Invalid Official Code!");
                return;
            }

            Account newOfficial = new Account
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                FullName = txtFullName.Text,
                Code = txtSecretCode.Text
            };

            AuthService auth = new AuthService();
            if (auth.RegisterOfficial(newOfficial))
            {
                MessageBox.Show("Account Created!");
                new LogForm().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration Failed. Check Database connection.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            new LogForm().Show(); // Redirect to Login
            this.Hide();
        }
    }
}