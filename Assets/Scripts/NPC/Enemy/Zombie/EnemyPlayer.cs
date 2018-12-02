using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(PathFinder))]
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyPlayer : MonoBehaviour
    {
        #region Variable.
        // float.
        private float _closestTarget;

        // Class.
        [SerializeField] private MovingSettings _settings;

        private PathFinder _pathFinder;
        [SerializeField] private Scanner _enemyScanner;

        private Player _playerPriorityTarget;

        private EnemyHealth m_EnemyHealth;
        public EnemyHealth _enemyHealth
        {
            get
            {
                if (m_EnemyHealth == null)
                {
                    m_EnemyHealth = GetComponent<EnemyHealth>();
                }
                return m_EnemyHealth;
            }
        }


        // List.
        private List<Player> _myTargets;

        

        #endregion

        #region Start.
        private void Start()
        {
            _pathFinder = GetComponent<PathFinder>();
            _pathFinder._agent.speed = _settings._zWalkSpeed;

            _enemyScanner._onScanReady += OnScanReady;
            OnScanReady();
        }
        #endregion

        #region On Scan Ready.
        private void OnScanReady()
        {
            if (_playerPriorityTarget != null)
            {
                return;
            }

            _myTargets = _enemyScanner.ScanForTargets<Player>();

            if (_myTargets.Count == 1)
            {
                _playerPriorityTarget = _myTargets[0];
            }
            else
            {
                SelectClosestTarget();
            }

            if (_playerPriorityTarget != null)
            {
                SetDestinationToPriorityTarget();
            }

        }
        #endregion

        #region Set Destination To Priority Target.
        private void SetDestinationToPriorityTarget()
        {
            _pathFinder.SetTarget(_playerPriorityTarget.transform.position);
        }
        #endregion

        #region Select Closest Target.
        private void SelectClosestTarget()
        {
            _closestTarget = _enemyScanner._scanRange;
            foreach (var possibleTarget in _myTargets)
            {
                if (Vector2.Distance(transform.position, possibleTarget.transform.position) < _closestTarget)
                {
                    _playerPriorityTarget = possibleTarget;
                }
            }
        }
        #endregion

    }
}

