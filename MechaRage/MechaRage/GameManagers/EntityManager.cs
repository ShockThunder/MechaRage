namespace MechaRage.GameManagers
{
    using System.Collections.Generic;
    using System.Linq;

    using global::MechaRage.Entities;

    using Microsoft.Xna.Framework.Graphics;

    public static class EntityManager
    {
        private static List<BaseEntity> _entities = new List<BaseEntity>();

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
                _entities.Add(entity);
            }
        }

        public static void Update()
        {
            _isUpdating = true;

            foreach (var entity in _entities)
            {
                entity.Update();
            }

            _isUpdating = false;

            foreach (var entity in _entitiesToAdd)
            {
                _entities.Add(entity);
            }

            _entitiesToAdd.Clear();

            _entities = _entities.Where(x => !x.IsDestroyed).ToList();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (var entity in _entities)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}