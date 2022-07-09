using System;

namespace Snake.IServices
{
    public interface IGameAction
    {
        public void SetMove(bool keyInfo, bool game);
        public bool GetMove(ref double frameRate, DateTime dateNow);
        public void GetGameOver(bool game);

    }
}
