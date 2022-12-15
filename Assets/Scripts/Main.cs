using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        LevelObjectView _playerView;
        SpriteAnimator _playerAnimator;
        ParalaxManager _paralaxManager;
    void Start()
        {
            var _configAnimation = Resources.Load<SpriteAnimationsConfig>("PlayerAnimationsConfig");
            _playerAnimator = new SpriteAnimator(_configAnimation);
            _playerAnimator.StartAnimation(_playerView.spriteRenderer, Track.Walk, true, 10f);
            var _comfigBackGround = Resources.Load<BackGroundConfig>("ParallaxConfig");
            _paralaxManager = new ParalaxManager(_comfigBackGround);
        }

        void Update()
        {
            _playerAnimator?.Update();
        }
        private void LateUpdate()
        {
            _paralaxManager?.LateUpdate();
        }
    }
}