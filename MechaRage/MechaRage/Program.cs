using System;

namespace MechaRage
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new MechaRage())
                game.Run();
        }
    }
}