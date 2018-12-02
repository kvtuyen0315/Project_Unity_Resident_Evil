using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class EnemyHealth : Destructable
    {
        #region Variable.
        // Class.
        [SerializeField] private Ragdoll _radoll;


        #endregion

        #region Override.
        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
        }

        public override void Die()
        {
            base.Die();
            _radoll.EnableRagdoll(true);
        }
        #endregion
    }
}

