using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakOut_Prototype
{
    public class Shapes
    {
        public float posx;
        public float posy;
        public float width;
        public float height;
        //public Color color;
        public uint color;
        public bool isVisible;
    }

    public class Ball : Shapes 
    {
        public float speedx;
        public float speedy;

        public Ball()
        {
            this.posx = 200;
            this.posy = 250;
            this.width = 12;
            this.height = 12;
            this.speedx = 5;
            this.speedy = -5;
            this.color = 0xFFD62828;
            this.isVisible = true;
        }

        public void Move() 
        {
            posx += this.speedx;
            posy += this.speedy;
        }
        public void Bounce(float maxX, float maxY) 
        {
            if ((posx < 0) || (posx + width > maxX)) 
            {
                posx -= speedx;
                speedx = -speedx;
            }
            if (posy < 0) 
            {
                posy -= speedy;
                speedy = -speedy;
            }
            if (posy + height > maxY) 
            {
                //posy -= speedy;
                //speedy = -speedy;
                this.isVisible = false;
            }
        }
    }

    public class Paddle : Shapes
    {
        public float speed;
        public Paddle() 
        {
            this.posx = 400;
            this.posy = 400;
            this.width = 80;
            this.height = 10;
            this.speed = 15;
            this.color =  0xFFF77F00;
            this.isVisible = true;   
        }            
    }

    public class Brick : Shapes
    {
        public Brick(float posx, float posy)
        { 
            this.posx = posx;
            this.posy = posy;
            this.width = 78;
            this.height = 20;
            this.color = 0xFFFCBF49;
            this.isVisible = true;   
        }
        
    }

}
