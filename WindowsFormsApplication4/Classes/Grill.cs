using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;
using System.Windows.Forms;


namespace HotDogBush
{
    public class Grill :  Drawable
    {
        public List<Sausage> sausages { get; set; }
        public List<Point> positions { get; set; }
        public List<bool> isEmpty { get; set; }
        public List<Timer> timers { get; set;  }

        public Grill()
        {
            sausages = new List<Sausage>(3);
            positions = new List<Point>(3);
            isEmpty = new List<bool>(3);
            timers = new List<Timer>(3);

            sausages.Add(null);
            sausages.Add(null);
            sausages.Add(null);

            positions.Add(new Point(460, 215));
            positions.Add(new Point(500, 215));
            positions.Add(new Point(540, 215));

            isEmpty.Add(true);
            isEmpty.Add(true);
            isEmpty.Add(true);

            for (int i = 0; i < 3; i++)
            {
                timers.Add(new Timer());
                timers[i].Interval = 7000;
                timers[i].Tick += Grill_Tick;
            }

               
            //timers.Add(new Timer());
            //timers.Add(new Timer());

            
            //timers[1].Interval = 7000;
            //timers[2].Interval = 7000;

            
            //timers[1].Tick += Grill_Tick;
            //timers[2].Tick += Grill_Tick;

        }

        void Grill_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                if (timers[i] == sender)
                {
                    sausages[i].changeState();
                    Game.Redraw();
                    if (sausages[i].State == 3) {
                        timers[i].Stop();
                        timers[i].Enabled = false;                    
                    }
                    return;
                }
            }
        }

        public Shape addSausage()
        {
            for (int i = 0; i < isEmpty.Count; i++)
            {
                if (isEmpty[i])
                {
                    sausages[i] = new Sausage(positions[i].X, positions[i].Y, 30, 100);
                    sausages[i].Selected = sausages[i];
                    isEmpty[i] = false;
                    timers[i].Enabled = true;
                    timers[i].Start();
                    return sausages[i];
                }
            }
            return null;     
        }

        public void removeSausage(Sausage s)
        {
            int ind = sausages.IndexOf(s);
            sausages[ind] = null;
            isEmpty[ind] = true;
            timers[ind].Stop();
            timers[ind].Enabled = false;       
        }

        public void stopTimer(Sausage s)
        {
            int ind = sausages.IndexOf(s);
            timers[ind].Enabled = false;
        }

        public void startTimer(Sausage s)
        {
            int ind = sausages.IndexOf(s);
            timers[ind].Enabled = true;
        }

        public void Draw(Graphics g)
        {

        }
    }
}
