using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GamePlay.ShipSystem
{
    public class Target : MonoBehaviour, IDamagable
    {
        public void TakeDamage(DamageData damageData)
        {
            gameObject.SetActive(false);
        }
    }
}