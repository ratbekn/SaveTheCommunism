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
        private Timer timer;

        private World World { get; set; }
        private Player Player { get; set; }

        public Square()
        {
            ForeColor = Color.White;
            WindowState = FormWindowState.Maximized;
            BackgroundImage = Properties.Resources.background;
            BackgroundImageLayout = ImageLayout.Tile;

            timer = new Timer();
            timer.Interval = 20;
            timer.Tick += new EventHandler(OnTick);
            timer.Start();
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

            graphics.DrawString("Ammo: " + World.Ammo, Font, brush, width / 6, 0, stringFormat);

            graphics.DrawString("Score: " + World.Score, Font, brush, width / 2, 0, stringFormat);

            graphics.DrawString("Health: " + Player.Health, Font, brush, (width / 6) * 5, 0, stringFormat);
        }

        private void DrawEnemies(Graphics graphics)
        {
            var enemies = World.Enemies;
            foreach (var enemy in enemies)
                graphics.DrawImage(Properties.Resources.enemy_stand_up, enemy.Position.ToPoint());
        }
        private void DrawPlayer(Graphics graphics)
        {
            graphics.DrawImage(Properties.Resources.player_move_gun_up, Player.Position.ToPoint());
        }

        private void OnTick(object sender, EventArgs e)
        {
            World.Update();
            World.WorldSize = ClientSize;
            Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            World = World.GetInstance(ClientSize);
            Player = World.Player;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;

            DrawStatisticsBar(graphics);
            DrawPlayer(graphics);
            DrawEnemies(graphics);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            var downedKey = e.KeyCode;
            Debug.WriteLine(Player.Position.ToString());
            if (downedKey == Keys.W)
                Player.MoveDirection = Directions.Up;
            if (downedKey == Keys.D)
                Player.MoveDirection = Directions.RightDown;
            if (downedKey == Keys.S)
                Player.MoveDirection = Directions.Down;
            if (downedKey == Keys.A)
                Player.MoveDirection = Directions.Left;
            Debug.WriteLine(Player.Position.ToString());
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            var uppedKey = e.KeyCode;

            switch (uppedKey)
            {
                case Keys.W:
                case Keys.D:
                case Keys.S:
                case Keys.A:
                    Player.MoveDirection = Directions.None;
                    break;
            }
        }
    }
}
