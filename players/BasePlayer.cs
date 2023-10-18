using System.Data;
using System.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using текстовое_подземелье;
using System.Linq.Expressions;

namespace текстовое_подземелье.players
{
    public abstract class BasePlayer
    {

        protected Random random;
        public delegate void IsDeadDelegate();
        public event IsDeadDelegate IsDead;

        private int strenght;
        private int agility;
        private int vitality;
        private int hp;
        bool takeMiddleArmor;
        bool takeCoolArmor;
        bool takeMiddleWeapon;
        bool takeCoolWeapon;
        bool takeJinxedArmor;
        bool takeJinxedWeapon;
        string itemName;
        string itemDescription;
        string itemResult;
        int jinxDamage;
        int itemType;
        string armorName = "тканевый доспех";
        string weaponName = "кинжал";

        public string Name { get; set; }
        public string ClassDescription { get; private set; }
        public int Damage { get; private set; }
        public int DodgeChance { get; private set; }
        public int Strenght
        {
            get { return strenght; }
            private set
            {
                strenght = value;
                Damage = value * 2;
            }
        }
        public int Agility
        {
            get { return agility; }
            private set
            {
                agility = value;
                DodgeChance = value * 10;
            }
        }
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value * 20;
            }
        }
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                    IsDead();
                }
            }
        }

        protected BasePlayer(string name, string classDescription, int strenght, int agility, int vitality)
        {
            random = new Random();
            Name = name;
            ClassDescription = classDescription;
            Agility = agility;
            Strenght = strenght;
            Vitality = vitality;
        }

        public int Kick()
        {
            if (Damage > 10)
            {
                int totalDamage = random.Next(Damage - 10, Damage + 11);
                return totalDamage;
            }
            else
            {
                int totalDamage = random.Next(Damage + 11);
                return totalDamage;
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($"Очки силы: {strenght}\nОчки ловкости: {agility}\nОчки здоровья: {vitality}\nБроня:{armorName}\nОружие:{weaponName}");
        }

        public void ShowHP()
        {
            Console.WriteLine($"У {Name} осталось {HP}/{vitality*20} очков жизни");
        }

        public abstract void Introduction();

        public void TakeItem()
        {
            itemType = random.Next(1, 7);
            switch (itemType)
            {
                case 4:
                    int armorType = random.Next(1, 3);
                    if (armorType == 1)
                    {
                        armorName = "кольчуга";
                        itemDescription = "её";
                        jinxDamage = 2;
                    }
                    else
                    {
                        armorName = "латы";
                        itemDescription = "их";
                        jinxDamage = 4;
                    }
                    WriteArmorDescription(armorType);
                    ShowStats();
                    break;

                case 5:
                    int weaponType = random.Next(1, 3);
                    if (weaponType == 1)
                    {
                        weaponName = "тяжёлый меч";
                        jinxDamage = 2;
                    }
                    else
                    {
                        weaponName = "молот";
                        jinxDamage = 4;
                    }
                    WriteWeaponDescription(weaponType);
                    ShowStats();
                    break;

                case 6:
                    if ((takeCoolArmor) || (takeCoolWeapon))
                    {
                        jinxDamage = 4;
                    }
                    else
                    {
                        jinxDamage = 2;
                    }
                    TakeScript();
                    ShowStats();
                    break;

                default:
                    TakePotion();
                    break;
            }
        }

        public void WritePotionDescription()
        {
            Console.WriteLine($"{Name} замечает зелье {itemName}! {Name} выпивает его и чувствует, как {itemDescription}. {itemResult}.");
        }

        public void TakePotion()
        {
            switch (itemType)
            {
                case 1:
                    itemName = "силы";
                    itemDescription = "становится сильнее";
                    itemResult = "+1 очко силы";
                    WritePotionDescription();
                    Strenght++;
                    ShowStats();
                    break;

                case 2:
                    itemName = "ловкости";
                    itemDescription = "пружинят мышцы";
                    itemResult = "+1 очко ловкости";
                    WritePotionDescription();
                    Agility++;
                    ShowStats();
                    break;

                case 3:
                    itemName = "исцеления";
                    itemDescription = "становится сильнее";
                    itemResult = "Здоровье восстановлено";
                    WritePotionDescription();
                    HP = vitality * 20;
                    ShowHP();
                    break;
                default:
                    break;
            }
        }

        public void WriteArmorDescription(int armorType)
        {
            Console.WriteLine($"{Name} замечает {armorName}! {Name} немного переживает, стоит ли надевать {itemDescription}, поскольку броня может оказаться проклятой. Стоит ли?");
            Console.WriteLine("1. Да, надеть\n2. Нет, не надевать");
            string option = Console.ReadLine()!;
            Console.WriteLine($"{Name} сделал свой выбор");
                if (option == "1")
            {
                int jinx = random.Next(1, 3);

                if (takeJinxedArmor)
                {
                    Console.WriteLine($"{Name} уже носит броню, и проклятье не позволяет снять её. Если бы тут был свиток снятия проклятия, это было бы более полезно.");
                }
                else if ((takeCoolArmor) && (armorType == 1))
                {
                    Console.WriteLine($"{Name} уже носит латы - а это броня покруче, как никак, и смысла менять её на более плохую нет.");
                }
                else if ((takeCoolArmor) && (armorType == 2))
                {
                    Console.WriteLine($"{Name} уже носит латы, и точно такая же броня ему не нужна");
                }
                else if ((takeMiddleArmor) && (armorType == 1))
                {
                    Console.WriteLine($"{Name} уже носит кольчугу, и вторая ему не нужна.");
                }
                else if (jinx == 1)
                {
                    takeJinxedArmor = true;
                    if (armorType == 1)
                    {
                        takeMiddleArmor = true;
                    }
                    else
                    {
                        takeCoolArmor = true;
                    }
                    Console.WriteLine($"На броне лежит проклятие. Минус {jinxDamage} очка ловкости");
                    Agility -= jinxDamage;
                }
                else if (jinx == 2)
                {
                    if (armorType == 1)
                    {
                        takeMiddleArmor = true;
                    }
                    else
                    {
                        takeCoolArmor = true;
                        takeMiddleArmor = true;
                    }
                    Console.WriteLine($"Плюс {jinxDamage} очка ловкости за счёт более подходящей тебе брони");
                    Agility += jinxDamage;
                }
            }
            else 
            {
                Console.WriteLine($"{Name} решил не рисковать и покинул комнату не прикасаясь к находке. Для него ничего не изменилось");
            }
        }

        public void WriteWeaponDescription(int weaponType)
        {
            Console.WriteLine($"{Name} замечает {weaponName}! {Name} немного переживает, стоит ли брать его, поскольку он может оказаться проклятым. Взять?");
            Console.WriteLine("1. Да, взять\n2. Нет, не брать");
            string option = Console.ReadLine()!;
            Console.WriteLine($"{Name} сделал свой выбор");
            if (option == "1")
            {
                int jinx = random.Next(1, 3);

                if (takeJinxedWeapon)
                {
                    Console.WriteLine($"{Name} уже носит оружие, и проклятье не позволяет снять его. Если бы тут был свиток снятия проклятия, это было бы более полезно.");
                }
                else if ((takeCoolWeapon) && (weaponType == 1))
                {
                    Console.WriteLine($"{Name} уже носит молот - а он будет покруче, как никак, и смысла менять его на более плохое оружие нет.");
                }
                else if ((takeCoolWeapon) && (weaponType == 2))
                {
                    Console.WriteLine($"{Name} уже носит латы, и точно такая же броня ему не нужна");
                }
                else if (jinx == 1)
                {
                    takeJinxedWeapon = true;
                    if (weaponType == 1)
                    {
                        takeMiddleWeapon = true;
                    }
                    else
                    {
                        takeCoolWeapon = true;
                        takeMiddleWeapon = false;
                    }
                    Console.WriteLine($"На оружии лежит проклятие. Минус {jinxDamage} очка силы");
                    Strenght -= jinxDamage;
                }
                else if (jinx == 2)
                {
                    if (weaponType == 1)
                    {
                        takeMiddleWeapon = true;
                    }
                    else
                    {
                        takeCoolWeapon = true;
                    }
                    Console.WriteLine($"Плюс {jinxDamage} очка силы за счёт более тяжёлого оружия");
                    Strenght += jinxDamage;
                }
                else if ((takeMiddleWeapon) && (weaponType == 1))
                {
                    Console.WriteLine($"{Name} уже носит тяжёлый меч, и вторая ему не нужна.");
                }
            }
            else
            {
                Console.WriteLine($"{Name} решил не рисковать и покинул комнату не прикасаясь к находке. Для него ничего не изменилось");
            }
        }

        public void TakeScript()
        {
            Console.WriteLine($"{Name} замечает свиток снятия проклятия! {Name} читает его тихим шёпотом, чтобы не привлечь внимания врагов поблизости.");
            if ((takeJinxedArmor) || (takeJinxedWeapon))
            {
                Console.WriteLine($"{Name} почувствовал как по нему прошла волна света, изгоняющая тёмную силу.");
                
                if (takeJinxedWeapon)
                {
                    Strenght += jinxDamage;
                    takeJinxedWeapon = false;
                }

                if (takeJinxedArmor)
                {
                    Agility += jinxDamage;
                    takeJinxedArmor = false;
                }
                Console.WriteLine("Проклятье снято. Очки возвращены.");

            }
            else
            {
                Console.WriteLine($"{Name} почувствовал как по нему прошла волна света, но ничего не произошло.");
            }
        }
    }
}