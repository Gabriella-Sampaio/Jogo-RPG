/* Console.Clear();

Console.WriteLine("RPG"); Thread.Sleep(1000);
Console.WriteLine();
Console.WriteLine("Qual seu nome?");
string nomeUsuário = Console.ReadLine();

Console.WriteLine(); Thread.Sleep(500);

Console.WriteLine("Olá, " + nomeUsuário); Thread.Sleep(1000);
Console.WriteLine("Qual número é maior?");



int val1 = Console.Read();
int val2 = Console.Read();

    if (val1 <= val2){
        Console.WriteLine("é menor");
        //val1 é menor q val2
    }
    
    else {
        Console.WriteLine("é maior");
        //val1 é maior q val2
    }

Console.ReadKey(); */

using System;

namespace SimpleRPG
{
    class Program //
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao SimpleRPG!");
            Console.WriteLine("Digite seu nome:");
            string? playerName = Console.ReadLine();

            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "Herói"; // Nome padrão caso o jogador não insira nada
            }

            Player player = new Player(playerName);
            Enemy enemy = new Enemy("Goblin", 50, 10);

            Console.WriteLine($"Um {enemy.Name} selvagem apareceu!");

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine($"{player.Name} (HP: {player.Health}) vs {enemy.Name} (HP: {enemy.Health})");
                Console.WriteLine("Escolha uma ação: 1. Atacar 2. Fugir");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    player.Attack(enemy);
                    if (enemy.IsAlive)
                    {
                        enemy.Attack(player);
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Você fugiu da batalha!");
                    break;
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }

            if (player.IsAlive)
            {
                Console.WriteLine($"Você derrotou o {enemy.Name}!");
            }
            else
            {
                Console.WriteLine("Você foi derrotado...");
            }

            Console.WriteLine("Fim do jogo. Pressione qualquer tecla para sair.");
            Console.ReadKey();
        }
    }

    class Player
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int AttackPower { get; }

        public bool IsAlive => Health > 0;

        public Player(string name, int health = 100, int attackPower = 15)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void Attack(Enemy enemy)
        {
            Console.WriteLine($"{Name} ataca {enemy.Name}!");
            enemy.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} sofreu {damage} de dano! HP restante: {Health}");
        }
    }

    class Enemy
    {
        public string Name { get; }
        public int Health { get; private set; }
        public int AttackPower { get; }

        public bool IsAlive => Health > 0;

        public Enemy(string name, int health, int attackPower)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} ataca {player.Name}!");
            player.TakeDamage(AttackPower);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} sofreu {damage} de dano! HP restante: {Health}");
        }
    }
}

//fim do código da IA (estudar POO)

