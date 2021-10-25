using Long.Shared;
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
    public partial class RecordScreen : Form
    {
        private Recorder rec;
        int timer = 0;
        private int Quality = 60;
        private int FPS = 10;
        private string PathImage = "out.avi";
        private bool IsChange = false;
        private string PathBin = System.IO.Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public RecordScreen()
        {
            InitializeComponent();
            btnStop.Visible = false;
        }

        private void RecordScreen_Load(object sender, EventArgs e)
        {
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            btnStart.Visible = true;
            timer1.Stop();
            rec?.Dispose();
        }
        public void Alarm()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(aTimer_Tick);
            timer1.Interval = 1000;
            timer1.Start();
            timer = 0;
            lblTime.Text =timer.ToString();
        }
        private void aTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            lblTime.Text = timer.ToString();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!IsChange && UI.Quesion("Quay màn hình với cấu hình mặc định?"))
            {
                rec = new Recorder(new RecorderParams(PathImage, FPS, Quality));
                lblTime.Visible = true;
                Alarm();
            }
            else
            {
                if (!IsChange)
                {
                    using (ConfigurationRecord frm = new ConfigurationRecord())
                    {
                        frm.PathImage = PathBin + "\\" + PathImage;
                        frm.FPS = FPS;
                        frm.Quality = Quality;
                        if (frm.ShowDialog() == DialogResult.OK)
                            rec = new Recorder(new RecorderParams(frm.PathImage, frm.FPS, frm.Quality));
                        else
                        {
                            if (UI.Quesion("Quay màn hình với cấu hình mặc định?"))
                            {
                                rec = new Recorder(new RecorderParams(PathImage, FPS, Quality));
                                lblTime.Visible = true;
                                Alarm();
                            }
                        }
                    }
                }
                else
                {
                    rec = new Recorder(new RecorderParams(PathImage, FPS, Quality));
                    lblTime.Visible = true;
                    Alarm();
                }
            }
            btnStop.Visible = true;
            btnStart.Visible = false;
        }

        private void btnConfiguration_Click(object sender, EventArgs e)
        {
            using (ConfigurationRecord frm = new ConfigurationRecord())
            {
                frm.PathImage = PathBin + "\\" + PathImage;
                frm.FPS = FPS;
                frm.Quality = Quality;
                if (frm.ShowDialog() == DialogResult.OK)
                    IsChange = true;
            }
        }
    }
}
