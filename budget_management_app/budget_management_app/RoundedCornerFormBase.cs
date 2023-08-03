using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace budget_management_app
{
    public class RoundedCornerFormBase:Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private const int cornerRadius = 20;

        public RoundedCornerFormBase()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += RoundedCornerFormBase_Load;
        }

        private void RoundedCornerFormBase_Load(object sender, EventArgs e)
        {
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, cornerRadius, cornerRadius));
        }
    }
}
