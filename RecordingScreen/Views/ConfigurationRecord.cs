using Long.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecordingScreen.Views
{
    public partial class ConfigurationRecord : Form
    {
        public int Quality { get; set; }
        public int FPS { get; set; }
        public string PathImage { get; set; }
        public ConfigurationRecord()
        {
            InitializeComponent();
        }

        private void ConfigurationRecord_Load(object sender, EventArgs e)
        {
            txtFPS.Text = FPS.ToString();
            txtQuality.Text = Quality.ToString();
            txtSaveAs.Text = PathImage;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            string path = UI.OpenFolder();
            if (path != null)
            {
                PathImage = path;
                txtSaveAs.Text = path+"\\out.avi";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFPS.Text) && !string.IsNullOrEmpty(txtQuality.Text) && !string.IsNullOrEmpty(txtSaveAs.Text))
            {
                FPS = txtFPS.Text.ToInt();
                Quality = txtQuality.Text.ToInt();
                PathImage = txtSaveAs.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtQuality_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtQuality.Text, "[^0-9]"))
                txtQuality.Text = txtQuality.Text.Remove(txtQuality.Text.Length - 1);
        }

        private void txtFPS_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtFPS.Text, "[^0-9]"))
                txtFPS.Text = txtFPS.Text.Remove(txtFPS.Text.Length - 1);
        }
    }
}
