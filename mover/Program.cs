using System.Diagnostics;

namespace ZombieManager
{
    public class Program
    {
        static Vector2? lastPosition;
        static public void Main(string[] args)
        {
            Console.Clear();

            //Setup game variables
            Random random = new Random();
            List<Zombie> zombies = new List<Zombie>();
            Hunter hunter = new Hunter();
            Vector2 fieldStart = new Vector2(0, 0);
            Vector2 fieldSize = new Vector2(Console.WindowWidth, Console.WindowHeight);

            hunter.Position.X = random.Next(fieldStart.X, fieldSize.X);
            hunter.Position.Y = random.Next(fieldStart.Y, fieldSize.Y);

            if (OperatingSystem.IsWindows())
            {
                Console.SetBufferSize(fieldSize.X, fieldSize.Y);
            }
            
            Console.WriteLine("Welcome to zombie hunter, \nuse wasd or arrow keys to move your hunter (green) \nto kill the zombies(red)");

            //Ask for zombie amount
            Console.WriteLine("How many zombies do you want?");
            int zombieAmount = AskForAmount();
            Console.Clear();

            for (int i = 0; i < zombieAmount; i++)
            {
                Zombie zombie = new Zombie();
                zombie.Name = "Zombie" + (i + 1);
                zombie.Position = new Vector2(
                    random.Next(fieldStart.X, fieldSize.X),
                    random.Next(fieldStart.Y, fieldSize.Y)
                );

                zombies.Add(zombie);
            }

            lastPosition = hunter.Position.Clone();

            Console.Write("Press any key when you are ready to start the game");
            Console.ReadKey();
            Console.Clear();

            DrawEntities(hunter, zombies);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bool canceled = false;
            while (zombies.Count > 0 && canceled == false)
            {
                Vector2? direction = AskForDirection();
                if (direction == null)
                {
                    canceled = true;
                    break;
                }

                //Check if positions.[X|Y] > 0
                Vector2 newPosition = Vector2.Add(hunter.Position, direction);
                if (newPosition.X < 0 || newPosition.Y < 0 || newPosition.X >= fieldSize.X || newPosition.Y >= fieldSize.Y)
                {
                    continue;
                }
                //Move hunter
                hunter.Position.Add(direction);

                DrawEntities(hunter, null);
                lastPosition = hunter.Position.Clone();

                //Remove zombie that we killed
                zombies.RemoveAll(zombie =>
                {
                    return zombie.Position.Equals(hunter.Position);
                });
            }

            stopwatch.Stop();
            Console.Clear();

            string elapsedTime = String.Format(
                "{0:00}m:{1:00}.{2:000}s",
                stopwatch.Elapsed.Minutes,
                stopwatch.Elapsed.Seconds,
                stopwatch.Elapsed.Milliseconds / 100
            );

            String finishText = "";
            if (canceled)
            {
                finishText = "Game over, elapsed time: ";
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                finishText = "Game won, elapsed time: ";
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.SetCursorPosition(
                fieldStart.X + (fieldSize.X / 2) - (finishText.Length / 2) - (elapsedTime.Length / 2) - 4,
                fieldStart.Y + (fieldSize.Y / 2)
            );
            Console.Write(finishText + elapsedTime);

            Console.ResetColor();

            while (Console.ReadKey(true).Key != ConsoleKey.Enter) {}
        }

        private static Vector2? AskForDirection()
        {
            ConsoleKey input = Console.ReadKey(true).Key;

            if (input == ConsoleKey.W || input == ConsoleKey.UpArrow)
            {
                return new Vector2(0, -1);
            }
            else if (input == ConsoleKey.S || input == ConsoleKey.DownArrow)
            {
                return new Vector2(0, 1);
            }
            else if (input == ConsoleKey.A || input == ConsoleKey.LeftArrow)
            {
                return new Vector2(-1, 0);
            }
            else if (input == ConsoleKey.D || input == ConsoleKey.RightArrow)
            {
                return new Vector2(1, 0);
            }

            return null;
        }

        private static void DrawEntities(Hunter hunter, List<Zombie>? zombies)
        {
            if (lastPosition != null)
            {
                Console.SetCursorPosition(lastPosition.X, lastPosition.Y);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
                Console.ResetColor();
            }

            zombies?.ForEach(zombie => {
                Console.SetCursorPosition(zombie.Position.X, zombie.Position.Y);

                if (zombie.Position.Equals(hunter.Position) == false)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            });

            Console.SetCursorPosition(hunter.Position.X, hunter.Position.Y);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write(" ");
            Console.ResetColor();
        }

        private static int AskForAmount()
        {
            string? input = Console.ReadLine();
            int amount;

            try
            {
                amount = Convert.ToInt32(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Incorrect input");
                return AskForAmount();
            }

            return amount;
        }
    }
}
