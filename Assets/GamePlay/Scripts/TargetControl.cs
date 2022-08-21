using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetControl : MonoBehaviour
{

    private LookFollow _lookFollow;
    private Transform m_MainTarget;

    [SerializeField] List<Transform> _targetList;

    private void Start()
    {
        _lookFollow = GetComponent<LookFollow>();
        _targetList = FindObjectsOfType<Target>().Select(t => t.transform).ToList();
    }

    private void FixedUpdate()
    {
        if (!_lookFollow.CanFollowCurrentTarget())
        {
            _lookFollow.SetTarget( GetTarget());
        }
    }

    private Transform GetTarget()
    {
        if(m_MainTarget != null && _lookFollow.CheckCanFollow(m_MainTarget.position - transform.position))
        {
            return m_MainTarget;
        }
        else
        {
            var nearestList = _targetList
                .FindAll(x=> (_lookFollow.CheckCanFollow(x.position - transform.position)))
                .OrderBy(x=> (x.position - transform.position).sqrMagnitude)
               ;
            return nearestList.FirstOrDefault();
        }

        return null;
    }
}
