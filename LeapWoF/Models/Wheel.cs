using LeapWoF.Interfaces;
using System;
using System.Threading.Tasks;
using LeapWoF;
using System.Collections.Generic;

namespace LeapWoF.Models
{
    public class Wheel
    {
        public List<Prize> prizes { get; private set; }

        private Random random { get; set; }

        public Wheel()
        {
            random = new Random();

            // Is there a better way to implement generating a list of Prizes?
            prizes = new List<Prize> {
                new Prize("500", 500),
                new Prize("600", 600),
                new Prize("700", 700),
                new Prize("800", 800),
                new Prize("900", 900),
                new Prize("1000", 1000),
                new Prize("3500", 3500),
                new Prize("Bankrupt", -1),
                new Prize("Lose A Turn", 0)
                };
        }

        public Prize Spin()
        {
            return prizes[random.Next(prizes.Count)];
        }
    }
}
