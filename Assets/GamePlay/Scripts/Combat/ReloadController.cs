using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.Combat
{
    public class ReloadController : MonoBehaviour
    {
        public event Action OnReloaded;
        private bool _isReloadReady;
        public bool IsReloadReady => _isReloadReady;

        [SerializeField] private float m_AttackRate;
        private float _cooldownRate;
        private bool _isNeedReload;

        private void Awake()
        {
            Reload();
        }

        public void Reload()
        {
            _isReloadReady = false;
            _isNeedReload = true;
            _cooldownRate = 1 / m_AttackRate;
        }

        private void Update()
        {
            if (_isNeedReload)
                ReloadIick(Time.deltaTime);
        }

        private void ReloadIick(float deltaTime)
        {
            if (_isReloadReady)
            {
                return;
            }
            if (_cooldownRate <= 0)
            {
                _isNeedReload = false;
                _isReloadReady = true;
                OnReloaded?.Invoke();
            }

            if (_cooldownRate > 0)
            {
                _cooldownRate -= deltaTime;
            }
        }
    }
}