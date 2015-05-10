using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;


namespace HotDogBush
{
    class Trash : Shape
    {
        private static Image img1 = Resources.trash;
        public Trash(int x, int y, int width, int height)
            : base(img1, x, y, width, height)
        {

        }

        public override void MouseUp(Shape s)
        {
            if (s is Sausage)
            {
                Game.removeShape(s);
                Sausage sausage = (Sausage)s;
                Game.grill.removeSausage(sausage);
                Game.showPrice(new Point((int)this.X+this.Width/2, (int)this.Y), (int)(sausage.price*0.3*(-1)));

            }
            else if (s is Bread)
            {
                Game.removeShape(s);
                Game.table.removeBread(s);
                Game.showPrice(new Point((int)this.X + this.Width / 2, (int)this.Y), (int)(((Bread)s).price * 0.3 * (-1)));
            }
            else
                s.MouseUp();
        }

        public override Shape Click()
        {
            return null;
        }

    }
}
