using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
        private Vector2 _originalPsoition;

        private String _text = " ";
        private Vector2 _textPosition = new Vector2();
        private Vector2 _textOrigion = new Vector2();
        private Vector2 _originaltextPosiiton = new Vector2();

        private SpriteFont _font;

        private Rectangle _hitbox;

        private MouseState _currentMouse;
        private MouseState _previousMouse;

        private Color buttonColor = Color.White;

        public event EventHandler Click;

        public Button(ContentManager content, Texture2D texture, Vector2 position, string text)
        {
            _font = content.Load<SpriteFont>("Fonts/File");

            _texture = texture;
            _position = position;
            _text = text;
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width * (int)scaleFactor, _texture.Height * (int)scaleFactor);
            _originalPsoition = _position;

            _textPosition.X = _position.X + _texture.Width / 2;
            _textPosition.Y = _position.Y + _texture.Height / 2;

            _textOrigion = _font.MeasureString(_text) / 2;

            _originaltextPosiiton = _textPosition;
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, buttonColor, 0f, new Vector2(0,0), scaleFactor, SpriteEffects.None, 1);
            spriteBatch.DrawString(_font, _text, _textPosition, Color.Red, 0f, _textOrigion, scaleFactor, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            RefreschButtonScale();

            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            if (mouseRectangle.Intersects(_hitbox))
            {
                buttonColor = Color.Gray;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                buttonColor = Color.White;
            }
        }

        private void RefreschButtonScale()
        {
            _position = _originalPsoition * scaleFactor;
            _textPosition = _originaltextPosiiton * scaleFactor;
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, _texture.Width * (int)scaleFactor, _texture.Height * (int)scaleFactor);
        }

    }
}
