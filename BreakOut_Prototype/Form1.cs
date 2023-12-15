using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut_Prototype
{
    public partial class BreakOutGame : Form
    {
        private List<Brick> bricks;
        Ball ball = new Ball();
        Paddle paddle = new Paddle();
        PowerUp powerup = new PowerUp();
        private List<PowerUp> powerups;
        Bitmap canvasBitmap;
        Bitmap workingBitmap;
        Graphics workingGraphics;

        Random rnd = new Random();

        bool gameover;
        bool levelUp;
        bool goleft;
        bool goright;

        uint Bg_color = 0xFF264653;
        uint uibg_color = 0xFF287271;
        uint Bg_lbl = 0xFFF4A261;

        int score;
        int lvl = 01;
        public BreakOutGame()
        {
            InitializeComponent();

            bricks = new List<Brick>();
            powerups = new List<PowerUp>();

            SetLevel(2);
        }

        public void SetLevel(int level)
        {
            bricks.Clear();

            gameover = false;
            levelUp = false;

            //Random rnd = new Random();

            ball.posx = rnd.Next(700);
            ball.speedx = rnd.Next(4, 7);
            ball.speedy = -rnd.Next(4, 7);

            paddle.posx = rnd.Next(600);
            paddle.speed = 15;

            for (int lvl = 0; lvl < level; lvl++)
            {
                for (int i = 0; i < 10; i++)
                {
                    Brick brk = new Brick(i * 78 + 3, lvl * 20 + 2);
                    bricks.Add(brk);
                }
            }

            timer.Start();
        }

        public void DrawCanvas()
        {
            BackColor = Color.FromArgb((int)Bg_color);
            lbl_score.BackColor = Color.FromArgb((int)Bg_color);
            lbl_level.BackColor = Color.FromArgb((int)Bg_color);
            lbl_retry.BackColor = Color.FromArgb((int)uibg_color);
            lbl_quit.BackColor = Color.FromArgb((int)uibg_color);
            lbl_nl.BackColor = Color.FromArgb((int)uibg_color);
            lbl_score02.BackColor = Color.FromArgb((int)uibg_color);
            lbl_score.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_level.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_retry.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_quit.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_nl.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_score02.ForeColor = Color.FromArgb((int)Bg_lbl);

            canvasBitmap = new Bitmap(pic_canvas.Width, pic_canvas.Height);
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < bricks.Count; i++)
            {
                Brush brush = new SolidBrush(Color.FromArgb((int)bricks[i].color));
                if (bricks[i].isVisible)
                    workingGraphics.FillRectangle(brush, new Rectangle(Convert.ToInt32(bricks[i].posx), Convert.ToInt32(bricks[i].posy + 40), Convert.ToInt32(bricks[i].width) - 2, Convert.ToInt32(bricks[i].height) - 2));
            }

            if (ball.isVisible)
            {
                Brush brush = new SolidBrush(Color.FromArgb((int)ball.color));
                workingGraphics.FillEllipse(brush, new Rectangle(Convert.ToInt32(ball.posx), Convert.ToInt32(ball.posy), Convert.ToInt32(ball.width), Convert.ToInt32(ball.height)));
            }

            if (paddle.isVisible)
            {
                Brush brush = new SolidBrush(Color.FromArgb((int)paddle.color));
                workingGraphics.FillRectangle(brush, new Rectangle(Convert.ToInt32(paddle.posx), Convert.ToInt32(paddle.posy), Convert.ToInt32(paddle.width), Convert.ToInt32(paddle.height)));
            }

            /*if (powerup.isVisible)
            {
                Brush brush = new SolidBrush(Color.FromArgb((int)powerup.color));
                workingGraphics.FillRectangle(brush, new Rectangle(0, 0, 5, 5));
            }*/

            pic_canvas.Image = workingBitmap;
        }

        /*private void PaddleCollision()
        {
            if (ball.posy + ball.height >= paddle.posy && ball.posy <= paddle.posy)
            {

                if (ball.posx + ball.width > paddle.posx && ball.posx < paddle.posx + paddle.width)
                {
                    ball.posy -= ball.speedy;
                    ball.speedy = -ball.speedy;
                }
            }
        }*/
        private void PaddleCollision()
        {
            // Çarpışmayı kontrol et
            if (ball.posy + ball.height >= paddle.posy && ball.posy <= paddle.posy + paddle.height &&
                ball.posx + ball.width > paddle.posx && ball.posx < paddle.posx + paddle.width)
            {
                // Topun hızını güncelle
                ball.posy -= ball.speedy;
                ball.speedy = -ball.speedy;

                // Topun yeni konumu paletin içinde mi kontrol et
                if (ball.posy + ball.height > paddle.posy)
                {
                    // Topun konumunu paletin dışına çıkar
                    ball.posy = paddle.posy - ball.height;
                }
            }
        }
        private void BrickCollision()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isVisible)
                {
                    bool isColl = false;

                    if (ball.posx + ball.width > bricks[i].posx && ball.posx < bricks[i].posx + bricks[i].width)
                    {
                        if (ball.posy + ball.height > bricks[i].posy + 40 && ball.posy < bricks[i].posy + 40 + bricks[i].height)
                        {
                            // Top, tuğlanın üst veya alt kenarına çarptı
                            isColl = true;
                            ball.posy -= ball.speedy;
                            ball.speedy = -ball.speedy;
                        }
                    }

                    if (ball.posy + ball.height > bricks[i].posy + 40 && ball.posy < bricks[i].posy + 40 + bricks[i].height)
                    {
                        if (ball.posx + ball.width > bricks[i].posx && ball.posx < bricks[i].posx + bricks[i].width)
                        {
                            // Top, tuğlanın sağ veya sol kenarına çarptı
                            isColl = true;
                            ball.posx -= ball.speedx;
                            ball.speedx = -ball.speedx;
                        }
                    }

                    if (ball.posx + ball.width > bricks[i].posx && ball.posx < bricks[i].posx + bricks[i].width &&
                        ball.posy + ball.height > bricks[i].posy + 40 && ball.posy < bricks[i].posy + 40 + bricks[i].height)
                    {
                        isColl = true;
                        ball.posy -= ball.speedy;
                        ball.speedy = -ball.speedy;
                        ball.posx -= ball.speedx;
                        ball.speedx = -ball.speedx;
                    }

                    if(isColl)
                    {
                        bricks[i].isVisible = false;
                        score++;
                    }
                    

                }                           
            }            
        }

        /*private void HandleCollision(int i, bool hitHorizontal, bool hitVertical)
        {
            bricks[i].isVisible = false;
            score++;

            if (hitHorizontal)
            {
                ball.posy -= ball.speedy;
                ball.speedy = -ball.speedy;
            }

            if (hitVertical)
            {
                ball.posx -= ball.speedx;
                ball.speedx = -ball.speedx;
            }
        }*/

        /*private void BrickCollision()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isVisible)
                {
                    bool hitHorizontal = ball.posx + ball.width > bricks[i].posx && ball.posx < bricks[i].posx + bricks[i].width;
                    bool hitVertical = ball.posy + ball.height > bricks[i].posy + 40 && ball.posy < bricks[i].posy + 40 + bricks[i].height;

                    if (hitHorizontal && hitVertical)
                    {
                        HandleCollision(i, hitHorizontal, hitVertical);
                    }
                }                
            }
        } */

        private void GameOver()
        {
            if (ball.isVisible == false)
            {
                gameover = true;
                timer.Stop();
                lbl_quit.Visible = true;
                lbl_retry.Visible = true;
            }
        }

        public void ResetAndRestartGame()
        {
            ball.posx = 200;
            ball.posy = 250;
            ball.speedx = 5;
            ball.speedy = -5;
            ball.isVisible = true;

            paddle.posx = 400;
            paddle.posy = 400;

            score = 0;

            lbl_quit.Visible = false;
            lbl_retry.Visible = false;

            SetLevel(2);
        }

        private void LevelUp()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isVisible == false && gameover == false && score == bricks.Count)
                {
                    timer.Stop();
                    lbl_nl.Visible = true;
                    lbl_quit.Visible = true;
                    lbl_score02.Text = "SCORE: " + score;
                    lbl_score02.Visible = true;
                    levelUp = true;
                }
            }
        }

        private void ResetForNextLevel()
        {
            lbl_nl.Visible = false;
            lbl_quit.Visible = false;
            lbl_score02.Visible = false;

            ball.posx = 200;
            ball.posy = 250;
            ball.speedx = 5;
            ball.speedy = -5;
            ball.isVisible = true;

            paddle.posx = 400;
            paddle.posy = 400;

            score = 0;
            lvl += 1;
            int level = lvl + 2;
            SetLevel((int)level);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (goleft == true && paddle.posx > 0)
            {
                paddle.posx -= paddle.speed;
            }

            if (goright == true && paddle.posx + paddle.width < pic_canvas.Width)
            {
                paddle.posx += paddle.speed;
            }

            /*for (int i = 0; i < bricks.Count; i++)
            {
                bricks[i].powerUpBrick = rnd.NextDouble() < 0.1;
                powerups.Add(powerup);
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                if (!bricks[i].isVisible) 
                {                    
                     powerup.posx = bricks[i].posx;
                     powerup.posy = bricks[i].posy;
                     powerup.speedy = 3;
                     powerup.isVisible = true;
                     canvasBitmap = new Bitmap(pic_canvas.Width, pic_canvas.Height);
                     workingBitmap = new Bitmap(canvasBitmap);
                     workingGraphics = Graphics.FromImage(workingBitmap);

                    if (powerup.isVisible)
                    {
                        Brush brush = new SolidBrush(Color.FromArgb((int)powerup.color));
                        workingGraphics.FillRectangle(brush, new Rectangle(Convert.ToInt32(bricks[i].posx), Convert.ToInt32(bricks[i].posy + 40), 5, 5));
                    }

                    pic_canvas.Image = workingBitmap;
                    //powerups.Add(powerup);                    
                }
            }

            if(powerup.isVisible == true)
            {
                powerup.Move();

                if (powerup.posx + powerup.height == paddle.posx)
                {
                    score += 100;
                }
            }*/

            lbl_score.Text = Convert.ToString(score);
            lbl_level.Text = Convert.ToString(lvl);

            ball.Move();
            ball.Bounce(pic_canvas.Width, pic_canvas.Height);
            
            PaddleCollision();
            BrickCollision();
            LevelUp();
            GameOver();
            DrawCanvas();
        }

        private void BreakOutGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goleft = true;
                    break;
                case Keys.Right:
                    goright = true;
                    break;
                default:
                    return;
            }
        }

        private void BreakOutGame_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goleft = false;
                    break;
                case Keys.Right:
                    goright = false;
                    break;
                default:
                    return;
            }
        }

        private void lbl_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbl_retry_Click(object sender, EventArgs e)
        {
            ResetAndRestartGame();
        }

        private void lbl_nl_Click(object sender, EventArgs e)
        {
            ResetForNextLevel();
        }
    }
       


}
