using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    public class Sausage : Shape
    {
        public int State { get; set; }
        private static Image img1 = Resources.sausage_1;
        private static Image img2 = Resources.sausage_2;
        private static Image img3 = Resources.sausage_3;
        public int price
        {
            get
            {
                if (this.State == 1)
                    return 6;
                else if (this.State == 2)
                    return 10;
                else
                    return 5;
            }
        } 

        public Sausage(int x, int y, int width, int height)
            : base(img1, x, y, width, height)
        {
            State = 1;
        }

        public override void Move(float dx, float dy)
        {
            base.Move(dx, dy);
            Game.grill.stopTimer(this);
        }

        public override void MouseUp(Shape s)
        {
            this.X = Selected.X = origX;
            this.Y = Selected.Y = origY;
            Game.grill.startTimer(this);
        }

        public override void MouseUp()
        {
            this.X = Selected.X = origX;
            this.Y = Selected.Y = origY;
            Game.grill.startTimer(this);
        }

        public override Shape Click()
        {
            return null;
        }

        public void changeState()
        {
            if (State == 1)
            {
                this.img = Resources.sausage_2;
            }
            else if (State == 2)
            {
                this.img = Resources.sausage_3;
            }
            else
            {
                return;
            }
            State++;

        }
    }
}
