using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SA
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PathFinder : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _distanceRemainingTreshold;

        // bool.
        private bool m_DestinationReached;
        public bool _destinationReached
        {
            get
            {
                return m_DestinationReached;
            }
            set
            {
                m_DestinationReached = value;
                if (m_DestinationReached)
                {
                    if (_onDestinationReached != null)
                    {
                        _onDestinationReached();
                    }
                }
            }
        }

        // System Action.
        public event System.Action _onDestinationReached;

        // AI.
        [HideInInspector] public NavMeshAgent _agent;

        #endregion

        #region Awake.
        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }
        #endregion

        #region Set Target.
        public void SetTarget(Vector3 target)
        {
            _agent.SetDestination(target);
            _destinationReached = false;
            
        }
        #endregion

        #region Update.
        private void Update()
        {
            if (_destinationReached || _agent.hasPath)
            {
                return;
            }

            if (_agent.remainingDistance < _distanceRemainingTreshold)
            {
                _destinationReached = true;
            }
        }
        #endregion
    }
}

