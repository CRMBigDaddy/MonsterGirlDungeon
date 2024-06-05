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
        private int menuStateResHeight = 180;
        private int menuStateResWidth = 320;

        private GraphicsDeviceManager _graphics;

        private List<Components> _components;

        public event EventHandler changeRes;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, GraphicsDeviceManager graphics) : base(game, graphicsDevice, content)
        {
            _graphics = graphics;

            Texture2D resButtonTexture = _content.Load<Texture2D>("textures/ButtonPlay");
            Vector2 resButtonPos = new Vector2(0, 0);

            Button resButton = new Button(resButtonTexture, resButtonPos);

            resButton.Click += ResButton_Click;

            _components = new List<Components>()
            {
                resButton,
            };
        }

        private void ResButton_Click(object sender, EventArgs e)
        {
            foreach (var component in _components)
            {
                component.ChangeScaleFactor(1);
            }

            menuStateResHeight += 180;
            menuStateResWidth += 320;

            _graphics.PreferredBackBufferHeight = menuStateResHeight;
            _graphics.PreferredBackBufferWidth = menuStateResWidth;

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
