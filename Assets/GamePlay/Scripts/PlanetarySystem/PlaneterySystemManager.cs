using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace GamePlay.PlanetarySystem
{
    public class PlaneterySystemManager : MonoBehaviour
    {
        [SerializeField] private Camera _systemCamera;
        [SerializeField] private GameObject m_BackPrefab;
        [SerializeField] private GameObject m_StarControllerPrefab;
        [SerializeField] private PlanetSystemInfoManager m_PlanetSystemInfoManager;
        [SerializeField] private PlanetController m_PanetControllerPrefab;
        [SerializeField] private PlanetDatabase _planetDatas;
        [SerializeField] private PlanetController[] planetControllers;

        private void Start()
        {
            InitSystem();
        }

        private void InitSystem()
        {
            _systemCamera.orthographicSize = _planetDatas.PlanetDatas.Max(x => x.PlanetVectorPosition.magnitude + x.PlanetSize);
            Instantiate(m_BackPrefab, transform);
            Instantiate(m_StarControllerPrefab, transform);
            planetControllers = new PlanetController[_planetDatas.PlanetDatas.Count];
            for (int i = 0; i < _planetDatas.PlanetDatas.Count; i++)
            {
                var pd = _planetDatas.PlanetDatas[i];
                var inst = Instantiate(m_PanetControllerPrefab, transform);
                inst.SetData(pd);
                planetControllers[i] = inst;
            }

            m_PlanetSystemInfoManager.SetPlanets(planetControllers);
        }
    }
}
