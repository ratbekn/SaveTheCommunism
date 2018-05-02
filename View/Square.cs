using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using SaveTheCommunism.Model;

namespace SaveTheCommunism.View
{
    class Square : Form
    {
        private World World { get; set; }

        public Square()
        {
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Tile;

            World = new World(ClientSize);
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

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            var moveDirection = Directions.None;
            var downedKey = e.KeyCode;

            switch (downedKey)
            {
                case Keys.W:
                    moveDirection = Directions.Up;
                    break;
                case Keys.D:
                    moveDirection = Directions.Right;
                    break;
                case Keys.S:
                    moveDirection = Directions.Down;
                    break;
                case Keys.A:
                    moveDirection = Directions.Left;
                    break;
            }
            World.Player.MoveDirection = moveDirection;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }
    }
}
