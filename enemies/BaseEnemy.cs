using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.enemies
{
    public abstract class BaseEnemy
    {
        protected Random random;

        public string Name { get; set; }
        public int Damage { get; set; }
        public int Strenght
        {
            get { return strenght; }
            private set
            {
                strenght = value;
                Damage = value * 10;
            }
        }
        public int Vitality
        {
            get { return vitality; }
            private set
            {
                vitality = value;
                HP = value * 2;
            }
        }
        public int HP { get; set; }

        private int strenght;
        private int vitality;
        

        protected BaseEnemy(string name, int strenght, int vitality)
        {
            Name = name;
            random = new Random();
            Strenght = strenght;
            Vitality = vitality;
        }

        public int GetDamage()
        {
            int totalDamage = random.Next(Damage - 10, Damage + 11);
            return totalDamage;
        }

        public virtual int UseSpecialAbility()
        {
            return 0;
        }

    }
}