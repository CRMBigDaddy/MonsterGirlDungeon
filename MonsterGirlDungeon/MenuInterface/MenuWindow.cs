using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.MenuInterface
{
    internal class MenuWindow : Components
    {
        private Texture2D _texture;

        private Vector2 _position;
        private Vector2 _originalPsoition;


        public MenuWindow(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;

            _originalPsoition = _position;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(0, 0), scaleFactor, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
            RefreshWindowScale();
        }

        private void RefreshWindowScale()
        {
            _position = _originalPsoition * scaleFactor;
        }
    }
}
