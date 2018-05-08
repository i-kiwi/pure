using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace scene
{
    public class MapGenerator : MonoBehaviour
    {
        public int width;
        public int height;
        // 平滑次数
        public int firstSmooth = 4;
        public int secondSmooth = 3;
        // 分布指数
        public int randomFillPercent = 40;
        // 地图碎片
        public Sprite[] spriteList;
        // 瓦片地图
        public Tilemap tilemap;

        // 随机种子
        private string seed;
        private bool useRandomSeed = true;

        // 瓦片规则
        private RuleTile ruleTile;

        private int[,] map;


        void Start()
        {
            GenerateMap();
            initRules();
            initMap();
        }

        private void initRules()
        {
            ruleTile = ScriptableObject.CreateInstance<RuleTile>();
            ruleTile.m_DefaultSprite = spriteList[4];
            List<RuleTile.TilingRule> rules = RuleTileDetail.getRuleDetails();
            for (int i = 0; i < rules.Count && i < spriteList.Length; i++)
            {
                rules[i].m_Sprites = new Sprite[1] { spriteList[i] };
            }
            ruleTile.m_TilingRules = rules;
        }

        private void GenerateMap()
        {
            map = new int[width, height];
            RandomFillMap();
        }

        private void RandomFillMap()
        {
            if (useRandomSeed)
            {
                seed = Random.Range(0, 100000).ToString();
            }
            
            System.Random pseudoRandom = new System.Random(seed.GetHashCode());

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        map[x, y] = 1;
                    }
                    else
                    {
                        map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                    }
                }
            }
        }

        private void SmoothMap()
        {
            int[,] tempMap = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int firstLayerCount = GetSurroundingWallCount(x, y, 1);
                    int secondLayerCount = GetSurroundingWallCount(x, y, 2);

                    int flag = map[x, y] == 1 ? 4 : 5;
                    if (firstSmooth > 0)
                    {
                        tempMap[x, y] = firstLayerCount >= flag || secondLayerCount <= 2 ? 1 : 0;
                    }
                    else if (secondSmooth > 0)
                    {
                        tempMap[x, y] = firstLayerCount >= flag ? 1 : 0;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            map = tempMap;
        }

        private int GetSurroundingWallCount(int gridX, int gridY, int layer)
        {
            int wallCount = 0;
            for (int neighbourX = gridX - layer; neighbourX <= gridX + layer; neighbourX++)
            {
                for (int neighbourY = gridY - layer; neighbourY <= gridY + layer; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                        {
                            wallCount += map[neighbourX, neighbourY];
                        }
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }

        private void initMap()
        {
            for (int i = 0; i < 25; i++)
            {
                SmoothMap();
                if (firstSmooth > 0)
                    firstSmooth--;
                else if (secondSmooth > 0)
                    secondSmooth--;
                else
                    break;
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (map[x, y] == 1)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, 0), ruleTile);
                    }
                }
            }
        }
    }
}