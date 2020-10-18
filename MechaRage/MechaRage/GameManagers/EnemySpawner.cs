namespace MechaRage.GameManagers
{
    using System;

    using global::MechaRage.Entities;

    using Microsoft.Xna.Framework;

    public static class EnemySpawner
    {
        private static Random _rand = new Random();
        private static float _inverseSpawnChance = 90;

        public static void Update()
        {
            if (EntityManager.Count < 10)
            {
                if (_rand.Next((int)_inverseSpawnChance) == 0)
                    EntityManager.Add(Enemy.CreateSeeker(GetSpawnPosition()));

                if (_rand.Next((int)_inverseSpawnChance) == 0)
                    EntityManager.Add(Enemy.CreateWanderer(GetSpawnPosition()));
            }
			
            // slowly increase the spawn rate as time progresses
            if (_inverseSpawnChance > 30)
                _inverseSpawnChance -= 0.005f;
        }

        private static Vector2 GetSpawnPosition()
        {
            Vector2 pos;
            do
            {
                pos = new Vector2(_rand.Next((int)MechaRage.ScreenSize.X), _rand.Next((int)MechaRage.ScreenSize.Y));
            } 
            while (Vector2.DistanceSquared(pos, PlayerMecha.Instance.Position) < 250 * 250);

            return pos;
        }

        public static void Reset()
        {
            _inverseSpawnChance = 90;
        }
    }
}