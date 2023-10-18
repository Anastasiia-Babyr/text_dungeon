using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.players
{
    public class Huntress : BasePlayer
    {
        public Huntress(string name = "имя выбирает игрок") : base (name, PLAYERTYPE, STRENGHT, AGILITY, VITALITY)
        {
            
        }

        private const int STRENGHT = 5;
        private const int AGILITY = 5;
        private const int VITALITY = 40;
        private const string PLAYERTYPE = "Охотник";

        public override void Introduction()
        {
            Console.Clear();
            Console.WriteLine($"{Name} потуже затянул свой синий шарф: как только он начал спуск стало ощутимо холоднее, запахло сыростью. Было немного страшно, но кинжал в руке придавал уверенности - сколько раз уже он выручал его? Он быстро преодолел последние пару ступеней и остановился перед ржавой железной калиткой. Здесь начинался его путь, и он не мог уйти даже не попытавшись, как бы страшно ни было: в конце концов, у него была цель.");
            Console.WriteLine("[выбор]\n1. Он хотел купить своему ручному хорьку позолоченную клетку.\n2. Он мечтал построить себе уютную хижину в самой глуши, чтобы жить в уединении и гармонии с природой.\n3. Его сокровенным желанием было, чтобы его родители смогли понять и принять его выобр - жизнь в глухой деревне, почти что в лесу.");
            Console.ReadLine();
        }

    }
}