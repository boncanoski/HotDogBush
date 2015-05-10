using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace HotDogBush
{
    public class ShapeList
    {
        //public List<Drawable> Shapes;
        //public Queue<Drawable> list;
        public ArrayList Shapes = new ArrayList();

        public ShapeList()
        {
            //Shapes = new List<Drawable>();
        }

        public void Draw(Graphics g)
        {
            lock (Game.syncLock)
            {
                for (int i = 0; i < Shapes.Count; i++)
                {

                    if (Shapes[i] is Shape)
                    {
                        Shape s = (Shape)Shapes[i];
                        if (s != null && s is Person && ((Person)s).ShouldMove)
                            ((Person)s).MoveTo();
                    }
                    if (i < Shapes.Count)
                        ((Drawable)Shapes[i]).Draw(g);
                }
                //foreach (Drawable s in Shapes)
                //{
                //    if (s is Shape)
                //    {

                //        if (s != null && s is Person && ((Person)s).ShouldMove)
                //            ((Person)s).MoveTo();
                //    }
                //    s.Draw(g);
                //}
                    
            }
            
            
        }

        public Shape IsHovered(float x, float y)
        {
            foreach (Shape s in Shapes)
                if (s.IsHovered(x, y)!=null)
                    return s;
            return null;
        }
    }
}
