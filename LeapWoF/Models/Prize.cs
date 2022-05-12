using LeapWoF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapWoF.Models
{
    public class Prize : IPrize
    {

        public string Name { get; set; }

        public int Value { get; private set; }

        public Prize(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}
