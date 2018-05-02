using SaveTheCommunism.Model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;

namespace SaveTheCommunism.View
{
    internal class Square : Form
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
            var drawFont = new Font("Arial", 16);

            graphics.DrawString("Ammo: " + World.Ammo, drawFont, brush, width / 6, 0, stringFormat);

            graphics.DrawString("Score: " + World.Score, drawFont, brush, width / 2, 0, stringFormat);

            graphics.DrawString("Health: " + Player.Health, drawFont, brush, (width / 6) * 5, 0, stringFormat);
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

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Debug.WriteLine(Player.Position.ToString());

            if (Keyboard.IsKeyDown(Key.W))
            {
                if (Keyboard.IsKeyDown(Key.A))
                    Player.MoveDirection = Directions.LeftUp;
                else if (Keyboard.IsKeyDown(Key.D))
                    Player.MoveDirection = Directions.UpRight;
                else
                    Player.MoveDirection = Directions.Up;
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                if (Keyboard.IsKeyDown(Key.W))
                    Player.MoveDirection = Directions.UpRight;
                else if (Keyboard.IsKeyDown(Key.S))
                    Player.MoveDirection = Directions.RightDown;
                else
                    Player.MoveDirection = Directions.Right;
            }

            if (Keyboard.IsKeyDown(Key.S))
            {
                if (Keyboard.IsKeyDown(Key.A))
                    Player.MoveDirection = Directions.DownLeft;
                else if (Keyboard.IsKeyDown(Key.D))
                    Player.MoveDirection = Directions.RightDown;
                else
                    Player.MoveDirection = Directions.Down;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                if (Keyboard.IsKeyDown(Key.W))
                    Player.MoveDirection = Directions.LeftUp;
                else if (Keyboard.IsKeyDown(Key.S))
                    Player.MoveDirection = Directions.DownLeft;
                else
                    Player.MoveDirection = Directions.Left;
            }

            Debug.WriteLine(Player.Position.ToString());
        }

        protected override void OnKeyUp(System.Windows.Forms.KeyEventArgs e)
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
