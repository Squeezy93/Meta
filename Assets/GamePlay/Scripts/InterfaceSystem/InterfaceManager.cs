using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.SpaceSystem
{
    public class InterfaceManager : MonoBehaviour
    {
        private static InterfaceManager _instance;
        [SerializeField] private List<InterfaceWindow> m_WindowList = new List<InterfaceWindow>();

        [SerializeField] private CameraManager m_CameraManager;      

        private Dictionary<string, InterfaceWindow> m_InterfaceViews = new Dictionary<string, InterfaceWindow>();
        private List<string> _windowsList = new List<string>();

        private void Awake()
        {
            _instance = this;
            Debug.Log("awake");
            foreach (var window in m_WindowList)
            {
                m_InterfaceViews.Add(window.InterfaceKey, window);
            }    
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
            _windowsList.Add(key);
        }

        private void CloseLast()
        {
            var lastKey = _windowsList.Last();
            _windowsList.Remove(lastKey);

            foreach (var view in m_InterfaceViews)
            {
                m_InterfaceViews[view.Key].SetActive(_windowsList.Last() == view.Key);
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

        public static void OpenView(string key)
        {
            switch (key)
            {
                case "Map": _instance.MapViewOpen(); break;
                case "GamePlay": _instance.GamePlayViewOpen(); break;
                case "Planet": _instance.OpenPlanetView(); break;
                default:
                    _instance.OpenInterface(key);
                    break;
            }
        }        

        public static void CloseLastView()
        {
            _instance.CloseLast();
        }
    }
}
