using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(PathFinder))]
    [RequireComponent(typeof(EnemyPlayer))]
    public class EnemyPatrol : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _waitTimeMin;
        [SerializeField] private float _waitTimeMax;

        // Class.
        [SerializeField] private WayPointController _wayPointController;
        private PathFinder _pathFinder;

        private EnemyPlayer m_EnemyPlayer;
        public EnemyPlayer _enemyPlayer
        {
            get
            {
                if (m_EnemyPlayer == null)
                {
                    m_EnemyPlayer = GetComponent<EnemyPlayer>();
                }
                return m_EnemyPlayer;
            }
        }

        #endregion

        #region Start.
        private void Start()
        {
            _wayPointController.SetNextWayPoint();
        }
        #endregion

        #region Awake.
        private void Awake()
        {
            _pathFinder = GetComponent<PathFinder>();

            _pathFinder._onDestinationReached += OnDestinationReached;

            _wayPointController._onWayPointChanged += OnWayPointChanged;

            _enemyPlayer._enemyHealth._onDeath += OnDeath;
        }


        #endregion

        #region On Death.
        private void OnDeath()
        {
            _pathFinder._agent.Stop();
        }
        #endregion

        #region On Destination Reached.
        private void OnDestinationReached()
        {
            // Assume we are patrolling.
            GameManager._instance._timer.Add(_wayPointController.SetNextWayPoint , Random.Range(_waitTimeMin, _waitTimeMax));
        }
        #endregion

        #region On Way Point Changed.
        private void OnWayPointChanged(WayPoint wayPoint)
        {
            _pathFinder.SetTarget(wayPoint.transform.position);
        }
        #endregion
    }
}

