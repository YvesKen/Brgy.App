using System;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Brgy.App
{
    public partial class Entry : MaterialForm
    {
        public Entry()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void btnPublic_Click(object sender, EventArgs e)
        {
            new PublicDashboard(false).Show(); 
            this.Hide();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            new LogForm().Show(); 
            this.Hide();
        }
    }
}