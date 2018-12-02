using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(Collider))]
    public class Destructable : MonoBehaviour
    {
        #region Variable.
        // float.
        [SerializeField] private float _hitPoints;
        private float _damageTaken;
        public float _hitPointsRemaining
        {
            get
            {
                return _hitPoints - _damageTaken;
            }
        }

        // bool.
        public bool _isAlive
        {
            get
            {
                return _hitPointsRemaining > 0.0f;
            }
        }

        // System Action.
        public event System.Action _onDeath;
        public event System.Action _onDamageReceived;

        #endregion

        #region Die.
        public virtual void Die()
        {
            //if (!_isAlive)
            //{
            //    return;
            //}

            if (_onDeath != null)
            {
                _onDeath();
            }
        }
        #endregion

        #region Take Damage.
        public virtual void TakeDamage(float amount)
        {
            _damageTaken += amount;

            if (_onDamageReceived != null)
            {
                _onDamageReceived();
            }

            if (_hitPointsRemaining <= 0.0f)
            {
                Die();
            }
        }
        #endregion

        #region Reset.
        public void Reset()
        {
            _damageTaken = 0.0f;
        }
        #endregion
    }
}

