using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.enemies
{
    public class Boss : BaseEnemy
    {
        public Boss() : base("чёрная жижа", STRENGHT, VITALITY)
        {
            Console.WriteLine("Прямо посреди комнаты стояло...лежало..? В общем, было (!) нечто. Огромный кусок какой-то чёрной дряни, которая медленно покачивалась туда сюда. Неизвестно, чьё извращённое сознание создало это существо, но он явно был очень давно и серьёзно болен. Видимо, вот она - та самая злая магия о которой все судачили на поверхности. Авантюрист покрепче сжал в руке своё оружие и вытер свободную ладонь, давно взмокшую то ли от пота то ли от грязной воды, о штаны. Так или иначе, это всё пора было уже заканчивать, и он собирался сделать всё, чтобы эта тварь хотя бы изрядно помучилась, прежде чем убить его.");
        }

        private const int TOTALDAMAGE = 300;
        private const int STRENGHT = 20;
        private const int VITALITY = 20;

        public override int UseSpecialAbility()
        {
            Console.WriteLine("Чёрная жижа стреляет в тебя сгустками слизи! Она липнет к коже и разъедает её! Это наносит в три раза больше урона!");
            return TOTALDAMAGE;
        }
    }
}