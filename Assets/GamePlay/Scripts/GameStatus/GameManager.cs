using GamePlay.GameStatus;
using GamePlay.PlanetarySystem;
using GamePlay.PlanetarySystem.Map;
using GamePlay.SpaceSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] PlaneterySystemManager m_PlaneterySystemManager;
    [SerializeField] CameraManager m_CameraManager;
    [SerializeField] GameObject m_PlayerShip;
    [SerializeField] InterfaceManager m_InterfaceManager;
    [SerializeField] PlanetSystemInfoManager m_PlanetSystemInfoManager;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        SpaceFlyState();
    }

    public static void SetStatus(IState state)
    {
        if(state is PlanetLandState landState)
        {
            _instance.PlanetLandState();
        }
        if (state is PlanetarySystemMapState mapState)
        {
            _instance.PlanetSystemMapState();
        }
        if (state is PlanetSystemSpace spaceState)
        {
            _instance.SpaceFlyState();
        }
    }

    private void CombatState()
    {

    }

    private void SpaceFlyState()
    {
        m_InterfaceManager.OpenView("GamePlay");
        m_PlayerShip.gameObject.SetActive(true);
    }

    private void PlanetLandState()
    {
        m_PlayerShip.gameObject.SetActive(false);
        m_InterfaceManager.OpenView("Planet");
    }

    private void PlanetSystemMapState()
    {
        m_CameraManager.MapCameraTurn();
        m_InterfaceManager.OpenView("Map");
    }

    private void GalacticMapState()
    {

    }
}
