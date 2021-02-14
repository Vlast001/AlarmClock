using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlarmClock
{
    public partial class Form1 : Form
    {
        private int H;
        private int M;
        private int S;

        private int h;
        private int m;
        private int s;
        private DateTime currentTime;
        public Form1()
        {
            InitializeComponent();
            turnOffBtn.Enabled = false;
        }

        private void DisplayTime()
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayTime();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DisplayTime();
            currentTime = DateTime.Now;
            h = currentTime.Hour;
            m = currentTime.Minute;
            s = currentTime.Second;
            if (h == H && m == M && s == S)
            {
                string soundPath = Path.GetFullPath(@"..\..\Sounds\Sound.mp3");
                mediaPlayer.URL = soundPath;
                mediaPlayer.Ctlcontrols.play();
                //MessageBox.Show("Время истекло", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FinishCount();
                mediaPlayer.Ctlcontrols.stop();
            }
        }

        private void turnOnBtn_Click(object sender, EventArgs e)
        {
            H = (int) Hours.Value;
            M = (int) Minutes.Value;
            S = (int) Seconds.Value;
            MessageBox.Show("Будильник включен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            turnOnBtn.Enabled = false;
            turnOffBtn.Enabled = true;
        }

        private void FinishCount()
        {
            H = M = S = 0;
            Hours.Value = 0;
            Minutes.Value = 0;
            Seconds.Value = 0;
            MessageBox.Show("Будильник выключен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            turnOnBtn.Enabled = true;
            turnOffBtn.Enabled = false;
        }
        private void turnOffBtn_Click(object sender, EventArgs e)
        {
            FinishCount();
        }
    }
}
