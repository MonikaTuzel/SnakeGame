using System;
namespace Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;   
            bool game = true;
            bool gameover = false;
            double frameRate = 200;
            var dateNow = DateTime.Now;

            GameAction action = new GameAction();

            while (game)
            {
                if (Console.KeyAvailable)
                    action.SetMove(Console.KeyAvailable, game);

                if ((DateTime.Now - dateNow).TotalMilliseconds >= frameRate)
                {
                    dateNow = DateTime.Now;
                    gameover = action.GetMove(ref frameRate, dateNow);
                }

                if (gameover || !game)
                    action.GetGameOver(game);                    
            }
        }
    }
}
