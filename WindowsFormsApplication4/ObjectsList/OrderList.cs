using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotDogBush.Properties;

namespace HotDogBush
{
    public class OrderList
    {
        public List<Order> list;
        private const int width = 90;
        private const int height = 150;

        public OrderList()
        {
            list = new List<Order>();

            list.Add(new Order(Resources.order1, 0, 0, height, width));
            list[0].Sausage = list[0].Ketchup = true;
            list.Add(new Order(Resources.order2, 0, 0, height, width));
            list[1].Sausage = true;
            list.Add(new Order(Resources.order3, 0, 0, height, width));
            list[2].Sausage = list[2].Ketchup = list[2].Glass = true;
            list.Add(new Order(Resources.order4, 0, 0, height, width));
            list[3].Sausage = list[3].Glass = true;
            list.Add(new Order(Resources.order5, 0, 0, height, width));
            list[4].Glass = true;
        }

        public Order getOrder(int ind)
        {
            return new Order(list[ind]);
        }
    }
}
