using System;
using System.Collections.Generic;
using System.Text;

namespace bninamango
{
    class Vector2
    {
        public int x;
        public int y;

        public static Vector2 Zero
        {
            get => new Vector2(0, 0);
        }

        public static Vector2 Up
        {
            get => new Vector2(0, 1);
        }

        public static Vector2 Down
        {
            get => new Vector2(0, -1);
        }

        public static Vector2 Right
        {
            get => new Vector2(1, 0);
        }

        public static Vector2 Left
        {
            get => new Vector2(-1, 0);
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector2(Vector2 vector)
        {
            x = vector.x;
            y = vector.y;
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            int x = a.x + b.x;
            int y = a.y + b.y;

            return new Vector2(x, y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            int x = a.x - b.x;
            int y = a.y - b.y;

            return new Vector2(x, y);
        }

        public static Vector2 operator *(Vector2 a, int k)
        {
            int x = a.x * k;
            int y = a.y * k;

            return new Vector2(x, y);
        }
    }
}