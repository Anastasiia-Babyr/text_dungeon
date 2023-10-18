using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.enemies
{
    public class Rats : BaseEnemy
    {
        public Rats() : base ("Крыса", STRENGHT, VITALITY)
        {
            Console.WriteLine("Крыса - типичный преставитель подземельного животного мира. Они обитают на первом уровне, и поэтому часто выползают наружу и охотятся там. Будучи ночными хищниками, абсолютно спокойно чувствуют себя в полумраке подземелья.");
        }

        private const int STRENGHT = 5;
        private const int VITALITY = 5;
    }
}