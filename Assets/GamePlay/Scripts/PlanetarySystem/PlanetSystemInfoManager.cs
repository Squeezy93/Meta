using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystemInfoManager : MonoBehaviour
{
    [SerializeField] private Camera _systemCamera; 
    [SerializeField] private FollowObjectOnCanvas _buttonHandlerPrefab;

    public void SetPlanets(PlanetController[] planetControllers)
    {
        foreach (var planetController in planetControllers)
        {
            var buttonHandler = Instantiate(_buttonHandlerPrefab, transform);
            buttonHandler.Camera = _systemCamera;
            buttonHandler.TargetFollow = planetController.PlanetObject;
        }
        
    }

}
