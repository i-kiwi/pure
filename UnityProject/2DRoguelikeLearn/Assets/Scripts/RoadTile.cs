using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RoadTile : MonoBehaviour {
    public Tilemap tile;

    void Update()
	{

        if (Input.GetMouseButtonDown(0))
        {
            //tile.
            Debug.Log("[tile.transform]" + tile.cellSize);
            Instantiate(tile, Vector3.zero, Quaternion.identity);
        }
    }
}
