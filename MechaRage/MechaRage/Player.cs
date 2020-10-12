namespace MechaRage
{
    public class Player
    {
        private float X { get; set; }
        private float Y { get; set; }

        public void MoveUp()
        {
            Y += 10;
        }

        public void MoveDown()
        {
            Y -= 10;
        }

        public void MoveLeft()
        {
            X -= 10;
        }

        public void MoveRight()
        {
            X += 10;
        }
    }
}