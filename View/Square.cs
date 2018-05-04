using SaveTheCommunism.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
            timer.Tick += OnTick;
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

            graphics.DrawString("Ammo: " + Player.Ammo, drawFont, brush, width / 6f, 0, stringFormat);

            graphics.DrawString("Score: " + World.Score, drawFont, brush, width / 2f, 0, stringFormat);

            graphics.DrawString("Health: " + Player.Health, drawFont, brush, (width / 6f) * 5, 0, stringFormat);
        }

        private void DrawEnemies(Graphics graphics)
        {
            var enemies = World.Enemies;
            foreach (var enemy in enemies)
                graphics.DrawImage(Properties.Resources.enemy_stand_up, enemy.Position.ToPoint());
        }

        private void DrawPlayer(Graphics graphics)
        {
            graphics.DrawImage(GetPlayerImage(Player.MoveDirection, Player.HasGun), Player.Position.ToPoint());
        }

        private Bitmap GetPlayerImage(Directions moveDirection, bool hasGun)
        {
            var playerImage = default(Bitmap);
            //выглядит странно
            switch (moveDirection)
            {
                case Directions.Up:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_up : Properties.Resources.player_stand_up;
                    break;
                case Directions.RightUp:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_upright : Properties.Resources.player_stand_upright;
                    break;
                case Directions.Right:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_right : Properties.Resources.player_stand_right;
                    break;
                case Directions.RightDown:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_rightdown : Properties.Resources.player_stand_rightdown;
                    break;
                case Directions.Down:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_down : Properties.Resources.player_stand_down;
                    break;
                case Directions.LeftDown:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_downleft : Properties.Resources.player_stand_downleft;
                    break;
                case Directions.Left:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_left : Properties.Resources.player_stand_left;
                    break;
                case Directions.LeftUp:
                    playerImage = hasGun ? Properties.Resources.player_move_gun_leftup : Properties.Resources.player_stand_leftup;
                    break;
            }

            return playerImage;
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

        private static readonly Dictionary<HashSet<Key>, Directions> DoubleKeys =
            new Dictionary<HashSet<Key>, Directions>
            {
                {new HashSet<Key> {Key.W, Key.A}, Directions.LeftUp},
                {new HashSet<Key> {Key.W, Key.D}, Directions.RightUp},
                {new HashSet<Key> {Key.D, Key.S}, Directions.RightDown},
                {new HashSet<Key> {Key.S, Key.A}, Directions.LeftDown}
            };

        private static readonly Dictionary<Key, Directions> SingleKeys = new Dictionary<Key, Directions>
        {
            {Key.W, Directions.Up},
            {Key.D, Directions.Right},
            {Key.S, Directions.Down},
            {Key.A, Directions.Left}
        };

        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            Debug.WriteLine(Player.Position.ToString());

            foreach (var key in SingleKeys.Keys)
                SetMoveDirection(key);

            Player.IsMoving = true;

            Debug.WriteLine(Player.Position.ToString());
        }

        //rename
        private void SetMoveDirection(Key key)
        {
            if (!Keyboard.IsKeyDown(key))
                return;

            var keysPairs = DoubleKeys.Where(pair => pair.Key.Contains(key));
            Directions? direction = null;
            foreach (var pair in keysPairs)
            {
                foreach (var curKey in pair.Key)
                {
                    if (curKey != key && Keyboard.IsKeyDown(curKey))
                        direction = pair.Value;
                }
            }

            direction = direction ?? SingleKeys[key];
            Player.MoveDirection = direction.Value;
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
                    Player.IsMoving = false;
                    break;
            }
        }
    }
}
