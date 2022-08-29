using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.SpaceSystem
{
    public class InterfaceManager : MonoBehaviour
    {
        [SerializeField] private CameraManager m_CameraManager;
        [SerializeField] private GameObject m_MapView;
        [SerializeField] private GameObject m_GamePlayView;

        private void Awake()
        {
            GamePlayViewOpen();
        }

        public void MapViewOpen()
        {
            m_CameraManager.MapCameraTurn();
            m_MapView.SetActive(true);
            m_GamePlayView.SetActive(false);
        }

        public void GamePlayViewOpen()
        {
            m_CameraManager.PlayerCameraTurn();
            m_MapView.SetActive(false);
            m_GamePlayView.SetActive(true);
        }
    }
}
