using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.Tiles
{
    internal class Tile : Components
    {

        private String _tileID;
        private Vector2 _tileScale;
        private Texture2D _texture;
        private Vector2 _tilePos;
        private Vector2 _tileOrigin;

        private SpriteFont _font;


        public Tile(string tileID, Texture2D texture, Vector2 tilePos, ContentManager content)
        {
            _tileID = tileID;
            _texture = texture;
            _tilePos = tilePos;
            _tileOrigin = new Vector2(0, 0);

        }



        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(_font, _tileID , _tilePos, Color.White, 0f, _tileOrigin, scaleFactor, SpriteEffects.None, 1);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
