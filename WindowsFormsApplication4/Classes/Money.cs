using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HotDogBush
{
    public class Money : Shape
    {
        public int money { get; set; }
        private Point location;

        public Money(Point p, int price)
            : base(null, 0, 0, 0, 0)
        {
            this.location = p;
            this.money = price;
        }

        public override void Draw(Graphics g)
        {
            RectangleF rectf = new RectangleF(location, new Size(60, 20));
            g.DrawString(money + "$", new Font("Tahoma", 15), Brushes.White, rectf);
        }

        public override Shape Click()
        {
            return null;
        }

        
    }
}
