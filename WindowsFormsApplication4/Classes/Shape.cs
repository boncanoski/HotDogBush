using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HotDogBush
{
    public abstract class Shape : Drawable
    {
        public Image img { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Shape Selected { get; set; }
        public float origX { get; set; }
        public float origY { get; set; }
        public bool draw { get; set; }

        public Shape(Image img, int x, int y, int width, int height)
        {
            this.img = img;
            this.X = this.origX = x;
            this.Y = this.origY = y;
            this.Width = width;
            this.Height = height;
            draw = true;
        }

        public virtual void Draw(Graphics g)
        {
            if (draw)
                g.DrawImage(img, X, Y, Width, Height);
        }

        public Shape IsHovered(float x, float y)
        {
            if (this.X <= x && this.X + Width >= x && this.Y <= y && this.Y + Height >= y)
                return this;
            return null;


        }

        public virtual void Move(float dx, float dy)
        {
            X += dx;
            Y += dy;
        }

        public abstract Shape Click();

        public virtual void MouseUp(Shape s)
        {
            s.MouseUp();
        }

        public virtual void MouseUp()
        {
            this.X = origX;
            this.Y = origY;
            if (this.Selected != null)
            {
                this.Selected.X = origX;
                this.Selected.Y = origY;
            }
        }
    }
}
