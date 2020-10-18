namespace MechaRage.Entities
{
    using System;

    using global::MechaRage.Helpers;
    using global::MechaRage.ResourceManagers;

    using Microsoft.Xna.Framework;

    public class Bullet : BaseEntity
    {
        public Bullet(Vector2 position, Vector2 velocity)
        {
            Texture = ArtManager.Bullet;
            Position = position;
            Velocity = velocity;
            Orientation = velocity.ToAngle();
            Radius = 8;
        }
        public override void Update()
        {
            if (Velocity.LengthSquared() > 0)
            {
                Orientation = Velocity.ToAngle();
            }

            Position += Velocity;

            if (MechaRage.Viewport.Bounds.Contains(Position.ToPoint()))
            {
                IsDestroyed = true;
            }
        }
    }
}