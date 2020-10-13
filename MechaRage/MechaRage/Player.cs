namespace MechaRage
{
    public class Player
    {
        private int timeCoef = 50;
        private float X { get; set; }
        private float Y { get; set; }

        public Player()
        {
            X = 100;
            Y = 100;
        }
        public void MoveUp(double elapsedTime)
        {
            Y -= 10 * (float)elapsedTime / timeCoef;
        }

        public void MoveDown(double elapsedTime)
        {
            Y += 10 * (float)elapsedTime / timeCoef;
        }

        public void MoveLeft(double elapsedTime)
        {
            X -= 10 * (float)elapsedTime / timeCoef;
        }

        public void MoveRight(double elapsedTime)
        {
            X += 10 * (float)elapsedTime / timeCoef;
        }

        public float GetX()
        {
            return X;
        }

        public float GetY()
        {
            return Y;
        }
    }
}