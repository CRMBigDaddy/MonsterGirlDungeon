using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private int _gameScaleTracker;

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, MenuState menustate) : base(game, graphicsDevice, content)
        {
            _game = game;
            _content = content;
            _font = content.Load<SpriteFont>("Fonts/File");

            _gameScaleTracker = menustate.GetCurrentMenuscale();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            spriteBatch.DrawString(_font,"We are in Game", new Vector2(0, 0), Color.White, 0f, new Vector2(0, 0), _gameScaleTracker, SpriteEffects.None, 1);

            spriteBatch.End();

        }

        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _game.ChangeToMenuState();
            }
        }
        public override void PostUpdate(GameTime gameTime)
        {

        }
    }
}
