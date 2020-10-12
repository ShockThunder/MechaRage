namespace MechaRage
{
    public class Player
    {
        private float X { get; set; }
        private float Y { get; set; }

        public Player()
        {
            X = 100;
            Y = 100;
        }
        public void MoveUp()
        {
            Y -= 10;
        }

        public void MoveDown()
        {
            Y += 10;
        }

        public void MoveLeft()
        {
            X -= 10;
        }

        public void MoveRight()
        {
            X += 10;
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