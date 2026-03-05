namespace Brgy.App
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            txtSecretCode = new TextBox();
            txtFullName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnRegister = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            backBtn = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtSecretCode
            // 
            txtSecretCode.Location = new Point(154, 91);
            txtSecretCode.Name = "txtSecretCode";
            txtSecretCode.Size = new Size(62, 23);
            txtSecretCode.TabIndex = 4;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(154, 123);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(405, 23);
            txtFullName.TabIndex = 5;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(154, 158);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(405, 23);
            txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(154, 197);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(405, 23);
            txtPassword.TabIndex = 7;
            // 
            // btnRegister
            // 
            btnRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnRegister.Depth = 0;
            btnRegister.HighEmphasis = true;
            btnRegister.Icon = null;
            btnRegister.Location = new Point(305, 232);
            btnRegister.Margin = new Padding(4, 6, 4, 6);
            btnRegister.MouseState = MaterialSkin.MouseState.HOVER;
            btnRegister.Name = "btnRegister";
            btnRegister.NoAccentTextColor = Color.Empty;
            btnRegister.Size = new Size(89, 36);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "REGISTER";
            btnRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnRegister.UseAccentColor = false;
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(794, 383);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BackgroundImage = (Image)resources.GetObject("panel2.BackgroundImage");
            panel2.BackgroundImageLayout = ImageLayout.Stretch;
            panel2.Location = new Point(321, 22);
            panel2.Name = "panel2";
            panel2.Size = new Size(126, 124);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtSecretCode);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtUsername);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtFullName);
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnRegister);
            panel3.Location = new Point(53, 64);
            panel3.Name = "panel3";
            panel3.Size = new Size(709, 274);
            panel3.TabIndex = 8;
            // 
            // backBtn
            // 
            backBtn.Location = new Point(722, 35);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(75, 23);
            backBtn.TabIndex = 10;
            backBtn.Text = "back";
            backBtn.UseVisualStyleBackColor = true;
            backBtn.Click += backBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 94);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 9;
            label1.Text = "CODE:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 123);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 11;
            label3.Text = "FULLNAME:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 166);
            label4.Name = "label4";
            label4.Size = new Size(71, 15);
            label4.TabIndex = 12;
            label4.Text = "USERNAME:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 205);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 13;
            label2.Text = "PASSWORD:";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(backBtn);
            Controls.Add(panel1);
            Name = "RegisterForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtSecretCode;
        private TextBox txtFullName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private MaterialSkin.Controls.MaterialButton btnRegister;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button backBtn;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label1;
    }
}