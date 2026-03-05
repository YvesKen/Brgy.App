using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Brgy.App
{
    public partial class PublicDashboard : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private bool _isOfficial;

        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BrgyDB;Integrated Security=True";

        public PublicDashboard(bool userIsOfficial)
        {
            InitializeComponent();
            _isOfficial = userIsOfficial;

        
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue700, Primary.Blue900,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);

            this.DrawerShowIconsWhenHidden = true;
            this.DrawerTabControl = materialTabControl1; 
            this.DrawerIndicatorWidth = 4;
            this.DrawerBackgroundWithAccent = true;

          
            panel1.BackColor = Color.Transparent;
            ApplyCustomLabelStyles();

            ApplyAccessControl();
            LoadPopulationData();
            LoadAttendanceData();
        }

        private void ApplyCustomLabelStyles()
        {
            Label[] popLabels = { lblTotalCount, lblMaleCount, lblFemaleCount, lblMinorCount, lblAdultCount, lblSeniorCount };
            Font cooperFont = new Font("Cooper Black", 20f, FontStyle.Bold);

            foreach (Label lbl in popLabels)
            {
                lbl.ForeColor = Color.DodgerBlue;
                lbl.Font = cooperFont;
                lbl.BackColor = Color.Transparent;
            }
            label2.ForeColor = Color.DodgerBlue;
            label2.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
        }

        private void LoadPopulationData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 Males, Females, Minors, Adults, Seniors FROM PopulationStats";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtMaleInput.Text = reader["Males"].ToString();
                        txtFemaleInput.Text = reader["Females"].ToString();
                        txtMinorInput.Text = reader["Minors"].ToString();
                        txtAdultInput.Text = reader["Adults"].ToString();
                        txtSeniorInput.Text = reader["Seniors"].ToString();

                        CalculateTotal();
                        UpdateChartVisuals();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load Error: " + ex.Message);
            }
        }

        private void ApplyBlueStyle()
        {
            chart1.BackColor = Color.White;
            chart1.ChartAreas[0].BackColor = Color.White;

            chart1.Series["Series1"].ChartType = SeriesChartType.Doughnut;

         
            if (chart1.Series["Series1"].Points.Count >= 3)
            {
                chart1.Series["Series1"].Points[0].Color = Color.FromArgb(0, 153, 188);  
                chart1.Series["Series1"].Points[1].Color = Color.FromArgb(0, 122, 204);  
                chart1.Series["Series1"].Points[2].Color = Color.FromArgb(2, 65, 115);   
            }

            chart1.Series["Series1"].BorderColor = Color.White;
            chart1.Series["Series1"].BorderWidth = 2;
            chart1.Series["Series1"].LabelForeColor = Color.DimGray;

            chart1.Legends[0].BackColor = Color.White;
            chart1.Series["Series1"]["DoughnutRadius"] = "60";
        }

        private void CalculateTotal()
        {
 
            int.TryParse(txtMaleInput.Text, out int male);
            int.TryParse(txtFemaleInput.Text, out int female);
            int.TryParse(txtMinorInput.Text, out int minor);
            int.TryParse(txtAdultInput.Text, out int adult);
            int.TryParse(txtSeniorInput.Text, out int senior);

            int total = male + female;

         
            lblTotalCount.Text = total.ToString("N0");
            lblMaleCount.Text = male.ToString();
            lblFemaleCount.Text = female.ToString();
            lblMinorCount.Text = minor.ToString();
            lblAdultCount.Text = adult.ToString();
            lblSeniorCount.Text = senior.ToString();

            
        }

        private void UpdateChartVisuals()
        {
            if (chart1.Series.Count > 0)
            {
                chart1.Series["Series1"].Points.Clear();

         
                chart1.Series["Series1"].Points.AddXY("Minor", txtMinorInput.Text);
                chart1.Series["Series1"].Points.AddXY("Adult", txtAdultInput.Text);
                chart1.Series["Series1"].Points.AddXY("Senior", txtSeniorInput.Text);

            
                chart1.Series["Series1"].Label = "#PERCENT{P0}";
                chart1.Series["Series1"].LegendText = "#VALX";

                ApplyBlueStyle();
            }
        }

        private void ApplyAccessControl()
        {
            btnPost.Visible = _isOfficial;
            btnUpload.Visible = _isOfficial;
            btnLogout.Visible = true;
            cardAdminTools.Visible = _isOfficial;

            txtName.Visible = _isOfficial;
            cmbPosition.Visible = _isOfficial;
            cmbAttendance.Visible = _isOfficial;
            txtLeaveReason.Visible = _isOfficial;
            btnAddOfficial.Visible = _isOfficial;
            btnRemoveOfficial.Visible = _isOfficial;

            string savedText = Properties.Settings.Default.LastPostText;
            txtAnnouncement.Text = savedText?.Trim();
            txtAnnouncement.ReadOnly = !_isOfficial;

            string savedImagePath = Properties.Settings.Default.ImagePath;
            if (!string.IsNullOrEmpty(savedImagePath) && System.IO.File.Exists(savedImagePath))
            {
                picPreview.Image = Image.FromFile(savedImagePath);
                picPreview.Visible = true;
            }
        }

        private void btnUpdateChart_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateTotal();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE PopulationStats SET Males=@m, Females=@f, Minors=@min, Adults=@a, Seniors=@s";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@m", int.Parse(txtMaleInput.Text));
                    cmd.Parameters.AddWithValue("@f", int.Parse(txtFemaleInput.Text));
                    cmd.Parameters.AddWithValue("@min", int.Parse(txtMinorInput.Text));
                    cmd.Parameters.AddWithValue("@a", int.Parse(txtAdultInput.Text));
                    cmd.Parameters.AddWithValue("@s", int.Parse(txtSeniorInput.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                UpdateChartVisuals();
                MessageBox.Show("Information Saved Successfully!");
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Log out of the system?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                new Entry().Show();
                this.Hide();
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picPreview.Image = Image.FromFile(ofd.FileName);
                    picPreview.Visible = true;
                    Properties.Settings.Default.ImagePath = ofd.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.LastPostText = txtAnnouncement.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Announcement Posted!");
        }

        private void LoadAttendanceData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Name, Position, CurrentStatus AS [Today's Status], Remarks, TotalPresent AS [Total Present], TotalAbsent AS [Total Absent], TotalLeave AS [Total Leave] FROM OfficialAttendance";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dgvAttendance.DataSource = dt;
                }
            }
            catch (Exception ex) { Console.WriteLine("Grid Error: " + ex.Message); }
        }

        private void btnAddOfficial_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(cmbPosition.Text) || string.IsNullOrWhiteSpace(cmbAttendance.Text))
            {
                MessageBox.Show("Please fill out Name, Position, and Status.");
                return;
            }

            string status = cmbAttendance.Text;
            string remarks = (status == "Leave") ? txtLeaveReason.Text : "-";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        IF EXISTS (SELECT 1 FROM OfficialAttendance WHERE Name = @Name)
                        BEGIN
                            UPDATE OfficialAttendance 
                            SET CurrentStatus = @Status, Position = @Position, Remarks = @Remarks,
                                TotalPresent = TotalPresent + CASE WHEN @Status = 'Present' THEN 1 ELSE 0 END,
                                TotalAbsent = TotalAbsent + CASE WHEN @Status = 'Absent' THEN 1 ELSE 0 END,
                                TotalLeave = TotalLeave + CASE WHEN @Status = 'Leave' THEN 1 ELSE 0 END
                            WHERE Name = @Name
                        END
                        ELSE
                        BEGIN
                            INSERT INTO OfficialAttendance (Name, Position, CurrentStatus, Remarks, TotalPresent, TotalAbsent, TotalLeave)
                            VALUES (@Name, @Position, @Status, @Remarks, 
                                    CASE WHEN @Status = 'Present' THEN 1 ELSE 0 END,
                                    CASE WHEN @Status = 'Absent' THEN 1 ELSE 0 END,
                                    CASE WHEN @Status = 'Leave' THEN 1 ELSE 0 END)
                        END";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Position", cmbPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.ExecuteNonQuery();
                }
                LoadAttendanceData();
                MessageBox.Show("Attendance Updated.");
            }
            catch (Exception ex) { MessageBox.Show("DB Error: " + ex.Message); }
        }

        private void btnRemoveOfficial_Click(object sender, EventArgs e)
        {
            if (dgvAttendance.SelectedRows.Count > 0)
            {
                string selectedName = dgvAttendance.SelectedRows[0].Cells["Name"].Value.ToString();
                if (MessageBox.Show($"Remove {selectedName}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "DELETE FROM OfficialAttendance WHERE Name = @Name";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@Name", selectedName);
                            cmd.ExecuteNonQuery();
                        }
                        LoadAttendanceData();
                    }
                    catch (Exception ex) { MessageBox.Show("Delete Error: " + ex.Message); }
                }
            }
            else { MessageBox.Show("Select a row first."); }
        }

        private void cmbAttendance_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLeaveReason.Enabled = (cmbAttendance.Text == "Leave");
            if (cmbAttendance.Text != "Leave") txtLeaveReason.Clear();
        }

       
        private void PublicDashboard_Load(object sender, EventArgs e) { }
        private void btnLogout_Click(object sender, EventArgs e) { }
        private void ofdUpload_FileOk(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void txtAnnouncement_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void materialTextBox4_TextChanged(object sender, EventArgs e) { }
        private void chart1_Click(object sender, EventArgs e) { }
        private void lblFemaleCount_Click(object sender, EventArgs e) { }
        private void txtMinorInput_TextChanged(object sender, EventArgs e) { }
        private void pictureBox5_Click(object sender, EventArgs e) { }
        private void txtLeaveReason_TextChanged(object sender, EventArgs e) { }
        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e) { }
        private void dgvAttendance_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void tabPage2_Click(object sender, EventArgs e) { }
        private void lblTotalCount_Click(object sender, EventArgs e) { }
        private void lblAdultCount_Click(object sender, EventArgs e) { }

        private void txtSeniorInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}