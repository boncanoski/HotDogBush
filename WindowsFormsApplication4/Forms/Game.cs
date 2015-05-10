using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotDogBush.Properties;
namespace HotDogBush
{
    public partial class Game : Form
    {
        public Home home;
        public static ShapeList list;
        public static Game form;
        Shape current;
        Graphics g;
        private Graphics graphics;
        private Bitmap doubleBuffer;
        public bool mouse_down { get; set; }
        private float prevX;
        private float prevY;
        public static Grill grill { get; set; }
        public static Table table { get; set; }
        public static Timer moneyTimer;
        public static int profit { get; set; }
        public static CustomersPositions customers { get; set; }
        private Money money;
        public static readonly object syncLock = new object();

        public Game()
        {
            InitializeComponent();
            form = this;
            mouse_down = false;
            list = new ShapeList();
            current = null;
            profit = 0;

            doubleBuffer = new Bitmap(Width, Height);
            graphics = CreateGraphics();


            g = this.CreateGraphics();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Ketchup ketchup = new Ketchup(Resources.ketchup_bottle, 0, 160, 25, 60);
            Ketchup ketchup1 = new Ketchup(Resources.ketchup_bottle_fill, 0, 160, 25, 60);
            grill = new Grill();
            table = new Table();




            moneyTimer = new Timer();
            moneyTimer.Interval = 2500;
            moneyTimer.Tick += moneyTimer_Tick;

            ClickObject sausages = new ClickObject(Resources.sausages, 496, 317, 104, 51);
            sausages.Type = ClickObject.TYPE.GRILL;

            Shape drinks = new Drinks(0, 316, 66, 52);

            ClickObject bread = new ClickObject(Resources.bread, 151, 317, 121, 51);
            bread.Type = ClickObject.TYPE.TABLE;

            Trash trash = new Trash(0, 213, 108, 102);


            customers = new CustomersPositions();
            timerCustomers_Tick(new Object(), new EventArgs());

            ketchup.Selected = ketchup1;
            lock (syncLock)
            {
                list.Shapes.Add(trash);
                list.Shapes.Add(ketchup);
                list.Shapes.Add(sausages);
                list.Shapes.Add(bread);
                list.Shapes.Add(drinks);
            }

            this.DoubleBuffered = true;

        }

        void moneyTimer_Tick(object sender, EventArgs e)
        {
            moneyTimer.Stop();
            removeShape(money);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //list.Draw(e.Graphics);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (list.IsHovered(e.X, e.Y) != null)
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Arrow;

            if (mouse_down)
            {
                if (current != null && current.Selected != null)
                {
                    float dx = e.X - prevX;
                    float dy = e.Y - prevY;
                    current.Selected.Move(dx, dy);
                }
                prevX = e.X;
                prevY = e.Y;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Shape temp = list.IsHovered(e.X, e.Y);

            if (temp != null && temp == current)
            {
                Shape s = temp.Click();
                if (s != null)
                    addShape(s);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            current = list.IsHovered(e.X, e.Y);

            if (current != null && current.Selected != null)
                addShape(current.Selected);
            mouse_down = true;
            prevX = e.X;
            prevY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
            if (current != null)
            {
                removeShape(current.Selected);
                Shape s = list.IsHovered(e.X, e.Y);
                if (s != null)
                    s.MouseUp(current);
                else
                    current.MouseUp();
                current = null;
            }
        }


        public static void removeShape(Shape s)
        {
            lock (Game.syncLock)
            {
                list.Shapes.Remove(s);
            }
        }

        public static void addShape(Shape s)
        {
            if (s != null)
            {
                lock (Game.syncLock)
                {
                    list.Shapes.Add(s);
                }
            }
        }
        public static void Redraw()
        {
        }

        public static void showPrice(Point location, int price)
        {
            Game.profit = Game.profit + price;
            Game.removeShape(Game.form.money);
            Game.form.money = new Money(location, price);
            Game.addShape(Game.form.money);
            moneyTimer.Start();
            Game.form.lblProfit.Text = "Профит: " + profit + "$";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (elapsedTime.Value >= elapsedTime.Maximum)
                return;
            elapsedTime.Value += 1;
            chageTime();
        }

        private void chageTime()
        {
            int sec = elapsedTime.Value % 60;
            int min = elapsedTime.Value / 60;
            lblElapsedTime.Text = min + " мин " + sec + " сек";
        }

        private void timerCustomers_Tick(object sender, EventArgs e)
        {
            if (elapsedTime.Value < elapsedTime.Maximum)
                addShape(customers.generateCustomer());
            else if (customers.Finish())
            {
                timerCustomers.Stop();
                home.Visible = true;
                EndOfGame endOfGame = new EndOfGame();
                endOfGame.score = profit;
                endOfGame.Show();
                endOfGame.Activate();
               
                this.Close();
            }

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);

            g.Clear(Color.White);
            g.DrawImage(Resources.bg1, 0, 0, 600, 368);
            list.Draw(g);
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);


        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            home.Visible = true;
        }

    }
}
