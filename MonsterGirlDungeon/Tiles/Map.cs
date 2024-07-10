using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        private Vector2 _mapScale;

        private Dictionary<Vector2, int> _collsionLayer;
        private Dictionary<Vector2, int> _forGroundLayer;
        private Dictionary<Vector2, int> _middleGroundLayer;
        private Dictionary<Vector2, int> _backGroundLayer;

        private Texture2D _tileTextureSheet;

        public Map(ContentManager content, Vector2 mapScale, string collisonLayerPather, string forGroundLayerPath, string middleGroundLayerPath, string backGroundLayerPath, Texture2D tileTExtureSheet) 
        {

             _mapScale = mapScale;

            _collsionLayer = LoadMap(collisonLayerPather);
            _forGroundLayer = LoadMap(forGroundLayerPath);
            _middleGroundLayer = LoadMap(middleGroundLayerPath);
            _backGroundLayer = LoadMap(backGroundLayerPath);

            _tileTextureSheet = tileTExtureSheet;
        }



        public void DrawMap(GameTime gameTime, SpriteBatch spriteBatch)
        {

            int pixelTileSize = 16;

            //CollisionLayer
            foreach (var item in _collsionLayer)
            {
                Rectangle dest = new
                    (
                    ((int)item.Key.X * 32 * AppScaleFactor._scaleFactor),
                    ((int)item.Key.Y * 32 * AppScaleFactor._scaleFactor),
                    32 * AppScaleFactor._scaleFactor, 32 * AppScaleFactor._scaleFactor
                    );
                int x = item.Value % ((int)_mapScale.X);
                int y = item.Value / ((int)_mapScale.Y);
                Rectangle src = new
                    (
                        x * pixelTileSize, y * pixelTileSize,
                        pixelTileSize, pixelTileSize  
                    );
                spriteBatch.Draw(_tileTextureSheet, dest, src, Color.White);
            }
            //for Ground Layer
            foreach (var item in _forGroundLayer)
            {
                Rectangle dest = new
                    (
                    ((int)item.Key.X * 32 * AppScaleFactor._scaleFactor),
                    ((int)item.Key.Y * 32 * AppScaleFactor._scaleFactor),
                    32 * AppScaleFactor._scaleFactor, 32 * AppScaleFactor._scaleFactor
                    );
                int x = item.Value % ((int)_mapScale.X);
                int y = item.Value / ((int)_mapScale.Y);
                Rectangle src = new
                    (
                        x * pixelTileSize, y * pixelTileSize,
                        pixelTileSize, pixelTileSize
                    );
                spriteBatch.Draw(_tileTextureSheet, dest, src, Color.White);
            }
            //middle Ground layer
            foreach (var item in _middleGroundLayer)
            {
                Rectangle dest = new
                    (
                    ((int)item.Key.X * 32 * AppScaleFactor._scaleFactor),
                    ((int)item.Key.Y * 32 * AppScaleFactor._scaleFactor),
                    32 * AppScaleFactor._scaleFactor, 32 * AppScaleFactor._scaleFactor
                    );
                int x = item.Value % ((int)_mapScale.X);
                int y = item.Value / ((int)_mapScale.Y);
                Rectangle src = new
                    (
                        x * pixelTileSize, y * pixelTileSize,
                        pixelTileSize, pixelTileSize
                    );
                spriteBatch.Draw(_tileTextureSheet, dest, src, Color.White);
            }
            //background layer
            foreach (var item in _backGroundLayer)
            {
                Rectangle dest = new
                    (
                    ((int)item.Key.X * 32 * AppScaleFactor._scaleFactor),
                    ((int)item.Key.Y * 32 * AppScaleFactor._scaleFactor),
                    32 * AppScaleFactor._scaleFactor, 32 * AppScaleFactor._scaleFactor
                    );
                int x = item.Value % ((int)_mapScale.X);
                int y = item.Value / ((int)_mapScale.Y);
                Rectangle src = new
                    (
                        x * pixelTileSize, y * pixelTileSize,
                        pixelTileSize, pixelTileSize
                    );
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
                        if (value != -1)
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
