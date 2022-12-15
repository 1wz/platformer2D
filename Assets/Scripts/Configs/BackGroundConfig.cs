using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer
{
    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs/BackGroundConfig", order = 1)]
    public class BackGroundConfig : ScriptableObject
    {
        [Serializable]
        public class LayerSetting
        {
            public Sprite Sprite;
            public int orderInLayer;
            public float coef;
        }
        public List<LayerSetting> Layers = new List<LayerSetting>();
    }
}