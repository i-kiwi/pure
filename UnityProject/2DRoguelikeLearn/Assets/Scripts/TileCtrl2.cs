using UnityEngine;

public class TileCtrl2 : MonoBehaviour {

    public int width;
    public int height;

    public string seed;
    public bool useRandomSeed;

    [Range(0, 100)]
    public int randomFillPercent;

    public GameObject background;
    public Transform wall;
    public Transform floor;
    //平滑次数
    public int firstSmooth = 4;
    public int secondSmooth = 3;

    int[,] map;

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            foreach (Transform tran in background.transform)
            {
                Destroy(tran.gameObject);
            }
            GenerateMap();
            firstSmooth = 4;
            secondSmooth = 3;

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

            foreach (Transform tran in background.transform)
            {
                Destroy(tran.gameObject);
            }
            drawMap();
        }
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();
        drawMap();
    }


    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent)? 1: 0;
                }
            }
        }
    }

    void SmoothMap()
    {
        int[,] tempMap = new int[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
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

    int GetSurroundingWallCount(int gridX, int gridY, int layer)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - layer; neighbourX <= gridX + layer; neighbourX++) {
            for (int neighbourY = gridY - layer; neighbourY <= gridY + layer; neighbourY++) {
                if (neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    private void drawMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Instantiate(map[x, y] == 1 ? wall : floor, new Vector3(x, y, 0), Quaternion.identity, background.transform);
            }
        }
    }
}
