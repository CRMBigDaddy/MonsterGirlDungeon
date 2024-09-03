using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.Map;
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

        private Vector2 _mousePos = new Vector2();
        private Vector2 _playerPos = new Vector2();

        private GameMap _map;

        private Texture2D _playerTexture;
        private Player _player; 
        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, MenuState menustate) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _font = content.Load<SpriteFont>("Fonts/File");

            _playerTexture = content.Load<Texture2D>("textures/tiles/maxwell");
            _player = new Player(new Vector2(16, 16),_playerTexture);

            _map = new GameMap(content, 16, 16);

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _map.Draw(gameTime, spriteBatch);
             
            _player.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(_font, "mousePos: " + _mousePos.X + " X, " + _mousePos.Y + " Y ", new Vector2(0, 2) * AppScaleFactor._scaleFactor, Color.White, 0f, new Vector2(0, 0), AppScaleFactor._scaleFactor, SpriteEffects.None, 1);
            spriteBatch.DrawString(_font, "playerPos: " + (int)_playerPos.X + " X, " + (int)_playerPos.Y + " Y ", new Vector2(0, 22) * AppScaleFactor._scaleFactor, Color.White, 0f, new Vector2(0, 0), AppScaleFactor._scaleFactor, SpriteEffects.None, 1);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();


            _mousePos.X = mouseState.X / AppScaleFactor._scaleFactor;
            _mousePos.Y = mouseState.Y / AppScaleFactor._scaleFactor;

            _playerPos = _player.GetPlayerPos();

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
