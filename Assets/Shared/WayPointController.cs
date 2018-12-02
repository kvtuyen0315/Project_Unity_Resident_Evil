using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class WayPointController : MonoBehaviour
    {
        #region Variable.
        // int.
        private int _currentWayPointIndex = -1;

        // Class.
        private WayPoint[] _wayPoints;

        // System Action.
        public event System.Action<WayPoint> _onWayPointChanged;

        // Vector 3.
        private Vector3 _previousWayPoint;
        private Vector3 _wayPointPosition;

        #endregion

        #region Awake.
        private void Awake()
        {
            _wayPoints = GetWayPoint();    
            
        }
        #endregion

        #region Set Next Way Point.
        public void SetNextWayPoint()
        {
            _currentWayPointIndex++;

            if (_currentWayPointIndex == _wayPoints.Length)
            {
                _currentWayPointIndex = 0;
            }

            if (_onWayPointChanged != null)
            {
                _onWayPointChanged(_wayPoints[_currentWayPointIndex]);
            }
        }
        #endregion

        #region Get Way Point.
        private WayPoint[] GetWayPoint()
        {
            return GetComponentsInChildren<WayPoint>();
        }
        #endregion

        #region On Draw Gizmos.
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            _previousWayPoint = Vector3.zero;
            foreach (var wayPoint in GetWayPoint())
            {
                _wayPointPosition = wayPoint.transform.position;
                Gizmos.DrawWireSphere(_wayPointPosition, 0.2f);

                if (_previousWayPoint != Vector3.zero)
                {
                    Gizmos.DrawLine(_previousWayPoint, _wayPointPosition);
                }

                _previousWayPoint = _wayPointPosition;
            }
        }
        #endregion

    }
}

