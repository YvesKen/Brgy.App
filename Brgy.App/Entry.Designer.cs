namespace Brgy.App
{
    partial class Entry
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entry));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnPublic = new MaterialSkin.Controls.MaterialButton();
            btnAdmin = new MaterialSkin.Controls.MaterialButton();
            panel1 = new Panel();
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnPublic
            // 
            btnPublic.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnPublic.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnPublic.Depth = 0;
            btnPublic.HighEmphasis = true;
            btnPublic.Icon = null;
            btnPublic.Location = new Point(581, 405);
            btnPublic.Margin = new Padding(4, 6, 4, 6);
            btnPublic.MouseState = MaterialSkin.MouseState.HOVER;
            btnPublic.Name = "btnPublic";
            btnPublic.NoAccentTextColor = Color.Empty;
            btnPublic.Size = new Size(153, 36);
            btnPublic.TabIndex = 0;
            btnPublic.Text = "PUBLIC / RESIDENT";
            btnPublic.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnPublic.UseAccentColor = false;
            btnPublic.UseVisualStyleBackColor = true;
            btnPublic.Click += btnPublic_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAdmin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAdmin.Depth = 0;
            btnAdmin.HighEmphasis = true;
            btnAdmin.Icon = null;
            btnAdmin.Location = new Point(581, 312);
            btnAdmin.Margin = new Padding(4, 6, 4, 6);
            btnAdmin.MouseState = MaterialSkin.MouseState.HOVER;
            btnAdmin.Name = "btnAdmin";
            btnAdmin.NoAccentTextColor = Color.Empty;
            btnAdmin.Size = new Size(144, 36);
            btnAdmin.TabIndex = 1;
            btnAdmin.Text = "ADMIN / OFFICIAL";
            btnAdmin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAdmin.UseAccentColor = false;
            btnAdmin.UseVisualStyleBackColor = true;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.Controls.Add(btnPublic);
            panel1.Controls.Add(btnAdmin);
            panel1.Controls.Add(guna2Panel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(1258, 614);
            panel1.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            guna2Panel1.BackColor = Color.Transparent;
            guna2Panel1.CustomizableEdges = customizableEdges1;
            guna2Panel1.FillColor = Color.FromArgb(40, 50, 144, 255);
            guna2Panel1.Location = new Point(541, 276);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel1.Size = new Size(235, 324);
            guna2Panel1.TabIndex = 2;
            guna2Panel1.UseTransparentBackground = true;
            // 
            // Entry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(panel1);
            Name = "Entry";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Barangay Information System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialButton btnPublic;
        private MaterialSkin.Controls.MaterialButton btnAdmin;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}
