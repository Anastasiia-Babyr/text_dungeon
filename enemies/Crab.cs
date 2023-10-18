using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace текстовое_подземелье.enemies
{
    public class Crab : BaseEnemy
    {
        public Crab() : base ("краб", STRENGHT, VITALITY)
        {
            Console.WriteLine("Сточный краб - ещё более мерзкое создание, чем все те, кто встречался здесь до этого. Здоровый хитиновый панцирь, две огргомные твёрдые клешни и невероятная скорость делали его вершиной местной пищевой цепи. Ну, конечно, до появления здесь авантюриста.");
        }

        private const int STRENGHT = 15;
        private const int VITALITY = 15;
    }   
}