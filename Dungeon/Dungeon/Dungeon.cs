using System;
using System.Collections.Generic;
using System.Text;

namespace bninamango
{
    class Dungeon
    {
        private int rows;
        private int cols;
        private string[,] grid;

        public Dungeon(string[,] grid)
        {
            this.grid = grid;

            rows = grid.GetLength(0);
            cols = grid.GetLength(1);
        }

        public bool CanMove(Vector2 position, char character)
        {
            return grid[position.y, position.x] == character.ToString();
        }

        public void Draw()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string element = grid[i, j];

                    Console.SetCursorPosition(j, i);
                    Console.WriteLine(element);
                }
            }
        }

        public char GetCharacter(Vector2 position)
        {
            return char.Parse(grid[position.y, position.x]);
        }
        public void Replace(Vector2 position)
        {
            grid[position.y, position.x] = " ";
        }
    }
}