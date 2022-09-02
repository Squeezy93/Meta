using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.PlanetarySystem
{
    public class PlanetarySystemObject : MonoBehaviour
    {
        [SerializeField] private GameObject m_View;


        private void OnEnable()
        {
            PlanetarySystemObjectManager.AddObject(this);
        }

        private void OnDisable()
        {
            PlanetarySystemObjectManager.RemoveObject(this);
        }

        public void ShowView(bool enabled)
        {
            m_View.SetActive(enabled);
        }
    }
}
