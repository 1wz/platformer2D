using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer
{
    public class ParalaxManager
    {
        private readonly Vector3 _startRootsPosition = Vector3.zero;
        private Vector3 _startCameraPosition;
        private Transform _camera;
        private (InfiniteHorizontalBackground, float)[] _layersWithCoef;
        private Transform olderRoot;
        public ParalaxManager(BackGroundConfig backGroundConfig)
        {
            _camera = Camera.main.transform;
            _startCameraPosition = _camera.transform.position;
            olderRoot= new GameObject("BackGround").transform;
            _layersWithCoef = new (InfiniteHorizontalBackground, float)[backGroundConfig.Layers.Count];
            for(int i=0;i< backGroundConfig.Layers.Count;i++)
            {
                var _layer = new InfiniteHorizontalBackground(backGroundConfig.Layers[i].Sprite, backGroundConfig.Layers[i].orderInLayer);
                _layer.root.SetParent(olderRoot);
                _layersWithCoef[i]=(_layer, backGroundConfig.Layers[i].coef);
            }
        }
        public void LateUpdate()
        {
            for (int i = 0; i < _layersWithCoef.Length; i++)
            {
                _layersWithCoef[i].Item1. root.position = _startRootsPosition + (_camera.position -_startCameraPosition) * _layersWithCoef[i].Item2;


                _layersWithCoef[i].Item1.LateUpdate();
            }
        }
    }
}