using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.SpaceSystem
{
    public class InterfaceManager : MonoBehaviour
    {
        [SerializeField] private CameraManager m_CameraManager;
        [SerializeField] private GameObject m_MapView;
        [SerializeField] private GameObject m_GamePlayView;
        [SerializeField] private GameObject m_PlanetView;

        Dictionary<string, GameObject> m_InterfaceViews = new Dictionary<string, GameObject>();

        private void Awake()
        {
            m_InterfaceViews.Add("Map", m_MapView);
            m_InterfaceViews.Add("GamePlay", m_GamePlayView);
            m_InterfaceViews.Add("Planet", m_PlanetView);
           
        }

        private void MapViewOpen()
        {
            m_CameraManager.MapCameraTurn();
            OpenInterface("Map");
        }

        private void OpenInterface(string key)
        {
            foreach (var view in m_InterfaceViews)
            {
                m_InterfaceViews[view.Key].SetActive(key == view.Key);
            }
        }

        private void OpenPlanetView()
        {
            m_CameraManager.PlanetCameraTurn();
            OpenInterface("Planet");
           
        }

        private void GamePlayViewOpen()
        {
            m_CameraManager.PlayerCameraTurn();
            OpenInterface("GamePlay");
        }

        public void OpenView(string key)
        {
            switch (key)
            {
                case "Map": MapViewOpen(); break;
                case "GamePlay": GamePlayViewOpen(); break;
                case "Planet": OpenPlanetView(); break;
                default:
                    break;
            }
        }
    }
}
