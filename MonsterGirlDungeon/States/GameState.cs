using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.Tiles;
using System;
using System.Collections.Generic;
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

        private bool _stateLoaded = false;

        private List<Components> _tiles;

        private Texture2D _testTileTexture;
        private int tileDrawerXPos;
        private int tileDrawerYPos;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, MenuState menustate) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _font = content.Load<SpriteFont>("Fonts/File");

            _testTileTexture = content.Load<Texture2D>("textures/tiles/maxwell");

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            for (int x = 0; x < 16; x++)
            {

                tileDrawerXPos += 16;
                spriteBatch.Draw(_testTileTexture, new Vector2(tileDrawerXPos, tileDrawerYPos) * AppScaleFactor._scaleFactor, null, Color.White, 0f, new Vector2(0, 0), AppScaleFactor._scaleFactor, SpriteEffects.None, 1);

                for (int y = 0; y < 16; y++)
                {

                    tileDrawerYPos += 16;
                    spriteBatch.Draw(_testTileTexture, new Vector2(tileDrawerXPos, tileDrawerYPos) * AppScaleFactor._scaleFactor, null, Color.White, 0f, new Vector2(0, 0), AppScaleFactor._scaleFactor, SpriteEffects.None, 1);
                }
                tileDrawerYPos = 0;
            }
            tileDrawerXPos = 0;



            spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {



            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.ChangeToMenuState();
                _stateLoaded = false;
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

    }
}
