using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.MenuInterface
{
    internal class Button : Components
    {
        private Texture2D _texture;
        private Vector2 _position;

        private Rectangle _hitbox;

        private MouseState _currentMouse;
        private MouseState _previousMouse;

        public event EventHandler Click;

        public Button(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(0,0), scaleFactor, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width * (int)scaleFactor, _texture.Height * (int)scaleFactor);

            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            if (mouseRectangle.Intersects(_hitbox))
            {

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
        }
    }
}
