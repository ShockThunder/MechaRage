namespace MechaRage.Entities
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public abstract class BaseEntity
    {
        protected Texture2D Texture;
        protected Color Color = Color.White;
        protected float Scale = 1f;
        public Vector2 Position;
        public Vector2 Velocity;
        public float Orientation;

        /// <summary>
        /// Radius for collision detection
        /// </summary>
        public float Radius;

        public bool IsDestroyed;

        public Vector2 Size
        {
            get
            {
                return Texture == null ? Vector2.Zero : new Vector2(Texture.Width, Texture.Height);
            }
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color, Orientation, Size / 2f, Scale, 0, 0);
        }

    }
}