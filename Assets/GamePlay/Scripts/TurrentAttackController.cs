using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentAttackController : MonoBehaviour
{
    [SerializeField] private Transform m_AttackPoint;
    [SerializeField] private bool m_AutoAttack;

    private LookFollow _lookFollow;
    private ReloadController _reloadController;

    private void Awake()
    {
        _lookFollow = GetComponent<LookFollow>();
        _reloadController = GetComponent<ReloadController>();
    }

    private void FixedUpdate()
    {
        if(_reloadController.IsReloadReady && _lookFollow.IsLookAtTarget)
        {
            Attack();
            _reloadController.Reload();
        }
    }

    private void Attack()
    {
       
        if(m_AttackPoint != null)
        {
            m_AttackPoint.gameObject.SetActive(true);
            Invoke(nameof(TurnOffFireEffect),0.1f);
        }


    }

    private void TurnOffFireEffect()
    {
        m_AttackPoint.gameObject.SetActive(false);
    }
}
