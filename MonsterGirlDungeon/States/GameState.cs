using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;



namespace MonsterGirlDungeon.States
{
    internal class GameState : State
    {
        private Game1 _game;
        private GraphicsDeviceManager _graphics;
        private SpriteFont _font;

        private Map map1;
        private Texture2D _tileTextureSheetMap1;


        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, MenuState menustate) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _font = content.Load<SpriteFont>("Fonts/File");

            _tileTextureSheetMap1 = content.Load<Texture2D>("textures/tiles/testTileMap");
            map1 = new Map
                (
                    _content,

                    //Map path
                    "C:\\Users\\Haico\\Desktop\\MGD\\MonsterGirlDungeon\\MonsterGirlDungeon\\Content\\bin\\maps.csv",

                    //tile Sheet with textures
                    _tileTextureSheetMap1,

                    //tile texture position on tile sheet and tile size
                    new List<Rectangle>
                    {
                        new Rectangle(0, 0,     16, 16),
                        new Rectangle(16, 0,    16, 16),
                        new Rectangle(0, 16,    16, 16),
                        new Rectangle(16, 16,   16, 16)
                    }
                );

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            map1.DrawMap(gameTime, spriteBatch);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {



            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.ChangeToMenuState();
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void UnLoadState()
        {

        }

    }
}
