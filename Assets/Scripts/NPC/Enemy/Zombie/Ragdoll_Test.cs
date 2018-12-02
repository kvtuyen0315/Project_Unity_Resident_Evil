using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Ragdoll_Test : Destructable
    {
        #region Variable.
        // int.
        private int _spawnIndex;

        // Animator.
        [SerializeField] private Animator _animator;

        // Rigid Body.
        private Rigidbody[] _bodyParts;

        // Class.
        private MoveController m_MoveController;
        public MoveController _moveController
        {
            get
            {
                if (m_MoveController == null)
                {
                    m_MoveController = transform.GetComponent<MoveController>();
                }
                return m_MoveController;
            }
        }

        [SerializeField] private SpawnPoint[] _spawnPoint;

        #endregion

        #region Start.
        private void Start()
        {
            _animator = GetComponentInChildren<Animator>();

            _bodyParts = transform.GetComponentsInChildren<Rigidbody>();

            EnableRagdoll(false);

        }
        #endregion

        #region Spawn At New Spawn Point.
        private void SpawnAtNewSpawnPoint()
        {
            _spawnIndex = Random.Range(0, _spawnPoint.Length);
            transform.position = _spawnPoint[_spawnIndex].transform.position;
            transform.rotation = _spawnPoint[_spawnIndex].transform.rotation;

        }
        #endregion

        #region Enable Ragdoll.
        private void EnableRagdoll(bool value)
        {
            for (int i = 0; i < _bodyParts.Length; i++)
            {
                _bodyParts[i].isKinematic = !value;
            }
        }
        #endregion

        //#region Take Damage.
        //public override void TakeDamage(float amount)
        //{
        //    base.TakeDamage(amount);
        //}
        //#endregion

        #region Die.
        public override void Die()
        {
            base.Die();
            EnableRagdoll(true);
            _animator.enabled = false;
            Debug.Log("Die");

            GameManager._instance._timer.Add(() =>
            {
                EnableRagdoll(false);
                SpawnAtNewSpawnPoint();
                _animator.enabled = true;
                Reset();
            }, 5.0f);

        }
        #endregion

        #region Update.
        private void Update()
        {
            if (!_isAlive)
            {
                return;
            }

            // Funny :).
            //_animator.Play("Thriller_1");

            _animator.SetFloat("Vertical", 0.5f);

            _moveController.ZombieMove(new Vector2(0.1f, 0.0f));

        }
        #endregion

    }
}

