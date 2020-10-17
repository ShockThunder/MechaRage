namespace MechaRage.Entities
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Player
    {
        private const int TIME_COEFFICIENT = 50;
        private float X { get; set; }
        private float Y { get; set; }
        private Texture2D _texture;

        
        private Vector2 Position => new Vector2(X,Y);

        public Player()
        {
            X = 100;
            Y = 100;
        }
        public void MoveUp(double elapsedTime)
        {
            Y -= 10 * (float)elapsedTime / TIME_COEFFICIENT;
        }

        public void MoveDown(double elapsedTime)
        {
            Y += 10 * (float)elapsedTime / TIME_COEFFICIENT;
        }

        public void MoveLeft(double elapsedTime)
        {
            X -= 10 * (float)elapsedTime / TIME_COEFFICIENT;
        }

        public void MoveRight(double elapsedTime)
        {
            X += 10 * (float)elapsedTime / TIME_COEFFICIENT;
        }

        public float GetX()
        {
            return X;
        }

        public float GetY()
        {
            return Y;
        }

        public float GetRotation(MouseState mouseState)
        {
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);

            var direction = mousePosition - Position;
            direction.Normalize();
            return (float) (Math.Atan2(
                direction.Y,
                direction.X) + Math.PI/2);
        }

        public Vector2 GetPosition()
        {
            return Position;
        }

        public Vector2 GetScale()
        {
            return new Vector2((float) 0.2, (float) 0.2);
        }

        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }
        
        public Texture2D GetTexture()
        {
            return _texture;
        }

        public Vector2 GetOrigin()
        {
            return new Vector2(_texture.Width/2f,_texture.Height/2f);
        }
    }
}