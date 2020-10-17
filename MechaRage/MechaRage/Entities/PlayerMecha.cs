namespace MechaRage.Entities
{
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

        public PlayerMecha()
        {
            Texture = ArtManager.Player;
            Position = MechaRage.ScreenSize / 2;
            Radius = 10;
            Scale = 0.2f;
        }

        public override void Update()
        {
            const float speed = 8;
            Velocity += speed * InputManager.GetMovementDirection();
            Position += Velocity;
            Position = Vector2.Clamp(Position, Size / 2, MechaRage.ScreenSize - Size / 2);

            if (Velocity.LengthSquared() > 0)
            {
                Orientation = Velocity.ToAngle();
            }
        }
    }
}