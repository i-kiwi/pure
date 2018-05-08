using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor
{
    class TileDemo : Tile
    {
        public override void RefreshTile(Vector3Int location, ITilemap tilemap)
        {
            for (int yd = -1; yd <= 1; yd++)
                for (int xd = -1; xd <= 1; xd++)
                {
                    Vector3Int position = new Vector3Int(location.x + xd, location.y + yd, location.z);
                    if (HasRoadTile(tilemap, position))
                        tilemap.RefreshTile(position);
                }
        }

        // This determines if the Tile at the position is the same RoadTile.
        private bool HasRoadTile(ITilemap tilemap, Vector3Int position)
        {
            return tilemap.GetTile(position) == this;
        }
    }
}
