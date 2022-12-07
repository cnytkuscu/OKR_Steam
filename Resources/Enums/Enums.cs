using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resources.Enums
{
    public static class Enums
    {
        public enum ProfileStates
        {
            Online = 0,
            Offline = 1,
            InGame = 2,
            Away = 3,
            DoNotDisturb = 4
        }

        public enum ItemExteriors
        {
            FactoryNew = 0,
            MinimalWear = 1,
            FieldTested = 2,
            WellWorn = 3,
            BattleScarred = 4
        }
    }
}
