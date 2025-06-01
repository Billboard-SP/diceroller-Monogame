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

        public DamageRoll(int diceCount, int diceSides, int modifier, string damageType)
        {
            this.diceCount = diceCount;
            this.diceSides = diceSides;
            this.modifier = modifier;
            this.damageType = damageType;
            miscSources = new List<(int, int, string)>();
            damageByType = new Dictionary<string, int>();
        }

        public void AddMiscDamage(int count, int sides, string type)
        {
            miscSources.Add((count, sides, type));
        }

        public int RollDamage()
        {
            Random rnd = new Random();
            damageByType.Clear();
            int total = 0;

            // Base damage
            int baseTotal = 0;
            for (int i = 0; i < diceCount; i++)
                baseTotal += rnd.Next(1, diceSides + 1);
            baseTotal += modifier;
            damageByType[damageType] = baseTotal;
            total += baseTotal;

            // Misc
            foreach (var (count, sides, type) in miscSources)
            {
                int miscTotal = 0;
                for (int i = 0; i < count; i++)
                    miscTotal += rnd.Next(1, sides + 1);

                if (damageByType.ContainsKey(type))
                    damageByType[type] += miscTotal;
                else
                    damageByType[type] = miscTotal;

                total += miscTotal;
            }

            lastTotalDamage = total;
            return total;
        }

        public int GetTotalDamage() => lastTotalDamage;

        public Dictionary<string, int> GetDamageBreakdown() => damageByType;
    }
}
