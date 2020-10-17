namespace MechaRage.ResourceManagers
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class ArtManager
    {
        public static Texture2D Player { get; private set; }

        public static void Load(ContentManager content)
        {
            Player = content.Load<Texture2D>("Art/Player");
        }
    }
}