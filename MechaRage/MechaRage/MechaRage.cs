﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MechaRage
{
    using global::MechaRage.Entities;
    using global::MechaRage.GameManagers;
    using global::MechaRage.ResourceManagers;

    using JetBrains.Annotations;

    public class MechaRage : Game
    {
        public static MechaRage Instance { get; set; }
        public static Viewport Viewport
        {
            get { return Instance.GraphicsDevice.Viewport; }
        }

        public static Vector2 ScreenSize { get { return new Vector2(Viewport.Width, Viewport.Height); } }

        public static GameTime GameTime { get; private set; }

        [UsedImplicitly]
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public MechaRage()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
        }

        [UsedImplicitly]
        protected override void Initialize()
        {
            Content.RootDirectory = "Content";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ArtManager.Load(Content);

            EntityManager.Add(PlayerMecha.Instance);
        }

        protected override void Update(GameTime gameTime)
        {
            GameTime = gameTime;
            InputManager.Update();
            EnemySpawner.Update();
            EntityManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            _spriteBatch.Begin(SpriteSortMode.Texture);
            EntityManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}