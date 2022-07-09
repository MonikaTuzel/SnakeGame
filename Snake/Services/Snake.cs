using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake
{
    public enum Direction { Left, Right, Up, Down }

    public class Snake : ISnake
    {
        public int Lenght { get; set; } = 2;
        public Position HeadPosition { get; set; } = new Position();
        public Direction Direction { get; set; } = Direction.Right;
        List<Position> TailLenght = new List<Position>();
        public bool outRange = false;
        public bool gameOver
        {
            get 
            {
                return (TailLenght.Where(x => x.X == HeadPosition.X
                    && x.Y == HeadPosition.Y).ToList().Count() > 1 || outRange);
            } 
        }               
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }

            try
            {
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("O");

                TailLenght.Add(new Position(HeadPosition.X, HeadPosition.Y));
                if(TailLenght.Count > Lenght)
                {
                    var endTail = TailLenght.First();
                    Console.SetCursorPosition(endTail.X, endTail.Y);
                    Console.Write(" ");
                    TailLenght.Remove(endTail); 
                }
            } 
            catch (ArgumentOutOfRangeException)
            {
                outRange = true;
            }
        }
        public void Eat()
        {
            Lenght++;
        }
    }
}
