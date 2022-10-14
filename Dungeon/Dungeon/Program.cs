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
            bool isGameOver = false;

            Dungeon dungeon = new Dungeon(Level.FileToArray("Worlds/World_0.txt"));

            Vector2 direction = new Vector2();

            Player player = new Player('B', Vector2.One);

            dungeon.Draw();

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
                if (dungeon.CanMove(player.Position + direction, ' ') || dungeon.CanMove(player.Position + direction, 'F'))
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
                if (dungeon.CanMove(player.Position, 'F'))
                {
                    isGameOver = true;

                    Console.Clear();

                    Console.WriteLine("You finished the maze, congratulations !!!");
                }
            }
        }
    }
}