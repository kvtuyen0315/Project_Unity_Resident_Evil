using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Health : Destructable
    {
        #region Variable.
        [SerializeField] private float _inSeconds;

        #endregion

        #region Override.
        public override void Die()
        {
            base.Die();

            GameManager._instance._respawner.Despawn(gameObject, _inSeconds);
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);

        }
        #endregion

        #region On Enabled.
        private void OnEnable()
        {
            Reset();
        }
        #endregion
    }
}

