namespace Snake
{
    public class Position
    {
        public Position()
        {
            X = 0;
            Y = 0;  
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;                
        }
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
    }
}
