using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SaveTheCommunism.Model;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism
{
    public class RenameMe : Form
    {
        private readonly Image playerImage;
        private readonly Image enemyImage;
        private readonly Player player;
        private readonly List<Enemy> enemies;
        private readonly Timer timer1;
        private readonly Timer timer2;
        private bool right;
        private bool left;
        private bool up;
        private bool down;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            Text = "Use wasd to control player";
            WindowState = FormWindowState.Maximized;
        }

        public RenameMe()
        {
            playerImage = Properties.Resources.player;
            enemyImage = Properties.Resources.enemy;
            BackgroundImage = new Bitmap(Properties.Resources.background, 64, 64);
            BackgroundImageLayout = ImageLayout.Tile;
            enemies = GetEnemies(2, Screen.PrimaryScreen.Bounds.Size - enemyImage.Size);
            player = new Player(10, 2, new Vector(10, 10), new Vector(4, 2), new Vector(1, 1));
            timer1 = new Timer { Interval = 20 };
            timer2 = new Timer { Interval = 50};
            timer1.Tick += Timer1Tick1;
            timer2.Tick += Timer1Tick2;
            timer1.Start();
            timer2.Start();
            KeyPreview = true;
        }

        private void Timer1Tick1(object sender, EventArgs e)
        {
            MovePlayer();
            Invalidate();
            Update();
        }

        private void Timer1Tick2(object sender, EventArgs e)
        {
            foreach (var enemy in enemies)
                enemy.Move(ClientRectangle.Size - enemyImage.Size, player.Position);

            Invalidate();
            Update();
        }

        public void MovePlayer()
        {
            var dir = Character.Directions.None;
            if (right)
                dir = Character.Directions.Right;
            if (left)
                dir = Character.Directions.Left;
            if (up)
                dir = Character.Directions.Up;
            if (down)
                dir = Character.Directions.Down;
            player.Move(dir, ClientRectangle.Size - playerImage.Size);
        }

        private List<Enemy> GetEnemies(int number, Size squareSize)
        {
            var enems = new List<Enemy>();
            var usedPos = new HashSet<Tuple<double, double>>();
            for (var i = 0; i < number; i++)
            {
                var curEnemyPosition = Enemy.GetRandomEnemyPosition(squareSize);
                var curTuple = Tuple.Create(curEnemyPosition.X, curEnemyPosition.Y);
                if (!usedPos.Contains(curTuple))
                {
                    enems.Add(new Enemy(10, 2, curEnemyPosition, new Vector(1, 2), new Vector(2, 1)));
                    usedPos.Add(curTuple);
                }
                else
                    number++;
            }

            return enems;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, true);
        }

        private void HandleKey(Keys e, bool wasDown)
        {
            var keysActions = new Dictionary<Keys, Action>
            {
                {Keys.A, () => left = wasDown },
                {Keys.D, () => right = wasDown },
                {Keys.W, () => up = wasDown },
                {Keys.S, () => down = wasDown },
            };
            if (!keysActions.ContainsKey(e))
                return;
            keysActions[e]();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DrawTo(e.Graphics);
        }

        private void DrawTo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (timer1.Enabled)
            {
                foreach (var enemy in enemies)
                {
                    g.DrawImage(enemyImage, new Point((int) enemy.Position.X, (int) enemy.Position.Y));
                }
                g.DrawImage(playerImage, new Point((int)player.Position.X, (int)player.Position.Y));
            }
        }
    }
}