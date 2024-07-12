using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MonsterGirlDungeon
{
    internal class Player : Components
    {
        private Vector2 _playerSpawnPosition = Vector2.Zero;
        private Rectangle _playerHitbox;
        private Texture2D _playerTexture;

        public Player(Vector2 playerSpawnPosition, Texture2D playerTexture)
        {
            _playerSpawnPosition = playerSpawnPosition;
            _playerTexture = playerTexture;

            _playerHitbox = new Rectangle((int)_playerSpawnPosition.X, (int)_playerSpawnPosition.Y, 32, 32);

        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_playerTexture, _playerHitbox, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            _playerHitbox.Width = 32 * AppScaleFactor._scaleFactor;
            _playerHitbox.Height = 32 * AppScaleFactor._scaleFactor;

            PlayerMovment();

        }

        private void PlayerMovment()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _playerHitbox.Y -= 1;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _playerHitbox.Y += 1;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _playerHitbox.X -= 1;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _playerHitbox.X += 1;

            }
        }

        public Vector2 GetPlayerPos()
        {
            Vector2 playerPos;

            playerPos.X = _playerHitbox.X;
            playerPos.Y = _playerHitbox.Y;

            return playerPos; 
        }
    }

}
