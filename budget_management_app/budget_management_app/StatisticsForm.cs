using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace budget_management_app
{
    public partial class StatisticsForm : Form
    {
        bool bottombarExpand;

        DateTime currentDate = DateTime.Today;
        int selectedDay;
        int selectedMonth;
        int selectedYear;

        public StatisticsForm()
        {
            InitializeComponent();
        }
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            selectedDay = currentDate.Day;
            selectedMonth = currentDate.Month;
            selectedYear = currentDate.Year;
        }

        private void label_exit_Click(object sender, EventArgs e)
        {
            HomeForm home=new HomeForm();
            home.Show();
            this.Hide();
        }

        private void label_exit_MouseEnter(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.FromArgb(212, 148, 85);
        }

        private void label_exit_MouseLeave(object sender, EventArgs e)
        {
            label_exit.ForeColor = Color.White;
        }

        private void UpdateSelectedDate(int daysOffset)
        {
            DateTime selectedDate = currentDate.AddDays(-daysOffset);
            selectedDay = selectedDate.Day;
            selectedMonth = selectedDate.Month;
            selectedYear = selectedDate.Year;

            if (selectedMonth < 1)
            {
                selectedMonth += 12;
                selectedYear--;
            }
            else if (selectedMonth > 12)
            {
                selectedMonth -= 12;
                selectedYear++;
            }

            int daysInSelectedMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            if (selectedDay > daysInSelectedMonth)
            {
                selectedDay = daysInSelectedMonth;
            }
        }

        private void button_7D_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate(7);
        }

        private void button_30D_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate(30);
        }

        private void button_12W_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate(12*7);
        }

        private void button_6M_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate(6*30);
        }

        private void button_1Y_Click(object sender, EventArgs e)
        {
            UpdateSelectedDate(365);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new Size(50, 40);
            pictureBox_bottomBar.Location = new Point(191, -9);
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox_bottomBar.Size = new Size(50, 31);
            pictureBox_bottomBar.Location = new Point(191, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer_bottomBar.Start();
        }

        private void timer_bottomBar_Tick(object sender, EventArgs e)
        {
            if (bottombarExpand)
            {
                panel_bottomBar.Location = new Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y + 10);
                panel_bottomBar.Height -= 10;
                if (panel_bottomBar.Height == panel_bottomBar.MinimumSize.Height)
                {
                    bottombarExpand = false;
                    timer_bottomBar.Stop();
                }
            }
            else
            {
                panel_bottomBar.Location = new Point(panel_bottomBar.Location.X, panel_bottomBar.Location.Y - 10);
                panel_bottomBar.Height += 10;
                if (panel_bottomBar.Height == panel_bottomBar.MaximumSize.Height)
                {
                    bottombarExpand = true;
                    timer_bottomBar.Stop();
                }
            }
        }

    }
}
