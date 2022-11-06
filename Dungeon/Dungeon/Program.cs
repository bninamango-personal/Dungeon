using System.Threading;
using System.IO;
using System;
using System.Reflection;

namespace bninamango
{
    class Program
    {
        static void Main(string[] args)
        {
            Intro();
            Instructions();

            bool isGameOver = false;

            Dungeon dungeon = new Dungeon(Level.FileToArray("Worlds/World_0.txt"));

            Vector2 direction = new Vector2();

            Player player = new Player('B', Vector2.One);

            Render();

            GameLoop();

            void GameLoop()
            {
                while (!isGameOver)
                {
                    Input();

                    Update();

                    Render();

                    Thread.Sleep(60);
                }
            }

            void Input()
            {
                switch (Console.ReadKey().Key)
                {
                    default:
                        break;

                    case ConsoleKey.UpArrow:

                        direction = Vector2.Down;

                        break;

                    case ConsoleKey.DownArrow:

                        direction = Vector2.Up;

                        break;

                    case ConsoleKey.RightArrow:

                        direction = Vector2.Right;

                        break;

                    case ConsoleKey.LeftArrow:

                        direction = Vector2.Left;

                        break;
                }
            }

            void Update()
            {
                if (dungeon.CanMove(player.Position + direction, ' '))
                {
                    player.Move(direction);
                }

                if (dungeon.CanMove(player.Position + direction, 'L'))
                {
                    player.SetKey(true);

                    dungeon.Replace(player.Position + direction);

                    player.Move(direction);
                }

                if (dungeon.CanMove(player.Position + direction, 'F') && player.Key)
                {
                    player.Move(direction);
                }
            }

            void Render()
            {
                Console.Clear();

                dungeon.Draw();

                player.Draw();

                direction = Vector2.Zero;

                GameOver();
            }

            void GameOver()
            {
                if (dungeon.CanMove(player.Position, 'F') && player.Key)
                {
                    isGameOver = true;

                    Console.Clear();

                    Finish();
                }
            }

            void Intro()
            {
                string[] lines = File.ReadAllLines("Title.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.WriteLine();

                Console.ReadKey();

                Console.Clear();
            }

            void Instructions()
            {
                Console.WriteLine("Instructions");
                Console.WriteLine("▲ : Up movement");
                Console.WriteLine("▼ : Down movement");
                Console.WriteLine("► : Right movement");
                Console.WriteLine("◄ : Left movement");
                Console.WriteLine("L : Key door");
                Console.WriteLine("F : Destination door");
                Console.WriteLine("\nYou have to get the key to get out of the maze\n");
                
                Console.WriteLine("Press any key to continue");

                Console.ReadKey();

                Console.Clear();
            }

            void Finish()
            {
                string[] lines = File.ReadAllLines("Finish.txt");

                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
            }
        }
    }
}