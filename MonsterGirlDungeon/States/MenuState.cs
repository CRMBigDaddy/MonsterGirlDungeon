using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonsterGirlDungeon.MenuInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.States
{

    internal class MenuState : State
    {
        private Game1 _game;
        private GraphicsDeviceManager _graphics;
        private ContentManager _content;


        private List<Components> _components;
        private List<Components> _hiddenComponents;

        private Texture2D _buttonTexture;
        private SpriteFont font;

        private Vector2 _mousePos = new Vector2();

        private bool _showOptions = false;
        private bool _showDebug = false;



        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics) : base(game, graphicsDevice, content)
        {
            _game = game;
            _graphics = graphics;
            _content = content;

            _buttonTexture = _content.Load<Texture2D>("textures/uiElements/BetterButton");

            MainMenu();
            OptionsMenu();

            font = content.Load<SpriteFont>("Fonts/File");
        }

        //Main Methode Region

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState : SamplerState.PointClamp);

            foreach (var component in _components) 
            {
                component.Draw(gameTime, spriteBatch);
            }

            if(_showOptions)
            {
                foreach (var component in _hiddenComponents)
                {
                    component.Draw(gameTime, spriteBatch);
                }

            }

            if(_showDebug)
            {
                spriteBatch.DrawString(font, "mousePos: " + _mousePos.X + " X, " + _mousePos.Y + " Y ", new Vector2(0, 0),Color.White, 0f, new Vector2(0,0), AppScaleFactor._scaleFactor, SpriteEffects.None, 1);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }

            if (_showOptions)
            {
                foreach (var component in _hiddenComponents)
                {
                    component.Update(gameTime);
                }
            }
            MouseState mouseState = Mouse.GetState();

            _mousePos.X = mouseState.X / AppScaleFactor._scaleFactor;
            _mousePos.Y = mouseState.Y / AppScaleFactor._scaleFactor;
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void UnLoadState()
        {
            _showOptions = false;
            _showDebug = false;
        }

        //Logic Method Region

        //Menus Setup
        #region Menu SetUp
        private void MainMenu()
        {
            Vector2 playButtonPos = new Vector2(5,5);
            Button playButton = new Button(_content, _buttonTexture, playButtonPos, "Play", new Vector2(0, 2));
            playButton.Click += playButton_Click;

            Vector2 optionButtonPos = new Vector2(5, 35);
            Button optionsButton = new Button(_content, _buttonTexture, optionButtonPos, "Options", new Vector2(0, 2));
            optionsButton.Click += optionsButton_Click;

            Vector2 exitButtonPos = new Vector2(5, 65);
            Button exitButton = new Button(_content, _buttonTexture, exitButtonPos, "Exit", new Vector2(0, 2));
            exitButton.Click += ExitButton_Click;

            _components = new List<Components>()
            {
                playButton,
                optionsButton,
                exitButton,
            };
        }

        private void OptionsMenu()
        {

            Vector2 resButtonPos = new Vector2(150, 5);
            Button resButton = new Button(_content, _buttonTexture, resButtonPos, "180 x 320", new Vector2(0, 2));
            resButton.Click += ResButton_Click;

            Vector2 resButton2Pos = new Vector2(150, 40);
            Button resButton2 = new Button(_content, _buttonTexture, resButton2Pos, "360 x 640", new Vector2(0, 2));
            resButton2.Click += ResButton2_Click;

            Vector2 resButton3Pos = new Vector2(150, 75);
            Button resButton3 = new Button(_content, _buttonTexture, resButton3Pos, "540 x 960", new Vector2(0, 2));
            resButton3.Click += ResButton3_Click;

            Vector2 resButton4Pos = new Vector2(150, 110);
            Button resButton4 = new Button(_content, _buttonTexture, resButton4Pos, "720 x 1280", new Vector2(0, 2));
            resButton4.Click += ResButton4_Click;

            Vector2 resButton5Pos = new Vector2(150, 145);
            Button resButton5 = new Button(_content, _buttonTexture, resButton5Pos, "1080 x 1920", new Vector2(0, 2));
            resButton5.Click += ResButton5_Click;

            Vector2 debugButtonPos = new Vector2(5, 140);
            Button debugButton = new Button(_content, _buttonTexture, debugButtonPos, "Debug", new Vector2(0, 2));
            debugButton.Click += DeBugButton_Click;


            _hiddenComponents = new List<Components>()
            {
                resButton,
                resButton2,
                resButton3,
                resButton4,
                resButton5,

                debugButton,
            };
        }


        #endregion
        //Button Events
        #region Button Events

        private void playButton_Click(object sender, EventArgs e)
        {
            _game.ChangeToGameState();
        }

        private void DeBugButton_Click(object sender, EventArgs e)
        {
            if (!_showDebug)
            {
                _showDebug = true;
            }
            else if (_showDebug)
            {
                _showDebug = false;
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            if (!_showOptions)
            {
                _showOptions = true;
            }
            else if (_showOptions)
            {
                _showOptions = false;
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void ResButton_Click(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferHeight = 180;
            _graphics.PreferredBackBufferWidth = 320;

            AppScaleFactor._scaleFactor = 1;

            foreach (var component in _components)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }
            foreach (var component in _hiddenComponents)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }

            _graphics.ApplyChanges();

        }

        private void ResButton2_Click(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferHeight = 360;
            _graphics.PreferredBackBufferWidth = 640;

            AppScaleFactor._scaleFactor = 2;

            foreach (var component in _components)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }
            foreach (var component in _hiddenComponents)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }

            _graphics.ApplyChanges();

        }

        private void ResButton3_Click(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferHeight = 540;
            _graphics.PreferredBackBufferWidth = 960;

            AppScaleFactor._scaleFactor = 3;

            foreach (var component in _components)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }
            foreach (var component in _hiddenComponents)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }

            _graphics.ApplyChanges();

        }

        private void ResButton4_Click(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.PreferredBackBufferWidth = 1280;

            AppScaleFactor._scaleFactor = 4;

            foreach (var component in _components)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }
            foreach (var component in _hiddenComponents)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }

            _graphics.ApplyChanges();

        }

        private void ResButton5_Click(object sender, EventArgs e)
        {
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;

            AppScaleFactor._scaleFactor = 6;

            foreach (var component in _components)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }
            foreach (var component in _hiddenComponents)
            {
                component.ChangeScaleFactor(AppScaleFactor._scaleFactor);
            }

            _graphics.ApplyChanges();

        }
        #endregion

        public int GetCurrentMenuscale()
        {
            int currentMenuScale = AppScaleFactor._scaleFactor;
            return currentMenuScale;
        }
    }
}
