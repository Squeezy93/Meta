using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GamePlay.Combat
{
    public class TargetControl : MonoBehaviour
    {
        private LookFollow _lookFollow;
        private Transform _currentTarget;
        public Transform Target => _currentTarget;
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
                _currentTarget = GetTarget();
                _lookFollow.SetTarget(_currentTarget);
            }
        }

        private Transform GetTarget()
        {
            if (m_MainTarget != null && m_MainTarget.gameObject.activeSelf && _lookFollow.CheckCanFollow(m_MainTarget.position - transform.position))
            {
                return m_MainTarget;
            }
            else
            {
                var nearestList = _targetList
                    .FindAll(x => (_lookFollow.CheckCanFollow(x.position - transform.position)) && x.gameObject.activeSelf)
                    .OrderBy(x => (x.position - transform.position).sqrMagnitude)
                   ;
                return nearestList.FirstOrDefault();
            }

            return null;
        }
    }
}