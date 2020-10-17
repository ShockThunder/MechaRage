namespace MechaRage.Helpers
{
    using System;

    using Microsoft.Xna.Framework;

    public static class Extensions
    {
        public static float ToAngle(this Vector2 vector)
        {
            return (float)Math.Atan2(vector.Y, vector.X);
        }
    }
}