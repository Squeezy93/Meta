using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem
{
    public class PlanetarySystemObjectManager : MonoBehaviour
    {
        public static event Action OnChangeObjectList = delegate { };
        private static PlanetarySystemObjectManager _instance;
        private List<PlanetarySystemObject> _planetarySystemObjects = new List<PlanetarySystemObject>();

        private void Awake()
        {
            _instance = this;
        }

        public static void AddObject(PlanetarySystemObject planetaryObject)
        {
            _instance._planetarySystemObjects.Add(planetaryObject);
            OnChangeObjectList.Invoke();
        }

        public static void RemoveObject(PlanetarySystemObject planetaryObject)
        {
            _instance._planetarySystemObjects.Remove(planetaryObject);
            OnChangeObjectList.Invoke();
        }

        public static List<PlanetarySystemObject> PlanetarySystemObjects => _instance._planetarySystemObjects;
    }
}

