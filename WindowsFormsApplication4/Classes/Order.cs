using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    public class Order : Shape
    {
        public bool Sausage = false;
        public bool Ketchup = false;
        public bool Glass = false;

        public Order(Image img, int x, int y, int width, int height)
            : base(img, x, y, width, height)
        {

        }

        public Order(Order order)
            : base(order.img, (int)order.X, (int)order.Y, order.Width, order.Height)
        {
            this.Sausage = order.Sausage;
            this.Ketchup = order.Ketchup;
            this.Glass = order.Glass;
        }

        public override Shape Click()
        {
            return null;
        }

        public void changePicture(Shape s)
        {
            if (s is Bread)
            {
                if (Glass)
                    this.img = Resources.order5;
            }
            else if (s is Drinks)
            {
                if (Ketchup && Sausage)
                    this.img = Resources.order1;
                else if (Sausage)
                    this.img = Resources.order2;
            }

        }

    }
}
