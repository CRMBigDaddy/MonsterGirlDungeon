using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MonsterGirlDungeon.Tiles
{
    internal class Map
    {
        private Dictionary<Vector2, int> _tilemap;
        private List<Rectangle> _textureStore;

        private Texture2D _tileTextureSheet;
        public Map(ContentManager content, string mapFilePath, Texture2D tileTExtureSheet, List<Rectangle> textureStore) 
        {
            _tileTextureSheet = tileTExtureSheet;
            _tilemap = LoadMap(mapFilePath);

            _textureStore = textureStore;
            
        }

        public void DrawMap(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var item in _tilemap)
            {
                Rectangle dest = new(
                    ((int)item.Key.X * 16 * AppScaleFactor._scaleFactor),
                    ((int)item.Key.Y * 16 * AppScaleFactor._scaleFactor),
                    16 * AppScaleFactor._scaleFactor,
                    16 * AppScaleFactor._scaleFactor
                    );

                Rectangle src = _textureStore[item.Value - 1];

                spriteBatch.Draw(_tileTextureSheet, dest, src, Color.White);

            }
        }

        private Dictionary<Vector2, int> LoadMap(string filepath)
        {
            Dictionary<Vector2, int> result = new();

            StreamReader reader = new(filepath);

            string line;
            int y = 0;

            while ((line = reader.ReadLine()) != null)
            {
                string[] items = line.Split(',');

                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int value))
                    {
                        if (value > 0)
                        {
                            result[new Vector2(x, y)] = value;
                        }
                    }

                }
                y++;

            }

            return result;
        }

    }
}
