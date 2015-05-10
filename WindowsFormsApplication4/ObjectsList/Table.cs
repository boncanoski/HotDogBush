using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    public class Table : Drawable
    {
        public List<Shape> slices { get; set; }
        public List<Point> positions { get; set; }
        public List<bool> isEmpty { get; set; }

        public Table()
        {
            slices = new List<Shape>(3);
            positions = new List<Point>(3);
            


            positions.Add(new Point(160, 215));
            positions.Add(new Point(220, 215));
            positions.Add(new Point(280, 215));

            slices.Add(null);
            slices.Add(null);
            slices.Add(null);

            

            isEmpty = new List<bool>(3);
            isEmpty.Add(true);
            isEmpty.Add(true);
            isEmpty.Add(true);
        }

        public Shape addBread()
        {
            for (int i = 0; i < isEmpty.Count; i++)
            {
                if (isEmpty[i])
                {
                    slices[i] = new Bread(positions[i].X, positions[i].Y, 70, 100);
                    slices[i].Selected = slices[i];
                    isEmpty[i] = false;
                    return slices[i];
                }
            }
            return null;
        }

        public void removeBread(Shape r)
        {
            int ind = slices.IndexOf(r);
            slices[ind] = null;
            isEmpty[ind] = true;
        }


        public void Draw(Graphics g)
        {
            //for (int i = 0; i < isEmpty.Count; i++)
            //{
            //    if (!isEmpty[i])
            //    {
            //        sausages[i].X = positions[i].X;
            //        sausages[i].Y = positions[i].Y;
            //    }
            //}
        }
    }
}
