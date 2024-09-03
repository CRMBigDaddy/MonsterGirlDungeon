using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Xna.Framework.Content;

namespace MonsterGirlDungeon.Map
{
    internal class GameMap : Components
    {
        private SpriteFont _font;


        public GameMap(ContentManager content, int tileSizeX, int tileSizeY) 
        {
            _font = content.Load<SpriteFont>("Fonts/File");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
