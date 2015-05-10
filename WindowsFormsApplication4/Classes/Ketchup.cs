using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    class Ketchup : Shape
    {

        public static int price
        {
            get
            {
                return 3;
            }
        }

        public Ketchup(Image img, int x, int y, int width, int height)
            : base(img, x, y, width, height)
        {

        }

        public override void MouseUp(Shape s)
        {
            this.X = Selected.X = origX;
            this.Y = Selected.Y = origY;
            s.MouseUp();
        }

        public override void MouseUp()
        {
            this.X = Selected.X = origX;
            this.Y = Selected.Y = origY;
        }

        public override Shape Click()
        {
            return null;
        }
    }
}
