namespace MechaRage.Entities
{
    using System;
    using System.Collections.Generic;

    using global::MechaRage.Helpers;
    using global::MechaRage.ResourceManagers;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Enemy : BaseEntity
    {
        private List<IEnumerator<int>> behaviours = new List<IEnumerator<int>>();
        private int _timeUntilStart = 60;
        public bool IsActive { get { return _timeUntilStart <= 0; } }
        public int PointValue { get; private set; }

        public static Random _rand = new Random();
        
        public Enemy(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
            Scale = 0.2f;
            Radius = Texture.Width * Scale/ 2f;
            Color = Color.Transparent;
            PointValue = 1;
        }
        
        public override void Update()
        {
            if (_timeUntilStart <= 0)
                ApplyBehaviours();
            else
            {
                _timeUntilStart--;
                Color = Color.White * (1 - _timeUntilStart / 60f);
            }

            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, MechaRage.ScreenSize - Size * Scale / 2);

            Velocity *= 0.8f;
        }
        
        public void HandleCollision(Enemy other)
        {
            var d = Position - other.Position;
            Velocity += 10 * d / (d.LengthSquared() + 1);
        }
        
        public static Enemy CreateSeeker(Vector2 position)
        {
            var enemy = new Enemy(ArtManager.Enemy, position);
            enemy.AddBehaviour(enemy.FollowPlayer(0.9f));
            enemy.PointValue = 2;

            return enemy;
        }

        public static Enemy CreateWanderer(Vector2 position)
        {
            var enemy = new Enemy(ArtManager.Enemy, position);
            enemy.AddBehaviour(enemy.MoveRandomly());

            return enemy;
        }
        
        private void AddBehaviour(IEnumerable<int> behaviour)
        {
            behaviours.Add(behaviour.GetEnumerator());
        }

        private void ApplyBehaviours()
        {
            for (var i = 0; i < behaviours.Count; i++)
            {
                if (!behaviours[i].MoveNext())
                    behaviours.RemoveAt(i--);
            }
        }
        
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_timeUntilStart > 0)
            {
                // Draw an expanding, fading-out version of the sprite as part of the spawn-in effect.
                var factor = _timeUntilStart / 60f;	// decreases from 1 to 0 as the enemy spawns in
                spriteBatch.Draw(Texture, Position, null, Color.White * factor, Orientation, Size / 2f, Scale - factor, 0, 0);
            }

            base.Draw(spriteBatch);
        }
        
        public void WasShot()
        {
            IsDestroyed = true;
        }
        
        #region Behaviours

        private IEnumerable<int> FollowPlayer(float acceleration)
        {
            while (true)
            {
                Velocity += (PlayerMecha.Instance.Position - Position).ScaleTo(acceleration);

                if (Velocity != Vector2.Zero)
                    Orientation = Velocity.ToAngle() + (float)Math.PI / 2;

                yield return 0;
            }
        }

        private IEnumerable<int> MoveRandomly()
        {
            var direction = _rand.NextFloat(0, MathHelper.TwoPi);

            while (true)
            {
                direction += _rand.NextFloat(-0.1f, 0.1f);
                direction = MathHelper.WrapAngle(direction);

                for (var i = 0; i < 6; i++)
                {
                    Velocity += Extensions.FromPolar(direction, 0.4f);
                    Orientation -= 0.05f;

                    var bounds = MechaRage.Viewport.Bounds;
                    bounds.Inflate(-Texture.Width * Scale / 2 - 1, -Texture.Height * Scale / 2 - 1);

                    // if the enemy is outside the bounds, make it move away from the edge
                    if (!bounds.Contains(Position.ToPoint()))
                        direction = (MechaRage.ScreenSize / 2 - Position).ToAngle();

                    yield return 0;
                }
            }
        }
        #endregion
    }
}