using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotDogBush.Properties;

namespace HotDogBush
{
    public class Water : Shape
    {
        public static int price { 
            get {
                return 7;
            } 
        }
        public Water(int x, int y, int width, int height)
            : base(Resources.glass, x, y, width, height)
        {

        }

        public override Shape Click()
        {
            return null;
        }

        public override void MouseUp()
        {
            this.X = origX;
            this.Y = origY;
        }

        public override void MouseUp(Shape s)
        {
            s.MouseUp();
        }
    }
}
