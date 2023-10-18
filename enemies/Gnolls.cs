using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.enemies
{
    public class Gnolls : BaseEnemy
    {
        public Gnolls() : base ("Гнолл", STRENGHT, VITALITY)
        {
            Console.WriteLine("Гнолл - ещё одна разновидность грызунов, которая водится здесь. Грязный мех, некогда бывший тёмно-жёлтым, явно нуждался в расчёске, а в одном месте был заметно коротковат: то ли подпален, то ли выдран.");
        }

        private const int STRENGHT = 10;
        private const int VITALITY = 10;
    }
}