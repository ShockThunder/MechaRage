using System;

namespace MechaRage
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = new MechaRage();
            game.Run();
        }
    }
}