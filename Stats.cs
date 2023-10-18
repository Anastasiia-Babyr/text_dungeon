using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using текстовое_подземелье.players;

namespace текстовое_подземелье
{
    public static class Stats
    {

        public static void ShowHuntressFullStats()
        {
            Console.WriteLine("Класс: Охотник\nОчки силы: 5\nОчки ловкости: 5\nОчки здоровья: 40");
        }
        public static void ShowWarriorFullStats()
        {
            Console.WriteLine("Класс: Воин\nОчки силы: 11\nОчки ловкости: 5\nОчки здоровья: 30");
        }
        public static void ShowThiefFullStats()
        {
            Console.WriteLine("Класс: Вор\nОчки силы: 5\nОчки ловкости: 11\nОчки здоровья: 30");
        }
    }
}