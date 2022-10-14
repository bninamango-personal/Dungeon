using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace bninamango
{
    class Level
    {
        public static string[,] FileToArray(string path)
        {
            //if (!File.Exists(path)) return null;

            string[] lines = File.ReadAllLines(path);

            string firstLine = lines[LineToHighCharacters(lines)];

            int rows = lines.Length;
            int cols = firstLine.Length;

            string[,] grid = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string line = lines[i];

                for (int j = 0; j < cols; j++)
                {
                    char element = ' ';

                    try
                    {
                        element = line[j];
                    }
                    catch
                    {
                        element = ' ';
                    }

                    grid[i, j] = element.ToString();
                }
            }

            return grid;
        }

        private static int LineToHighCharacters(string[] lines)
        {
            int higher = 0;
            int aux = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > higher)
                {
                    higher = lines[i].Length;

                    aux = i;
                }
            }

            return aux;
        }
    }
}