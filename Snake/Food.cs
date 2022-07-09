using System;

namespace Snake
{
    public class Food
    {
        public Food()
        {
            Random random = new Random();
            var positionX = random.Next(1,20);
            var posiionY = random.Next(1,20);
            Position = new Position(positionX, posiionY);
            GetFood();
        }
        public Position Position { get; set; }
        public void GetFood()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("%");
        }
    }
}
