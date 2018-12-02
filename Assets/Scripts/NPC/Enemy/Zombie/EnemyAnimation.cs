using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(PathFinder))]
    public class EnemyAnimation : MonoBehaviour
    {
        #region Variable.
        // float.
        private float _vertical;

        // Class.
        [SerializeField] private Animator _animator;
        private PathFinder _pathFinder;

        // Vector 3.
        private Vector3 _lastPosition;

        #endregion

        #region Awake.
        private void Awake()
        {
            _pathFinder = GetComponent<PathFinder>();
            _animator = GetComponentInChildren<Animator>();
        }
        #endregion

        #region Update.
        private void Update()
        {
            _vertical = ((transform.position - _lastPosition).magnitude) / Time.deltaTime;
            _lastPosition = transform.position;

            if (_pathFinder._agent.speed < 1.0f)
            {
                _animator.SetBool("ZRuning", false);
            }
            else
            {
                _animator.SetBool("ZRuning", true);
            }

            _animator.SetFloat("Vertical", _vertical / _pathFinder._agent.speed);
        }
        #endregion

    }
}

