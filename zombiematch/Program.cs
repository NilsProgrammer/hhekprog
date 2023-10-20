using ZombieManager;

namespace ZombieManager
{
    public class Program
    {
        static readonly List<Zombie> zombies = new List<Zombie>();
        static readonly List<Hunter> hunters = new List<Hunter>();
        static readonly List<Vector2> overlap = new List<Vector2>();

        static public void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("How many zombies do you want?");
            int zombieAmount = AskForAmount();
            Console.Clear();

            Console.WriteLine("How many hunters do you want?");
            int hunterAmount = AskForAmount();
            Console.Clear();

            Vector2 fieldStart = new Vector2(0, 0);
            Vector2 fieldSize = new Vector2(Console.WindowWidth, 5);

            Random random = new Random();
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

            for (int i = 0; i < hunterAmount; i++) {
                Hunter hunter = new Hunter();
                hunter.Name = "Hunter" + (i + 1);
                hunter.Position = new Vector2(
                    random.Next(fieldStart.X, fieldSize.X),
                    random.Next(fieldStart.Y, fieldSize.Y)
                );

                hunters.Add(hunter);
            }

            zombies.ForEach(zombie => {
                Hunter? match = hunters.FirstOrDefault(hunter => {
                    return hunter.Position.Equals(zombie.Position);
                });

                if (match != null) {
                    overlap.Add(zombie.Position);
                }
            });

            Console.Clear();
            DrawEntities();

            Console.SetCursorPosition(0, fieldStart.Y + fieldSize.Y);
            Console.Write("Intersects: ");
            overlap.ForEach(intersect => {
                Console.Write(intersect.ToString() + " ");
            });
            Console.WriteLine();

            Console.ReadLine();
        }
        
        private static void DrawEntities() {
            zombies.ForEach(zombie => {
                Console.SetCursorPosition(zombie.Position.X, zombie.Position.Y);

                Vector2? intersect = overlap.FirstOrDefault(vector2 => {
                    return vector2.Equals(zombie.Position);
                });


                if (intersect != null) {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("±");

                    Console.ResetColor();
                }
                else {
                    Console.Write("-");
                }
            });

            hunters.ForEach(hunter => {
                Console.SetCursorPosition(hunter.Position.X, hunter.Position.Y);

                Vector2? intersect = overlap.FirstOrDefault(vector2 => {
                    return vector2.Equals(hunter.Position);
                });

                if (intersect == null) {
                    Console.Write("+");
                }
            });
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
