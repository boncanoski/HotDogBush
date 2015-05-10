using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HotDogBush
{
    public class CustomersPositions
    {
        private List<bool> free;
        private List<Point> positions;
        private List<Point> orderPositions;
        private List<Shape> list;
        private List<Timer> timers;
        private const int spots = 5;
        private PersonList personList;
        private int freeSpots;
        public Timer moveTimer { get; set; }
        private OrderList orderList;
        public List<Point> coinsList { get; set; }

        public CustomersPositions()
        {
            free = new List<bool>();
            personList = new PersonList();
            positions = new List<Point>();
            timers = new List<Timer>();
            list = new List<Shape>();
            orderList = new OrderList();
            orderPositions = new List<Point>();
            coinsList = new List<Point>();

            freeSpots = 5;

            moveTimer = new Timer();
            moveTimer.Interval = 7;
            moveTimer.Tick += moveTimer_Tick;
            for (int i = 0; i < spots; i++)
            {
                free.Add(true);
                positions.Add(new Point(116 * i + 10, 65));
                orderPositions.Add(new Point(115 * i - 5, -5));
                coinsList.Add(new Point(110 * i + 50, 160));
                list.Add(null);
                timers.Add(new Timer());
                timers[i].Interval = 15000;
                timers[i].Tick += CustomersPositions_Tick;
                timers[i].Enabled = false;
            }
        }

        void CustomersPositions_Tick(object sender, EventArgs e)
        {
            if(sender is Timer){
               int ind = timers.IndexOf((Timer)sender);
               ((Person)list[ind]).toSadFace();
            }            
        }

        void moveTimer_Tick(object sender, EventArgs e)
        {
            //bool shouldMove = false;
            //foreach (Shape s in list)
            //{
            //    if (s != null && ((Person)s).ShouldMove)
            //    {
            //        ((Person)s).MoveTo();
            //        shouldMove = true;
            //    }
            //}
            //if (!shouldMove)
            //    moveTimer.Stop();
        }

        public Shape generateCustomer()
        {
            if (freeSpots > 0)
            {
                Shape s = personList.getPerson();
                moveTimer.Start();
                getFreePosition(s);
                return s;
            }
            else
                return null;
        }

        private void getFreePosition(Shape s)
        {
            Random r = new Random();
            while (true)
            {
                int ind = r.Next(0, spots);
                if (free[ind])
                {
                    free[ind] = false;
                    list[ind] = s;
                    ((Person)s).order = orderList.getOrder(r.Next(5));
                    ((Person)s).order.X = orderPositions[ind].X;
                    ((Person)s).order.Y = orderPositions[ind].Y;
                    freeSpots--;
                    ((Person)s).moveTo = positions[ind];
                    return;
                }
            }
        }

        public void makeFree(Point p)
        {
            int ind = coinsList.IndexOf(p);
            free[ind] = true;
            freeSpots++;
        }

        public void removeCustomer(Shape s)
        {
            //int ind = list.IndexOf(s);
            //free[ind] = true;
            //freeSpots++;
            
        }

        public int getIndex(Shape s)
        {
            return list.IndexOf(s);
        }

        public void activateTimer(Shape s)
        {
            int ind = list.IndexOf(s);
            timers[ind].Start();
        }

        public void stopTimer(Shape s)
        {
            int ind = list.IndexOf(s);
            timers[ind].Stop();
        }

        public bool Finish()
        {
            return (freeSpots == spots);
        }

    }
}
