using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace LeapWoF.Interfaces
{
    internal interface IWheel
    {
        List<IPrize> Prizes { get; }

        IPrize spin();
    }
}
