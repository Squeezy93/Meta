using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.GameStatus
{
    public class StateActivate : MonoBehaviour
    {

        public void ActivatePlanetSystemMapState()
        {
            GameManager.SetStatus(new PlanetarySystemMapState());
        }
    }
}
