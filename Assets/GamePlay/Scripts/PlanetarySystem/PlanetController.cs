using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Color = UnityEngine.Color;

public class PlanetController: MonoBehaviour
{
    public Transform PlanetObject => m_PlanetObject;
   [SerializeField] private Transform m_PlanetObject;
   [SerializeField] private RotatePlanet _rotatePlanet;

    private PlanetData _planetData;
    
    public void SetData(PlanetData planetData)
    {
        _planetData = planetData;

        _rotatePlanet.SetAngleSpeed(_planetData.PlanetAngleMove);       
        m_PlanetObject.localPosition = Vector3.right * _planetData.PlanetVectorPosition.x + Vector3.forward * _planetData.PlanetVectorPosition.z;
        m_PlanetObject.localScale = Vector3.one * _planetData.PlanetSize;
    }   
}
