using Snake.IServices;
using System;

namespace Snake
{
    public class GameAction : IGameAction
    {
        Food food = new Food();
        Snake snake = new Snake();
        public void SetMove(bool keyInfo, bool game)
        {
            var direction = Console.ReadKey();

            switch (direction.Key)
            {
                case ConsoleKey.Escape:
                    snake.outRange = true;
                    break;
                case ConsoleKey.RightArrow:
                    snake.Direction = Direction.Right;
                    break;
                case ConsoleKey.LeftArrow:
                    snake.Direction = Direction.Left;
                    break;
                case ConsoleKey.UpArrow:
                    snake.Direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    snake.Direction = Direction.Down;
                    break;
            }
        }
        public bool GetMove(ref double frameRate, DateTime dateNow)
        {
            snake.Move();

            if (snake.HeadPosition.X == food.Position.X
                && snake.HeadPosition.Y == food.Position.Y)
            {
                snake.Eat();
                frameRate /= 1.2;
                food = new Food();
            }

            return snake.gameOver;
        }
        public void GetGameOver(bool game)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER" +
                $"\nYour result: {snake.Lenght - 2}" +
                "\npress ESC to exit or press any button and play");
            game = false;
            var key = Console.ReadKey();

            if(key.Key != ConsoleKey.Escape)
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);
            }
            Console.Clear();
            Environment.Exit(0);

        }
    }
}
