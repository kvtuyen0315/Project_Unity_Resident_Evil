using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class ShootingRangeTarget : Destructable
    {
        #region Variable.
        // float.
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _repairTime;

        // bool.
        private bool _repairesRotation;

        // Quaternion.
        private Quaternion _initalRotation;
        private Quaternion _targetRotation;

        #endregion

        #region Awake.
        private void Awake()
        {
            _initalRotation = transform.rotation;
            _repairesRotation = false;
        }
        #endregion

        #region Take Damage.
        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
        }
        #endregion

        #region Die.
        public override void Die()
        {
            base.Die();
            _targetRotation = Quaternion.Euler(transform.right * 90.0f);
            _repairesRotation = true;
            GameManager._instance._timer.Add(() =>
            {
                _targetRotation = _initalRotation;
                _repairesRotation = true;
            }, _repairTime);

        }
        #endregion

        #region Update.
        private void Update()
        {
            if (_repairesRotation == false)
            {
                return;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);

            if (transform.rotation == _targetRotation)
            {
                _repairesRotation = false;
            }
        }
        #endregion

    }
}

