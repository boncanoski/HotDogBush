using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace HotDogBush
{
    public class Person : Shape
    {
        private Image happyFace;
        private Image sadFace;
        public Point moveTo { get; set; }
        public bool ShouldMove { get; set; }
        public Order order { get; set; }
        private bool payHotDog;
        private bool payKetchup;
        private bool payWater;
        private int toPay;

        private enum STATE
        {
            gettingin,
            waiting,
            leaving
        }
        private STATE state;

        public Person(Image happy, Image sad, int x, int y, int width, int height)
            : base(happy, x, y, width, height)
        {
            this.happyFace = happy;
            this.sadFace = sad;
            ShouldMove = true;
            state = STATE.gettingin;
            payHotDog = payKetchup = payWater = false;
            toPay = 0;
        }

        public override Shape Click()
        {
            return null;
        }

        public override void MouseUp(Shape s)
        {
            if (s is Bread)
            {
                Bread b = (Bread)s;
                if (!b.hasSausage || !order.Sausage || payHotDog)
                    b.MouseUp();
                else
                {
                    payHotDog = true;
                    toPay += b.price;
                    if (b.hasKetchup && order.Ketchup)
                    {
                        payKetchup = true;
                        toPay += Ketchup.price;
                    }
                    else if (order.Ketchup && !b.hasKetchup)
                        toPay -= 2;
                    order.changePicture(b);
                    Game.removeShape(s);
                    Game.table.removeBread(s);

                }
                checkOrderCompleted();
            }
            else
                if (s is Drinks)
                {
                    if (!order.Glass || payWater)
                        s.MouseUp();
                    else
                    {
                        payWater = true;
                        toPay += Water.price;
                        s.MouseUp();
                        order.changePicture(s);
                        checkOrderCompleted();
                    }

                }
                else
                    s.MouseUp();
        }

        public override void MouseUp()
        {

        }

        private void checkOrderCompleted()
        {
            if (this.payHotDog == order.Sausage && this.payWater == order.Glass)
            {
                Game.removeShape(order);
                this.state = STATE.leaving;
                this.toHappyFace();
                Game.customers.stopTimer(this);
                this.moveTo = new Point(700, (int)this.Y);
                this.ShouldMove = true;
                int ind = Game.customers.getIndex(this);
                Point coinsPoint = Game.customers.coinsList[ind];
                Coins coins = new Coins(coinsPoint.X, coinsPoint.Y);
                coins.money = toPay;
                Game.addShape(coins);
            }
        }

        public void toHappyFace()
        {
            this.img = happyFace;
        }

        public void toSadFace()
        {
            this.img = sadFace;
        }

        public void MoveTo()
        {
            if (this.moveTo != new Point((int)this.X, (int)this.Y))
            {
                this.Move(2, 0);
                ShouldMove = true;
            }
            else
            {
                if (this.state == STATE.gettingin)
                {
                    state = STATE.waiting;
                    Game.addShape(this.order);
                    Game.customers.activateTimer(this);
                }
                else if (state == STATE.leaving)
                {
                    Game.customers.removeCustomer(this);
                    Game.removeShape(this);
                }
                ShouldMove = false;
            }
        }
    }
}
