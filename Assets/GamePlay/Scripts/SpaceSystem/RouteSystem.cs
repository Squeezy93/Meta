using GamePlay.PlanetarySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.SpaceSystem
{
    public class RouteSystem : MonoBehaviour
    {
        private static RouteSystem _instance;
        [SerializeField] private PlaneterySystemManager m_PlaneterySystemManager;
        private PlanetController m_PlaneteryController;

        private void Awake()
        {
            _instance = this;
        }

        public static void CreateRoute(PlanetData planetData)
        {
            _instance.m_PlaneteryController = _instance.m_PlaneterySystemManager.FindPlanet(planetData);
        }

        public static void ResetRoute()
        {
            _instance.m_PlaneteryController = null;
        }
    }
}