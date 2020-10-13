using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MechaRage
{
    public class MechaRage : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Player _player = new Player();

        public MechaRage()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = this.Content.Load<Texture2D>("Tanks");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
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
            _spriteBatch.Draw(_texture, new Vector2(_player.GetX(), _player.GetY()), new Rectangle(new Point(102,74), new Point(236,320)), Color.White, 0, new Vector2(0,0), new Vector2((float)0.2, (float)0.2), SpriteEffects.None, 0);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}