using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField]
        LevelObjectView _playerView;
        [SerializeField]
        List<LevelObjectView> coinViews;
        [SerializeField]
        List<LevelObjectView> deathZones;
        [SerializeField]
        List<LevelObjectView> winZones;
        CoinsManager _coinsManager;
        SpriteAnimator _playerAnimator;
        ParalaxManager _paralaxManager;
        MainHeroPhysicsWalker _mainHeroPhysicsWalker;
        LevelCompleteManager _levelCompleteManager;
    void Start()
        {
            var _configAnimation = Resources.Load<SpriteAnimationsConfig>("PlayerAnimationsConfig");
            _playerAnimator = new SpriteAnimator(_configAnimation);
            _mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_playerView, _playerAnimator);
            _coinsManager = new CoinsManager(_playerView, coinViews, _playerAnimator);
            _levelCompleteManager = new LevelCompleteManager(_playerView, deathZones, winZones);
            var _comfigBackGround = Resources.Load<BackGroundConfig>("ParallaxConfig");
            _paralaxManager = new ParalaxManager(_comfigBackGround);
        }

        void Update()
        {
            _playerAnimator?.Update();
        }
        private void FixedUpdate()
        {
            _mainHeroPhysicsWalker.FixedUpdate();
        }
        private void LateUpdate()
        {
            _paralaxManager?.LateUpdate();
        }
    }
}