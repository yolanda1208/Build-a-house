using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice02___Build_a_house
{
    internal abstract class Location
    {
        public Location(string name)
        {
            this.name = name;
        }

        public Location[] Exits;
        private string name;

        public string Name
        {
            get { return name; }
        }

        public virtual string Description
        {
            get
            {
                string description = "你站在" + name + ".你可以走到: ";
                for (int index = 0; index < Exits.Length; index++)
                {
                    description += "" + Exits[index].Name;
                    if (index != Exits.Length - 1)
                        description += ",";
                }
                description += ".";
                return description;
            }
        }
    }
}