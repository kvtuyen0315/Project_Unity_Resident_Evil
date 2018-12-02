using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(SphereCollider))]
    public class Scanner : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _scanSpeed;
        [SerializeField] [Range(0, 360)] private float _fieldOfView;
        private float _radian;
        private float _distanceToTarget;
        private float _closestTarget;
        public float _scanRange
        {
            get
            {
                if (_rangerTrigger == null)
                {
                    _rangerTrigger = GetComponent<SphereCollider>();
                }
                return _rangerTrigger.radius;
            }
        }

        // Collider.
        private SphereCollider _rangerTrigger;
        private Collider[] _results;

        // Layer Mask.
        [SerializeField] private LayerMask _mask;


        // Vector 3.
        Vector3 _direction;

        // System Action.
        public event System.Action _onScanReady;

        #endregion

        #region Prepare Scan.
        private void PrepareScan()
        {
            GameManager._instance._timer.Add(() =>
            {
                if (_onScanReady != null)
                {
                    _onScanReady();
                }
            }, _scanSpeed);
        }
        #endregion

        #region Get View Angle.
        private Vector3 GetViewAngle(float angle)
        {
            _radian = (angle + transform.eulerAngles.y) * Mathf.Deg2Rad;
            return new Vector3(Mathf.Sin(_radian), 0.0f, Mathf.Cos(_radian));
        }
        #endregion

        #region On Draw Gizmos.
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + GetViewAngle(_fieldOfView / 2) * GetComponent<SphereCollider>().radius);

            Gizmos.DrawLine(transform.position, transform.position + GetViewAngle(-_fieldOfView / 2) * GetComponent<SphereCollider>().radius);
        }
        #endregion

        #region Scan For Targets.
        public List<T> ScanForTargets<T>()
        {
            List<T> targets = new List<T>();

            _results = Physics.OverlapSphere(transform.position, _scanRange);

            for (int i = 0; i < _results.Length; i++)
            {
                var _player = _results[i].transform.GetComponent<T>();

                if (_player == null)
                {
                    continue;
                }

                if (!IsInLineOfSight(Vector3.up, _results[i].transform.position))
                {
                    continue;
                }

                targets.Add(_player);
                
            }

            PrepareScan();

            return targets;
        }
        #endregion

        #region Is In Line Of Sight.
        private bool IsInLineOfSight(Vector3 eyeHeight, Vector3 targetPosition)
        {
            _direction = targetPosition - transform.position;

            if (Vector3.Angle(transform.forward, _direction.normalized) < _fieldOfView / 2)
            {
                _distanceToTarget = Vector3.Distance(transform.position, targetPosition);

                // Something blocking our view?
                if (Physics.Raycast(transform.position + eyeHeight, _direction.normalized, _distanceToTarget, _mask))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
        #endregion

    }
}

