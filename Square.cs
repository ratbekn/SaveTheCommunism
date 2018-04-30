using System;
using System.Drawing;
using System.Windows.Forms;

namespace SaveTheCommunism
{
    public class Square : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox player;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private Timer timer1;
        private System.ComponentModel.IContainer components;
        private ProgressBar progressBar1;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DoubleBuffered = true;
            Text = "Use W,A,S,D keys to control player";
            WindowState = FormWindowState.Maximized;
        }

        public Square()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.progressBar1 = new ProgressBar();
            this.player = new PictureBox();
            this.pictureBox1 = new PictureBox();
            this.pictureBox2 = new PictureBox();
            this.pictureBox3 = new PictureBox();
            this.pictureBox4 = new PictureBox();
            this.timer1 = new Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = Color.White;
            this.label1.Location = new Point(69, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(76, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ammo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = Color.White;
            this.label2.Location = new Point(302, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(73, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Score";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = Color.White;
            this.label3.Location = new Point(477, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(74, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heath";
            this.label3.Click += new EventHandler(label3_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new Point(557, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new Size(100, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // player
            // 
            this.player.Image = Properties.Resources.player_gun_up;
            this.player.Location = new Point(450, 328);
            this.player.Name = "player";
            this.player.Size = new Size(43, 49);
            this.player.SizeMode = PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = Properties.Resources.enemy_stand_right;
            this.pictureBox1.Location = new Point(96, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(33, 43);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "enemy";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = Properties.Resources.enemy_stand_down;
            this.pictureBox2.Location = new Point(510, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Size(43, 33);
            this.pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "enemy";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = Properties.Resources.enemy_stand_left;
            this.pictureBox3.Location = new Point(759, 420);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new Size(33, 43);
            this.pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "enemy";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = Properties.Resources.enemy_stand_up;
            this.pictureBox4.Location = new Point(392, 461);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new Size(43, 33);
            this.pictureBox4.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Tag = "enemy";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new EventHandler(this.gameEngine);
            // 
            // Square
            // 
            this.ClientSize = new Size(857, 523);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Square";
            this.KeyDown += new KeyEventHandler(this.OnKeyDown);
            this.KeyUp += new KeyEventHandler(this.OnKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        bool goup;
        bool godown;
        bool goleft;
        bool goright;
        string facing = "up";
        double playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int enemySpeed = 3;
        int score = 0;
        bool gameOver = false;
        Random rnd = new Random();

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (e.KeyCode == Keys.A)
            {
                goleft = true;
                facing = "left";
                player.Image = Properties.Resources.player_gun_left;
            }

            if (e.KeyCode == Keys.D)
            {
                goright = true;
                facing = "right";
                player.Image = Properties.Resources.player_gun_right;
            }

            if (e.KeyCode == Keys.W)
            {
                goup = true;
                facing = "up";
                player.Image = Properties.Resources.player_gun_up;
            }

            if (e.KeyCode == Keys.S)
            {
                godown = true;
                facing = "down";
                player.Image = Properties.Resources.player_gun_down;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (gameOver)
                return;

            if (e.KeyCode == Keys.A)
                goleft = false;

            if (e.KeyCode == Keys.D)
                goright = false;

            if (e.KeyCode == Keys.W)
                goup = false;

            if (e.KeyCode == Keys.S)
                godown = false;

            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                Shoot(facing);

                if (ammo < 1)
                    DropAmmo();
            }
        }

        private void DropAmmo()
        {
            PictureBox ammo = new PictureBox();

            ammo.Image = Properties.Resources.ammo;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            ammo.Tag = "ammo";
            this.Controls.Add(ammo);
            ammo.BringToFront();
            player.BringToFront();
        }

        private void Shoot(string direct)
        {
            bullet shoot = new bullet();
            shoot.direction = direct;
            shoot.bulletLeft = player.Left + (player.Width / 2);
            shoot.bulletTop = player.Top + (player.Height / 2);
            shoot.mkBullet(this);
        }

        private void MakeEnemy()
        {
            PictureBox enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = Properties.Resources.enemy_stand_down;
            enemy.Left = rnd.Next(0, 900);
            enemy.Top = rnd.Next(0, 800);
            enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(enemy);
            player.BringToFront();
        }

        private void gameEngine(object sender, EventArgs e)
        {
            if (playerHealth > 1)
            {
                progressBar1.Value = Convert.ToInt32(playerHealth);
            }
            else
            {
                player.Image = Properties.Resources.player_stand_down;
                timer1.Stop();
                gameOver = true;
            }

            label1.Text = " Ammo: " + ammo;
            label2.Text = " Score: " + score;

            if (playerHealth < 20)
                progressBar1.ForeColor = Color.Red;

            if (goleft && player.Left > 0)
                player.Left -= speed;

            if (goright && player.Left + player.Width < 930)
                player.Left += speed;

            if (goup && player.Top > 60)
                player.Top -= speed;

            if (godown && player.Top + player.Height < 700)
                player.Top += speed;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag != null && x.Tag.Equals("ammo"))
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        this.Controls.Remove(((PictureBox)x));

                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if (x is PictureBox && x.Tag != null && x.Tag.Equals("bullet"))
                {
                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 ||
                        ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                    }
                }

                if (x is PictureBox && x.Tag != null && x.Tag.Equals("enemy"))
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(player.Bounds))
                    {
                        playerHealth--;
                    }

                    if (((PictureBox)x).Left > player.Left)
                    {
                        ((PictureBox)x).Left -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.enemy_stand_left;
                    }

                    if (((PictureBox)x).Top > player.Top)
                    {
                        ((PictureBox)x).Top -= enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.enemy_stand_up;
                    }

                    if (((PictureBox)x).Left < player.Left)
                    {
                        ((PictureBox)x).Left += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.enemy_stand_right;
                    }

                    if (((PictureBox)x).Top < player.Top)
                    {
                        ((PictureBox)x).Top += enemySpeed;
                        ((PictureBox)x).Image = Properties.Resources.enemy_stand_down;
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox && j.Tag != null && j.Tag.Equals("bullet")) 
                        && (x is PictureBox && x.Tag != null && x.Tag.Equals("enemy")))
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            j.Dispose();
                            this.Controls.Remove(x);
                            x.Dispose();
                            MakeEnemy();
                        }
                    }
                }
            }
        }
    }
}