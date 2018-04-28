using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using SaveTheCommunism.Utilities;

namespace SaveTheCommunism
{
    public class GameForm : Form
    {
        private readonly Image player;
        private readonly Timer timer;
        private bool right;
        private bool left;
        private bool up;
        private bool down;
        private readonly Size spaceSize = new Size(800, 600);
        private readonly Image image;
        private int iterationIndex;
        private string helpText;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            helpText = "Use wasd to control player";
            Text = helpText;
            WindowState = FormWindowState.Maximized;
        }

        public GameForm()
        {
            player = Image.FromFile("C:\\Users\\Света\\Desktop\\Save the communism\\SaveTheCommunism\\images\\player.png");
            //target = Image.FromFile("images/target.png");
            image = new Bitmap(spaceSize.Width, spaceSize.Height, PixelFormat.Format32bppArgb);
            timer = new Timer { Interval = 20 };
            timer.Tick += TimerTick;
            timer.Start();
            var top = 10;
            //var link = new LinkLabel
            //{
            //    Left = 10,
            //    Top = top,
            //    BackColor = Color.Transparent
            //};
            //link.LinkClicked += (sender, args) => ChangeLevel(level);
            //link.Parent = this;
            //Controls.Add(link);
            //top += link.PreferredHeight + 10;
            KeyPreview = true;
        }

        //private void ChangeLevel(Level newSpace)
        //{
        //    currentLevel = newSpace;
        //    currentLevel.Reset();
        //    timer.Start();
        //    iterationIndex = 0;
        //}

        private void TimerTick(object sender, EventArgs e)
        {
            //if (currentLevel == null) return;
            //MoveRocket();
            //if (currentLevel.IsCompleted)
            //    timer.Stop();
            //else
            Text = helpText;/* + ". Iteration # " + iterationIndex++;*/
            Invalidate();
            Update();
        }

        //private void MoveRocket()
        //{
        //    var control = left ? Turn.Left : (right ? Turn.Right : Turn.None);
        //    if (control == Turn.None)
        //        control = ControlTask.ControlRocket(currentLevel.Rocket, currentLevel.Target);
        //    currentLevel.Move(spaceSize, control);
        //}

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, true);
        }

        private void HandleKey(Keys e, bool down)
        {
            if (e == Keys.A)
                left = down;
            if (e == Keys.D)
                right = down;
            if (e == Keys.W)
                up = down;
            if (e == Keys.S)
                this.down = down;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            HandleKey(e.KeyCode, false);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.FloralWhite, ClientRectangle);
            var g = Graphics.FromImage(image);
            DrawTo(g);
            e.Graphics.DrawImage(image, (ClientRectangle.Width - image.Width) / 2, (ClientRectangle.Height - image.Height) / 2);
        }

        private void DrawTo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(Brushes.White, ClientRectangle);

            //if (currentLevel == null) return;

            //DrawGravity(g);
            var matrix = g.Transform;
            g.DrawImage(player, new Point(20, 20));
            //g.TranslateTransform((float)currentLevel.Target.X, (float)currentLevel.Target.Y);
            //g.DrawImage(target, new Point(-target.Width / 2, -target.Height / 2));

            //if (timer.Enabled)
            //{
            //    g.Transform = matrix;
            //    g.TranslateTransform((float)currentLevel.Rocket.Location.X, (float)currentLevel.Rocket.Location.Y);
            //    g.RotateTransform(90 + (float)(currentLevel.Rocket.Direction * 180 / Math.PI));
            //    g.DrawImage(player, new Point(-player.Width / 2, -player.Height / 2));
            //}
        }

        //private void DrawGravity(Graphics g)
        //{
        //    Action<Vector, Vector> draw = (a, b) => g.DrawLine(Pens.DeepSkyBlue, (int)a.X, (int)a.Y, (int)b.X, (int)b.Y);
        //    for (int x = 0; x < spaceSize.Width; x += 50)
        //        for (int y = 0; y < spaceSize.Height; y += 50)
        //        {
        //            var p1 = new Vector(x, y);
        //            var v = currentLevel.Gravity(spaceSize, p1);
        //            if (double.IsInfinity(v.X) || double.IsInfinity(v.Y))
        //                continue;
        //            var p2 = p1 + 20 * v;
        //            var end1 = p2 - 8 * v.Rotate(0.5);
        //            var end2 = p2 - 8 * v.Rotate(-0.5);
        //            draw(p1, p2);
        //            draw(p2, end1);
        //            draw(p2, end2);
        //        }
        //}
    }
}
