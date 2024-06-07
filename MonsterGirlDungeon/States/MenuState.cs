using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonsterGirlDungeon.MenuInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.States
{

    internal class MenuState : State
    {

        private GraphicsDeviceManager _graphics;

        private List<Components> _components;
        private List<Components> _hiddenComponents;

        private bool _showOptions = false;

        public event EventHandler changeRes;


        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics) : base(game, graphicsDevice, content)
        {
            _graphics = graphics;

            Texture2D optionButtontexture = _content.Load<Texture2D>("textures/ButtonOptionos");
            Vector2 optionButtonPos = new Vector2(10, 70);

            Button optionsButton = new Button(optionButtontexture, optionButtonPos);
            optionsButton.Click += optionsButton_Click;

            _components = new List<Components>()
            {
                optionsButton,
            };

            Texture2D resButtonTexture = _content.Load<Texture2D>("textures/ResolutionButton");
            Vector2 resButtonPos = new Vector2(10, 10);

            Button resButton = new Button(resButtonTexture, resButtonPos);
            resButton.Click += ResButton_Click;

            _hiddenComponents = new List<Components>()
            {
                resButton,
            };
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            if(!_showOptions)
            {
                _showOptions = true;
            }
            else if(_showOptions)
            {
                _showOptions = false;
            }
        }

        private void ResButton_Click(object sender, EventArgs e)
        {
            foreach (var component in _components)
            {
                component.ChangeScaleFactor(1);
            }


            _graphics.PreferredBackBufferHeight += 180;
            _graphics.PreferredBackBufferWidth += 320;

            _graphics.ApplyChanges();

        }

        //Main Methode Region

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(samplerState : SamplerState.PointClamp);

            foreach(var component in _components) 
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

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        //Logic Method Region

    }
}
