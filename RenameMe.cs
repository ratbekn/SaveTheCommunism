﻿using System;
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
        private readonly Player player;
        private readonly Timer timer;
        private bool right;
        private bool left;
        private bool up;
        private bool down;
        private readonly Size spaceSize = new Size(800, 600);
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
            image = new Bitmap(spaceSize.Width, spaceSize.Height, PixelFormat.Format32bppArgb);
            player = new Player(10, 2, new Vector(10, 10), new Vector(4, 2), new Vector(1, 1));
            timer = new Timer { Interval = 20 };
            timer.Tick += TimerTick;
            timer.Start();
            KeyPreview = true;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            MovePlayer(player);
            Invalidate();
            Update();
        }

        public void MovePlayer(Player player)
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
            player.Move(dir);
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
            e.Graphics.FillRectangle(Brushes.FloralWhite, ClientRectangle);
            var g = Graphics.FromImage(image);
            DrawTo(g);
            e.Graphics.DrawImage(image, (ClientRectangle.Width - image.Width) / 2, (ClientRectangle.Height - image.Height) / 2);
        }

        private void DrawTo(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillRectangle(Brushes.White, ClientRectangle);

            if (timer.Enabled)
            { 
                g.DrawImage(playerImage, new Point((int)player.Position.X, (int)player.Position.Y));
            }
        }
    }
}