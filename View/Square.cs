using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace SaveTheCommunism.View
{
    class Square : Form
    {
        public Square()
        {
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Tile;
        }

        private void DrawStatisticsBar(Graphics graphics)
        {
            var stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Near
            };
            var brush = new SolidBrush(ForeColor);
            var width = ClientSize.Width;
            var height = ClientSize.Height;

            graphics.DrawString("Ammo: ", Font, brush, width / 6, 0, stringFormat);

            graphics.DrawString("Score: ", Font, brush, width / 2, 0, stringFormat);

            graphics.DrawString("Health: ", Font, brush, (width / 6) * 5, 0, stringFormat);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;

            DrawStatisticsBar(graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
