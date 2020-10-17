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
            const int speed = 3;
            var direction = InputManager.GetMovementDirection();
            Position += direction * speed;
            Position = Vector2.Clamp(Position, Size * Scale / 2, MechaRage.ScreenSize - Size * Scale / 2);
            Orientation = (Position - InputManager.MousePosition).ToAngle() - (float)Math.PI / 2;

        }
    }
}