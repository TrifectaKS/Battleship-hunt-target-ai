using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Enums
{
    /// <summary>            
    ///     Carrier (5) - CV represented as (5) Displayed as E
    ///     Battleship(4) - BB represented as (4) Displayed as D
    ///     Crusier(3) - CL represented as (3) Displayed as C
    ///     Submarine(3) - SS represented as (3) Displayed as B
    ///     Destroyer(2) - DD represented as (2) Displayed as A
    ///     Empty - EMPTY represented as (-1)
    /// </summary>
    public enum ShipType
    {
        CV = 5,
        BB = 4,
        CL = 3,
        SS = 3,
        DD = 2
    }
}
