using System;
using System.Collections.Generic;
using System.Text;

namespace bninamango
{
    class Player
    {
        private char character;
        private Vector2 position;

        public Vector2 Position 
        {
            get => position;
        }

        public Player(char character, Vector2 position)
        {
            this.character = character;
            this.position = position;
        }

        public void Move(Vector2 direction)
        {
            position += direction;
        }

        public void Draw()
        {
            position.x = (position.x >= 0) ? position.x : 0;
            position.y = (position.y >= 0) ? position.y : 0;

            Console.SetCursorPosition(position.x, position.y);
            Console.WriteLine(character);
        }
    }
}