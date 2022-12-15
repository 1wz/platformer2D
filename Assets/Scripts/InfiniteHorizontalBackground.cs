
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer
{
    public class InfiniteHorizontalBackground
    {
        Camera mainCamera;
        float halfWidthOfCamera;
        Sprite backgroundImage;
        float widthOfTexture;
        Deque<Transform> Images = new Deque<Transform>();//first is left, last is right
        public Transform root { get; private set; }

        public InfiniteHorizontalBackground(Sprite image, int orderInLayer)
        {
            backgroundImage = image;
            mainCamera = Camera.main;
            root = new GameObject(backgroundImage.name).transform;
            halfWidthOfCamera = mainCamera.aspect * mainCamera.orthographicSize;
            widthOfTexture = backgroundImage.texture.width / backgroundImage.pixelsPerUnit;
            int countImage = Mathf.FloorToInt(halfWidthOfCamera*2 / widthOfTexture) + 2;
            Vector2 Pos = new Vector2(mainCamera.transform.position.x - ((float)countImage / 2 - 0.5f) * widthOfTexture, mainCamera.transform.position.x);
            for (int i = 0; i < countImage; i++)
            {
                var _gameObject = new GameObject(backgroundImage.name + i);
                var _transform = _gameObject.transform;
                _transform.SetParent(root);
                var spriteRenderer = _gameObject.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = backgroundImage;
                spriteRenderer.sortingOrder = orderInLayer;
                _transform.position = Pos;
                Images.AddLast(_transform);
                Pos += new Vector2(widthOfTexture, 0);
            }
        }

        public void LateUpdate()
        {

            while (mainCamera.transform.position.x + halfWidthOfCamera >= Images.Last.position.x+widthOfTexture/2)
            {
                var _transform = Images.RemoveFirst();
                _transform.position = new Vector2(Images.Last.position.x + widthOfTexture, _transform.position.y);
                Images.AddLast(_transform);

            }
            while(mainCamera.transform.position.x- halfWidthOfCamera<=Images.First.position.x-widthOfTexture/2)
            {
                var _transform = Images.RemoveLast();
                _transform.position = new Vector2(Images.First.position.x - widthOfTexture, _transform.position.y);
                Images.AddFirst(_transform);

            }

        }

        ~InfiniteHorizontalBackground()
        {
            UnityEngine.Object.Destroy(root.gameObject);
        }
    }
}