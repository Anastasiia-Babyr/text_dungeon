using System;
using текстовое_подземелье;
using текстовое_подземелье.players;


static void PrintMenu()
{
    Console.Clear();
    Console.WriteLine("ИГРА ТЕКСТОВОЕ ПОДЗЕМЕЛЬЕ\n");
    Console.WriteLine("1 - начать игру");
    Console.WriteLine("2 - правила");
    Console.WriteLine("3 - выход");
    var option = Console.ReadLine()!;

    if (option == "1")
    {
        Game game = new Game();
        game.Start();
    }
    if (option == "2")
        PrintRules();

    if (option == "3")
        return;

    PrintMenu();
}

PrintMenu();

static void PrintRules()
{
    Console.Clear();
    Console.WriteLine("Данная игра представляет собой небольшой текстовый квестик.\nГлавный герой - отважный искатель приключений. Он решает спуститься в таинственное подземелье, в недрах которого, как говорят, скрывается таинственный амулет, дарующий исполнение любых желаний. Многие смельчаки погибли, пытаясь достать его, многие возвращалась с полными карманами денег и артефактов, но до амулета ещё никому не удавалось добраться.\nСтанет ли ваш герой первым, кто сумеет?\n");
    Console.WriteLine("Доступные классы: (пополняются по мере наличия у меня свободного времени и интереса):\n");
    Stats.ShowWarriorFullStats();
    Console.WriteLine();
    Stats.ShowHuntressFullStats();
    Console.WriteLine();
    Stats.ShowThiefFullStats();
    Console.WriteLine("Чтобы вернуться, нажмите enter");
    Console.ReadLine();
    
}

