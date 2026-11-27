using System;

namespace Task3_Races
{
    public abstract class Trial
    {
        public abstract string Name { get; }
        public abstract void Play();
    }
    public class Beach : Trial
    {
        public override string Name => "Пляж";
        public override void Play() => Console.WriteLine($"[{Name}] Команда проходит испытание на песке.");
    }
    public class Mousetrap : Trial
    {
        public override string Name => "Мышеловка";
        public override void Play() => Console.WriteLine($"[{Name}] Команда преодолевает полосу препятствий.");
    }
    public class Sea : Trial
    {
        public override string Name => "Море";
        public override void Play() => Console.WriteLine($"[{Name}] Команда плывет на плотах.");
    }
    public class Fishing : Trial
    {
        public override string Name => "Рыбалка";
        public override void Play() => Console.WriteLine($"[{Name}] Команда ловит рыбу с закрытыми глазами.");
    }
    public class Postmen : Trial
    {
        public override string Name => "Почтальоны";
        public override void Play() => Console.WriteLine($"[{Name}] Команда разносит письма по адресам.");
    }
    public class Hill : Trial
    {
        public override string Name => "Горка";
        public override void Play() => Console.WriteLine($"[{Name}] Команда скатывается с горы на скорость.");
    }
    public class NewCustomGame : Trial
    {
        public override string Name => "Собственная игра (Прыжки в мешках)";
        public override void Play() => Console.WriteLine($"[{Name}] Команда прыгает в мешках до финиша.");
    }
    public class Team
    {
        public string Country { get; set; }
        public int MembersCount { get; set; }

        public Team(string country, int membersCount = 15)
        {
            Country = country;
            MembersCount = membersCount;
        }

        public void PerformTrial(Trial trial)
        {
            Console.Write($"Команда {Country} (человек: {MembersCount}): ");
            trial.Play();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Большие гонки ===\n");
            Team russia = new Team("Россия");
            Team france = new Team("Франция");
            Team china = new Team("Китай");
            Team kazakhstan = new Team("Казахстан");

            Team[] teams = { russia, france, china, kazakhstan };
            Trial[] games = 
            {
                new Beach(),
                new Mousetrap(),
                new Sea(),
                new Fishing(),
                new Postmen(),
                new Hill(),
                new NewCustomGame() 
            };
            int gamesToPlay = 6; 

            for (int i = 0; i < gamesToPlay; i++)
            {
                Console.WriteLine($"\n--- Этап {i + 1}: {games[i].Name} ---");
                foreach (var team in teams)
                {
                    team.PerformTrial(games[i]);
                }
            }

            Console.WriteLine("\nГонки завершены!");
            Console.ReadLine();
        }
    }
}}