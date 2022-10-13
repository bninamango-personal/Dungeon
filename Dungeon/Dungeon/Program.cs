using System.Threading;
using System.IO;
using System;

namespace bninamango
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameOver = false;

            Vector2 direction = new Vector2();

            Player player = new Player('B', Vector2.Zero);

            GameLoop();

            void GameLoop() 
            {
                while (!isGameOver)
                {
                    Thread t = new Thread(Input);
                    t.Start();

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
                player.Move(direction);
            }

            void Render()
            {
                Console.Clear();

                player.Draw();

                direction = Vector2.Zero;
            }
        }
    }
}