using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MechaRage
{
    using JetBrains.Annotations;

    public class MechaRage : Game
    {
        [UsedImplicitly]
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Player _player = new Player();
        private MouseState _currentMouseState;

        public MechaRage()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        [UsedImplicitly]
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _player.SetTexture(Content.Load<Texture2D>("Tank"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            
            _currentMouseState = Mouse.GetState();
            
            var elapsedTime = gameTime.ElapsedGameTime.TotalMilliseconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(Keyboard.GetState().IsKeyDown(Keys.A))
                _player.MoveLeft(elapsedTime);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                _player.MoveRight(elapsedTime);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                _player.MoveUp(elapsedTime);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                _player.MoveDown(elapsedTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                _player.GetTexture(), 
                _player.GetPosition(), 
                null, 
                Color.White, 
                _player.GetRotation(_currentMouseState), 
                _player.GetOrigin(), 
                _player.GetScale(), 
                SpriteEffects.None, 
                0);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}