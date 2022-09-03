using GamePlay.GameStatus;
using GamePlay.PlanetarySystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandingController : MonoBehaviour
{
    public void InteractPlanet(PlanetData planetData)
    {
        GameManager.SetStatus(new PlanetLandState() { PlanetData = planetData });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
