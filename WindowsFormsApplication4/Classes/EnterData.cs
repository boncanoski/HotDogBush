using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDogBush
{
    public class EnterData : IComparable<EnterData>
    {
        public string Ime { get; set; }
        public int Poeni { get; set; }
        public EnterData(string i, int p)
        {
            Ime = i;
            Poeni = p;
        }
        public override string ToString()
        {
            return string.Format("{0,27} {1}", Ime, Poeni);
        }


        int IComparable<EnterData>.CompareTo(EnterData other)
        {
            return other.Poeni.CompareTo(this.Poeni);
        }
    }
}
