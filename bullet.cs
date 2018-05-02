using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaveTheCommunism
{
    class Bullet
    {
        public string Direction;
        public int Speed = 20;
        PictureBox bullet = new PictureBox();
        Timer timer = new Timer();

        public int BulletLeft;
        public int BulletTop;

        public void mkBullet(Form form)
        {
            bullet.BackColor = Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = BulletLeft;
            bullet.Top = BulletTop;
            bullet.BringToFront();
            form.Controls.Add(bullet);

            timer.Interval = Speed;
            timer.Tick += new EventHandler(tm_Tick);
            timer.Start();
        }

        public void tm_Tick(object sender, EventArgs e)
        {
            if (Direction == "left")
                bullet.Left -= Speed;

            if (Direction == "right")
                bullet.Left += Speed;

            if (Direction == "up")
                bullet.Top -= Speed;

            if (Direction == "down")
                bullet.Top += Speed;

            if (bullet.Left < 16 || bullet.Left > 860 || bullet.Top < 10 || bullet.Top > 616)
            {
                timer.Stop();
                timer.Dispose();
                bullet.Dispose();
                timer = null;
                bullet = null;
            }
        }
    }
}
