using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour
{

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    public Texture texture;

    [Range(0, 100)]
    public int randomFillPercent;

    int[,] map;

    public GameObject groundSprite;

    void Start()
    {
        GenerateMap();
        initMap();
    }

    private void Awake()
    {
        OnDrawGizmos();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    void initMap()
    {
        //map = new int[width, height];
        //for (int i = 0; i < 10; i ++)
        //{
        //    Vector3 point = new Vector3(i, 0, 0);
        //    Instantiate(groundSprite, point, Quaternion.identity);
        //}
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (map[i, j] == 1)
                {
                    Vector3 point = new Vector3(i, j, 0);
                    Instantiate(groundSprite, point, Quaternion.identity);
                }

            }
        }
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();

        for (int i = 0; i < 5; i++)
        {
            SmoothMap();
        }
    }


    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
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

    void SmoothMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);

                if (neighbourWallTiles > 4)
                    map[x, y] = 1;
                else if (neighbourWallTiles < 4)
                    map[x, y] = 0;

            }
        }
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
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


    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, 0);
                    //Vector3 pos = new Vector3(x, y, 0);
                    //Gizmos.DrawCube(pos, Vector3.one);
                    //Gizmos.DrawSphere(pos, 0.5F);
                    //Gizmos.DrawWireSphere(pos, 0.5F);
                    //Gizmos.DrawWireCube(pos, Vector3.one);
                    //Gizmos.DrawGUITexture(new Rect(0, 0, 1, 1), texture);
                }
            }
        }
    }



}