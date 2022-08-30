using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.SpaceSystem
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Camera m_PlayerCamer;
        [SerializeField] private Camera m_MapCamera;
        [SerializeField] private Camera m_PlanetCamera;

        public void PlanetCameraTurn()
        {
            m_PlayerCamer.enabled = false;
            m_MapCamera.enabled = false;
            m_PlanetCamera.enabled = true;
        }

        public void PlayerCameraTurn()
        {
            m_PlayerCamer.enabled = true;
            m_MapCamera.enabled = false;
            m_PlanetCamera.enabled = false;
        }

        public void MapCameraTurn()
        {
            m_PlayerCamer.enabled = false;
            m_MapCamera.enabled = true;
            m_PlanetCamera.enabled = false;
        }
    }
}
