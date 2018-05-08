using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor
{
    public class TileCtrl3 : MonoBehaviour
    {

        public Tilemap tilemap;
        public Sprite[] sprites;

        public void initTile(Sprite[] sprites)
        {
            //private void Start()
            //{

            //Brush brush = ScriptableObject.CreateInstance<Brush>();
            //brush.Paint(tilemap.layoutGrid, brushTarget, new Vector3Int(1, 1, 1));

            List<RuleTile.TilingRule> rules = new List<RuleTile.TilingRule>();

            RuleTile.TilingRule rule = new RuleTile.TilingRule();
            rule.m_Sprites = new Sprite[1] { sprites[0] };
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
            RuleTile.TilingRule.Neighbor.DontCare,
            RuleTile.TilingRule.Neighbor.NotThis,
            RuleTile.TilingRule.Neighbor.DontCare,
            RuleTile.TilingRule.Neighbor.NotThis,
            RuleTile.TilingRule.Neighbor.This,
            RuleTile.TilingRule.Neighbor.DontCare,
            RuleTile.TilingRule.Neighbor.This,
            RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);


            //RuleTile.TilingRule rule = new RuleTile.TilingRule();
            //rule.m_Sprites = new Sprite[1] { sprites[0] };
            //rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            //{
            //    RuleTile.TilingRule.Neighbor.DontCare,
            //    RuleTile.TilingRule.Neighbor.NotThis,
            //    RuleTile.TilingRule.Neighbor.DontCare,
            //    RuleTile.TilingRule.Neighbor.NotThis,
            //    RuleTile.TilingRule.Neighbor.This,
            //    RuleTile.TilingRule.Neighbor.DontCare,
            //    RuleTile.TilingRule.Neighbor.This,
            //    RuleTile.TilingRule.Neighbor.DontCare
            //};


            RuleTile ruleTile = ScriptableObject.CreateInstance<RuleTile>();
            ruleTile.m_DefaultSprite = sprites[4];
            ruleTile.m_TilingRules = rules;
            tilemap.SetTile(new Vector3Int(0, 0, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(0, 1, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(0, 2, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(1, 0, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(1, 1, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(1, 2, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(2, 0, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(2, 1, 0), ruleTile);
            tilemap.SetTile(new Vector3Int(2, 2, 0), ruleTile);

            //TileDemo tile1 = ScriptableObject.CreateInstance<TileDemo>();
            //tile1.sprite = sprite;
            //tilemap.SetTile(Vector3Int.zero, tile1);

            //TileDemo tile2 = ScriptableObject.CreateInstance<TileDemo>();
            //tile2.sprite = sprite2;
            //tilemap.SetTile(new Vector3Int(1, 1, 0), tile2);

            //tilemap.SwapTile(tile1, tile2);
            //tilemap.RefreshTile(new Vector3Int(1, 1, 0));








            //tilemap.SwapTile(tilemap.GetTile(Vector3Int.zero), tile);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}