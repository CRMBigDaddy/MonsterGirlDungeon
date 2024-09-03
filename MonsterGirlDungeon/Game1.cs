using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.States;
using System;


namespace MonsterGirlDungeon
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private State _currentState;

        private MenuState _menuState;
        private GameState _gameState;

        private int _nativeHeight = 180;
        private int _nativeWidth = 320;

        public void ChangeToGameState()
        {
            _currentState = _gameState;
            _menuState.UnLoadState();
        }
        public void ChangeToMenuState()
        {
            _currentState = _menuState;
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = _nativeWidth;
            _graphics.PreferredBackBufferHeight = _nativeHeight;
            _graphics.ApplyChanges();

            Window.AllowUserResizing = false;

            IsMouseVisible = true;

            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _menuState = new MenuState(this, _graphics.GraphicsDevice, Content, _graphics);
            _currentState = _menuState;

            _gameState = new GameState(this, _graphics.GraphicsDevice, Content, _menuState);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (_nextState != null)
            //{
            //    _currentState = _nextState;

            //    _nextState = null;
            //}


            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _currentState.Draw(gameTime, _spriteBatch);


            base.Draw(gameTime);
        }

        //Function Methodes
        
    }
}
