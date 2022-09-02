using GamePlay.PlanetarySystem;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadarSystemController : MonoBehaviour
{
    [SerializeField] private float m_DetectRange;
    [SerializeField] private bool m_Enable;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(m_Enable)
            Scan();
    }

    private void Scan()
    {
        var allObjects = PlanetarySystemObjectManager.PlanetarySystemObjects;
        foreach (var obj in allObjects)
        {
            obj.ShowView((transform.position - obj.transform.position).magnitude < m_DetectRange);
        }       
    }
}
