using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.PlanetarySystem
{
    public interface IPlanet
    {
        void SetData(PlanetData planetData);
        void OpenPlanetWindow();
    }
}
