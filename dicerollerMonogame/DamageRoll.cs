using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicerollerMonogame
{
    internal class DamageRoll
    {
        private int diceCount, diceSides, modifier;
        private string damageType;
        private List<(int count, int sides, string type)> miscSources;
        private Dictionary<string, int> damageByType;
        private int lastTotalDamage;


    }
}
