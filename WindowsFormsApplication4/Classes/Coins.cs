using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotDogBush.Properties;
using System.Drawing;

namespace HotDogBush
{
    public class Coins : Shape
    {
        public int money { get; set; }
        public Coins(int x, int y)
            : base(Resources.coins, x, y, 79, 66)
        {
            money = 0;
        }

        public override Shape Click()
        {
            Game.showPrice(new Point((int)this.X + this.Width / 2, (int)this.Y), money);
            Game.customers.makeFree(new Point((int)this.X, (int)this.Y));
            Game.removeShape(this);
            return null;
        }

        public override void MouseUp(Shape s)
        {
            s.MouseUp();
        }
    }
}
