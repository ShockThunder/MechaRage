namespace MechaRage.GameManagers
{
    using System.Collections.Generic;
    using System.Linq;

    using global::MechaRage.Entities;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public static class EntityManager
    {
        private static List<BaseEntity> _entities = new List<BaseEntity>();
        private static List<Enemy> _enemies = new List<Enemy>();
        private static List<Bullet> _bullets = new List<Bullet>();

        private static bool _isUpdating;

        private static List<BaseEntity> _entitiesToAdd = new List<BaseEntity>();

        public static int Count
        {
            get { return _entities.Count; }
        }

        public static void Add(BaseEntity entity)
        {
            if (_isUpdating)
            {
                _entitiesToAdd.Add(entity);
            }
            else
            {
                AddEntity(entity);
            }
        }

        private static void AddEntity(BaseEntity entity)
        {
            _entities.Add(entity);
            if (entity is Bullet)
                _bullets.Add(entity as Bullet);
            else if (entity is Enemy)
                _enemies.Add(entity as Enemy);
        }
        
        public static void Update()
        {
            _isUpdating = true;
            HandleCollisions();
            foreach (var entity in _entities)
            {
                entity.Update();
            }

            _isUpdating = false;

            foreach (var entity in _entitiesToAdd)
            {
                AddEntity(entity);
            }

            _entitiesToAdd.Clear();

            _entities = _entities.Where(x => !x.IsDestroyed).ToList();
            _bullets = _bullets.Where(x => !x.IsDestroyed).ToList();
            _enemies = _enemies.Where(x => !x.IsDestroyed).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in _entities)
            {
                entity.Draw(spriteBatch);
            }
        }
        
        private static void HandleCollisions()
        {
            // handle collisions between enemies
            for (var i = 0; i < _enemies.Count; i++)
            for (var j = i + 1; j < _enemies.Count; j++)
            {
                if (IsColliding(_enemies[i], _enemies[j]))
                {
                    _enemies[i].HandleCollision(_enemies[j]);
                    _enemies[j].HandleCollision(_enemies[i]);
                }
            }

            // handle collisions between bullets and enemies
            for (var i = 0; i < _enemies.Count; i++)
            for (var j = 0; j < _bullets.Count; j++)
            {
                if (IsColliding(_enemies[i], _bullets[j]))
                {
                    _enemies[i].WasShot();
                    _bullets[j].IsDestroyed = true;
                }
            }

            // handle collisions between the player and enemies
            for (var i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].IsActive && IsColliding(PlayerMecha.Instance, _enemies[i]))
                {
                    //KillPlayer();
                    break;
                }
            }
        }
        
        private static bool IsColliding(BaseEntity a, BaseEntity b)
        {
            var radius = a.Radius + b.Radius;
            return !a.IsDestroyed && !b.IsDestroyed && Vector2.DistanceSquared(a.Position, b.Position) < radius * radius;
        }
    }
}