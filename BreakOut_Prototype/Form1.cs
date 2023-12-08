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
        Bitmap canvasBitmap;
        Bitmap workingBitmap;
        Graphics workingGraphics;
        bool gameover;
        bool goleft;
        bool goright;

        uint Bg_color = 0xFF003049;
        uint Bg_lbl = 0xFFEAE2B7;

        int score;
        int level = 01;
        public BreakOutGame()
        {
            InitializeComponent();

            bricks = new List<Brick>();
            //canvasBitmap = new Bitmap(pic_canvas.Width, pic_canvas.Height);
            //pic_canvas.Image = canvasBitmap;

            SetLevel(5);
        }

        public void SetLevel(int level)
        {
            bricks.Clear();

            gameover = false;

            Random rnd = new Random();

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
            lbl_score.ForeColor = Color.FromArgb((int)Bg_lbl);
            lbl_level.ForeColor = Color.FromArgb((int)Bg_lbl);

            canvasBitmap = new Bitmap(pic_canvas.Width, pic_canvas.Height);
            workingBitmap = new Bitmap(canvasBitmap);
            workingGraphics = Graphics.FromImage(workingBitmap);

            for (int i = 0; i < bricks.Count; i++)
            {
                Brush brush = new SolidBrush(Color.FromArgb((int)bricks[i].color));
                if (bricks[i].isVisible)
                    workingGraphics.FillRectangle(brush, new Rectangle(Convert.ToInt32(bricks[i].posx), Convert.ToInt32(bricks[i].posy +40 ), Convert.ToInt32(bricks[i].width) - 2, Convert.ToInt32(bricks[i].height) - 2));
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

            pic_canvas.Image = workingBitmap;
        }

        private void PaddleCollision()
        {
            if (ball.posy + ball.height + ball.speedy >= paddle.posy) 
            {

                if (ball.posx + ball.width > paddle.posx && ball.posx < paddle.posx + paddle.width)
                {
                    ball.posy -= ball.speedy;
                    ball.speedy = -ball.speedy;
                }
            }

        }

        private void BrickCollision() 
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isVisible && (ball.posy < (bricks[i].posy + bricks[i].height)) || ((ball.posy + ball.height) > bricks[i].posy))
                {                    
                    if ((bricks[i].posx < (ball.posx + ball.width)) || ((ball.posx + ball.width) < (bricks[i].posx + bricks[i].width)))
                    {
                        //bricks[i].isVisible = false;
                        ball.speedy = -ball.speedy;
                        score++;
                    }                                                     
                }
            }
        }
        private void GameOver() 
        {
            if (ball.isVisible == false) 
            {
                gameover = true;
                timer.Stop();
                MessageBox.Show("Game Over    " + score);
            }           
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

            lbl_score.Text = Convert.ToString(score);
            lbl_level.Text = Convert.ToString(level);

            ball.Move();
            ball.Bounce(pic_canvas.Width, pic_canvas.Height);
            DrawCanvas();
            PaddleCollision();
            BrickCollision();
            GameOver();
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
            switch(e.KeyCode)
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

        

        

    }


}
