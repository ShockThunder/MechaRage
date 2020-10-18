namespace MechaRage.GameManagers
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public static class InputManager
    {
        private static KeyboardState _keyboardState;
        private static KeyboardState _oldKeyboardState;
        private static MouseState _mouseState;
        private static MouseState _oldMouseState;

        public static Vector2 MousePosition { get { return new Vector2(_mouseState.X, _mouseState.Y); } }

        public static void Update()
        {
            _oldKeyboardState = _keyboardState;
            _oldMouseState = _mouseState;

            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
        }

        /// <summary>
        /// Checks if a key was just pressed down
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool WasKeyPressed(Keys key)
        {
            return _oldKeyboardState.IsKeyUp(key) && _keyboardState.IsKeyDown(key);
        }

        public static Vector2 GetMovementDirection()
        {
            var direction = Vector2.Zero;

            if (_keyboardState.IsKeyDown(Keys.A))
            {
                direction.X -= 1;
            }

            if (_keyboardState.IsKeyDown(Keys.D))
            {
                direction.X += 1;
            }

            if (_keyboardState.IsKeyDown(Keys.W))
            {
                direction.Y -= 1;
            }

            if (_keyboardState.IsKeyDown(Keys.S))
            {
                direction.Y += 1;
            }

            // Clamp the length of the vector to a maximum of 1.
            if (direction.LengthSquared() > 1)
            {
                direction.Normalize();
            }

            return direction;
        }
    }
}