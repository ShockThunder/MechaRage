namespace MechaRage.Entities
{
    using System;

    using global::MechaRage.GameManagers;
    using global::MechaRage.Helpers;
    using global::MechaRage.ResourceManagers;

    using Microsoft.Xna.Framework;

    public class PlayerMecha : BaseEntity
    {
        private static PlayerMecha _instance;
        private static Random _rand = new Random();
        
        /// <summary>
        /// Player speed in *texture sizes*
        /// </summary>
        private const int SPEED = 3;

        /// <summary>
        /// Frames between shoots
        /// </summary>
        private const int COOLDOWN_FRAMES = 6;
        
        /// <summary>
        /// Frames until next shoot
        /// </summary>
        private int _cooldownRemaining = 0;

        public static PlayerMecha Instance
        {
            get
            {
                _instance ??= new PlayerMecha();
                return _instance;
            }
        }

        private PlayerMecha()
        {
            Texture = ArtManager.Player;
            Position = MechaRage.ScreenSize / 2;
            Radius = 10;
            Scale = 0.2f;
        }
        
        
        public override void Update()
        {
            if (InputManager.MakeShoot())
            {
                Shoot();
            }
            
            if (_cooldownRemaining > 0)
            {
                _cooldownRemaining--;
            }

            var direction = InputManager.GetMovementDirection();
            Position += direction * SPEED;
            Position = Vector2.Clamp(Position, Size * Scale / 2, MechaRage.ScreenSize - Size * Scale / 2);
            Orientation = (Position - InputManager.MousePosition).ToAngle() - (float)Math.PI / 2;

        }

        public void Shoot()
        {
            if (_cooldownRemaining <= 0)
            {
                _cooldownRemaining = COOLDOWN_FRAMES;
                var aimAngle = Orientation - (float) Math.PI/2;
 
                var vel = Extensions.FromPolar(aimAngle, 11f);
                
                EntityManager.Add(new Bullet(Position, vel));
            }
        }
    }
}