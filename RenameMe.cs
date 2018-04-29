using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private readonly Timer timer;
        private bool right;
        private bool left;
        private bool up;
        private bool down;
        private readonly Image image;
        private string helpText;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            Text = "Use wasd to control player";
            WindowState = FormWindowState.Maximized;
        }

        public RenameMe()
        {
            //пофикси, чтобы путь был относительный
            playerImage = new Bitmap(Image.FromFile("C:/Users/Света/Desktop/Save the communism/SaveTheCommunism/images/player.png"), 150, 150);
            enemyImage = new Bitmap(Image.FromFile("C:/Users/Света/Desktop/Save the communism/SaveTheCommunism/images/enemy.png"), 100, 100);
            image = new Bitmap(Image.FromFile(
                "C:\\Users\\Света\\Desktop\\Save the communism\\SaveTheCommunism\\images\\background.png"));
            enemies = GetEnemies(2);
            player = new Player(10, 2, new Vector(10, 10), new Vector(4, 2), new Vector(1, 1));
            timer = new Timer { Interval = 20 };
            timer.Tick += TimerTick;
            timer.Start();
            KeyPreview = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            MovePlayer();
            foreach (var enemy in enemies)
                enemy.Move(ClientRectangle.Size);

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

        private List<Enemy> GetEnemies(int number)
        {
            var enems = new List<Enemy>();
            var usedPos = new HashSet<Tuple<double, double>>();
            for (var i = 0; i < number; i++)
            {
                var curEnemyPosition = Enemy.GetRandomEnemyPosition(ClientRectangle.Size);
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
            g.DrawImage(image, 0, 0, ClientRectangle.Width, ClientRectangle.Height);

            if (timer.Enabled)
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