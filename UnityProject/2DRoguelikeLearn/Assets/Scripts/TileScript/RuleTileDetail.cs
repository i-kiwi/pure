using System;
using System.Collections.Generic;

namespace UnityEngine
{
    class RuleTileDetail
    {
        private static List<RuleTile.TilingRule> rules;

        public static List<RuleTile.TilingRule> getRuleDetails()
        {
            if (rules != null && rules.Count > 0)
                return rules;
            // TopLeft↖
            rules = new List<RuleTile.TilingRule>();
            RuleTile.TilingRule rule = new RuleTile.TilingRule();
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

            // Top↑
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // TopRight↗
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // Left←
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // Center·
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // Right→
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // BottomLeft ↙
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // Bottom↓
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            // BottomRight↘
            rule = new RuleTile.TilingRule();
            rule.m_Neighbors = new RuleTile.TilingRule.Neighbor[8]
            {
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.This,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare,
                RuleTile.TilingRule.Neighbor.NotThis,
                RuleTile.TilingRule.Neighbor.DontCare
            };
            rules.Add(rule);

            return rules;
        }
    }
}
