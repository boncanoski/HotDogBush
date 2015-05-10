using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotDogBush.Properties;
using System.Collections.Generic;

namespace HotDogBush
{
    public class PersonList
    {
        List<bool> available;
        List<Person> all;

        public PersonList()
        {
            available = new List<bool>();
            all = new List<Person>();

            Person temp = new Person(Resources.happy1, Resources.sad1, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy2, Resources.sad2, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy3, Resources.sad3, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy4, Resources.sad4, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy5, Resources.sad5, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy6, Resources.sad6, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy7, Resources.sad7, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy8, Resources.sad8, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy9, Resources.sad9, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy10, Resources.sad10, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy11, Resources.sad11, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
            temp = new Person(Resources.happy12, Resources.sad12, -100, 65, 127, 147);
            available.Add(true);
            all.Add(temp);
        }

        public Person getPerson()
        {
            Random r = new Random();
            while (true)
            {
                int ind = r.Next(0, all.Count);
                if(available[ind])
                {
                    available[ind] = false;
                    return all[ind];
                }
            }
        }
    }
}
