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

        private Rectangle _renderDestination;

        private State _currentState;
        private State _nextState;

        private bool _isResizing;

        private int _nativeWidth = 320;
        private int _nativeHeight = 180;

        private RenderTarget2D _renderTarget;

        public void ChangeState(State state)
        {
            _nextState = state; 
        }


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _graphics.PreferredBackBufferWidth = _nativeWidth;
            _graphics.PreferredBackBufferHeight = _nativeHeight;
            _graphics.ApplyChanges();

            Window.AllowUserResizing = true;

            Window.ClientSizeChanged += OnClientSizeChanged;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            CalculateRenderDestination();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content, new Vector2(0, 0));

            _renderTarget = new RenderTarget2D(GraphicsDevice, _nativeWidth, _nativeHeight);

        }

        protected override void Update(GameTime gameTime)
        {
            if(_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }


            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GraphicsDevice.SetRenderTarget(_renderTarget);

            // TODO: Add your drawing code here

            _currentState.Draw(gameTime, _spriteBatch);

            #region RenderFinalImage

            GraphicsDevice.SetRenderTarget(null);

            _spriteBatch.Begin(samplerState : SamplerState.PointClamp);
            _spriteBatch.Draw(_renderTarget, _renderDestination, Color.White);
            _spriteBatch.End();

            #endregion


            base.Draw(gameTime);
        }

        //Function Methodes

        private void OnClientSizeChanged(object sender, EventArgs e)
        {
            if(!_isResizing && Window.ClientBounds.Width > 0 && Window.ClientBounds.Height > 0)
            {
                _isResizing = true;
                CalculateRenderDestination();
                _isResizing = false;
            }
        }

        private void CalculateRenderDestination()
        {
            Point size = GraphicsDevice.Viewport.Bounds.Size;

            float scaleX = (float)size.X / _renderTarget.Width;
            float scaleY = (float)size.Y / _renderTarget.Height;

            float scale = Math.Min(scaleX, scaleY);

            _renderDestination.Width = (int)(_renderTarget.Width * scale);
            _renderDestination.Height = (int)(_renderTarget.Height * scale);

            _renderDestination.X = (size.X - _renderDestination.Width) / 2;
            _renderDestination.Y = (size.Y - _renderDestination.Height) / 2;

        }
    }
}
