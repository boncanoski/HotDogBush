using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using HotDogBush.Properties;

namespace HotDogBush
{
    class ClickObject : Shape
    {
        public Grill grill { get; set; }
        public Table table { get; set; }
        public enum TYPE
        {
            GRILL, 
            TABLE
        }

        

        public TYPE Type { get; set; }
        

        public ClickObject(Image img, int x, int y, int width, int height)
            : base(img, x, y, width, height)
        {
            this.grill = Game.grill;
            this.table = Game.table;
        }

        public override Shape Click()
        {
            if (this.Type == TYPE.GRILL)
                return grill.addSausage();
            else
                return table.addBread();
        }

        public override void MouseUp(Shape s)
        {
            s.MouseUp();
        }

        public override void MouseUp()
        {

        }
    }
}
