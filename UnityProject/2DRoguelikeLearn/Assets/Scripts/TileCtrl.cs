using System.Collections.Generic;
using UnityEngine;

public class TileCtrl : MonoBehaviour {

    public GameObject floor;
    public GameObject wall;
    public GameObject background;
    //屏幕宽高
    public int mapWidth = 50;
    public int mapHeight = 50;
    
    private int[,] mapArray;

    //分布比例
    public int fillprob = 40;
    public bool useRandomSeed = false;
    public string seed;
    //平滑次数
    public int firstSmooth = 4;
    public int secondSmooth = 3;


    // Use this for initialization
    void Start ()
    {
        mapArray = new int[mapWidth, mapHeight];
        // init
        mapInit();
        // draw
        drawMap();
    }


    private void mapInit()
    {
        //if (useRandomSeed)
        //{
        //    seed = Time.time.ToString();
        //}
        //System.Random random = new System.Random(seed.GetHashCode());
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (x * y == 0 || x == mapWidth - 1 || y == mapHeight - 1)
                    mapArray[x, y] = 1;
                else
                    mapArray[x, y] = Random.Range(0, 100) < fillprob ? 1 : 0; // random.Next(0, 100) < fillprob ? 1 : 0;
            }
        }
    }
    private void smoothMap()
    {
        int[,] tempMapArray = new int[mapWidth, mapHeight];
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                int firstLayerCount = getNearWallCount(i, j, 1);
                int secondLayerCount = getNearWallCount(i, j, 2);
                //if (mapArray[i, j] == 1)
                //    tempMapArray[i, j] = (firstLayerCount >= 4) ? 1 : 0;
                //else
                //    tempMapArray[i, j] = (firstLayerCount >= 5) ? 1 : 0;
                int flag = mapArray[i, j] == 1 ? 4 : 5;
                if (firstSmooth > 0)
                {
                    tempMapArray[i, j] = firstLayerCount >= flag || secondLayerCount <= 2 ? 1 : 0;
                }
                else if (secondSmooth > 0)
                {
                    tempMapArray[i, j] = firstLayerCount >= flag ? 1 : 0 ;
                }
                else
                {
                    return;
                }
            }
        }
        mapArray = tempMapArray;

    }

    int checkNeighborWalls(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX != gridX || neighbourY != gridY)
                {
                    wallCount += mapArray[neighbourX, neighbourY];
                }
            }
        }

        return wallCount;
    }

    int getNearWallCount(int x, int y, int layer)
    {
        int count = 0;
        for (int i = x - layer; i <= x + layer; i++)
        {
            for (int j = y - layer; j <= y + layer; j++)
            {
                if (i >= 0 && i < mapWidth && j >= 0 && j < mapHeight)
                {
                    if (i != x || j != y)
                    {
                        count += mapArray[i, j];
                    }
                }
                else
                {
                    count++;
                }
            }
        }
        return count;
    }

    private void drawMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                if (mapArray[x, y] == 1)
                    Instantiate(wall, new Vector3(x, y, 0), Quaternion.identity, background.transform);
                else
                    Instantiate(floor, new Vector3(x, y, 0), Quaternion.identity, background.transform);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // smooth
            smoothMap();
            if (firstSmooth > 0)
                firstSmooth--;
            else if (secondSmooth > 0)
                secondSmooth--;
            else
                Debug.Log("over");
            foreach (Transform tran in background.transform)
            {
                Destroy(tran.gameObject);
            }
            drawMap();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            foreach (Transform tran in background.transform)
            {
                Destroy(tran.gameObject);
            }
            Start();
            firstSmooth = 4;
            secondSmooth = 3;
        }
	}
}
