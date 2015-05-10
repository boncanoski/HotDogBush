using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    class Bread : Shape
    {
        public bool hasSausage { get; set; }
        public bool hasKetchup { get; set; }
        private static Image img1 = Resources.bread1;
        private static Image img2 = Resources.bread2;
        private static Image img3 = Resources.bread3;
        private static Image img4 = Resources.bread4;
        public int price { get; set; }


        public Bread(int x, int y, int width, int height)
            : base(img1, x, y, width, height)
        {
            hasSausage = hasKetchup = false;
            price = 10;
        }

        public override void MouseUp(Shape s)
        {
            //this.X = origX;
            //this.Y = origY;

            if (s is Sausage && !hasSausage)
            {
                Sausage sausage = (Sausage)s;
                Game.grill.removeSausage(sausage);
                Game.removeShape(s);
                hasSausage = true;

                changePicture();
                price += sausage.price;
            }
            else if (s is Ketchup && !hasKetchup)
            {
                hasKetchup = true;
                ((Ketchup)s).MouseUp();

                changePicture();
            }
            else
                s.MouseUp();
        }

        private void changePicture()
        {
            if (hasKetchup && hasSausage)
                this.img = img3;
            else if (hasSausage)
                this.img = img2;
            else if (hasKetchup)
                this.img = img4;
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
    }

}
