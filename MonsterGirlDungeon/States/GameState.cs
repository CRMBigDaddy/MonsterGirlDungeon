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

        private Texture2D _playerTexture;
        private Player _player; 

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, MenuState menustate) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _font = content.Load<SpriteFont>("Fonts/File");

            _tileTextureSheetMap1 = content.Load<Texture2D>("textures/tiles/testTileMap3");
            map1 = new Map
                (
                    _content,
                    //tiles in tile sheet, need to be square = A x A
                    new Vector2(10, 10),
                    //Map paths
                    "../../../Data/maps/ProtoTypMap0.1/ProTyp_Collision.csv",
                    "../../../Data/maps/ProtoTypMap0.1/ProTyp_fg.csv",
                    "../../../Data/maps/ProtoTypMap0.1/ProTyp_mg.csv",
                    "../../../Data/maps/ProtoTypMap0.1/ProTyp_bg.csv",
                    //tile Sheet with textures
                    _tileTextureSheetMap1
                );

            _playerTexture = content.Load<Texture2D>("textures/tiles/maxwell");
            _player = new Player(new Vector2(32, 32),_playerTexture);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            map1.DrawMap(gameTime, spriteBatch);
            _player.Draw(gameTime, spriteBatch);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {
            _player.Update(gameTime);


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
