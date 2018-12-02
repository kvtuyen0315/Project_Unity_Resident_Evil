using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Ragdoll : MonoBehaviour
    {
        #region Variable.
        // Animator.
        public Animator _animator;

        // Rigidboy.
        private Rigidbody[] _bodyParts;



        #endregion

        #region Start.
        private void Start()
        {
            //_animator = GetComponent<Animator>();
            _bodyParts = GetComponentsInChildren<Rigidbody>();
            EnableRagdoll(false);
        }
        #endregion

        #region Enable Ragdoll.
        public void EnableRagdoll(bool value)
        {
            _animator.enabled = !value;
            for (int i = 0; i < _bodyParts.Length; i++)
            {
                _bodyParts[i].isKinematic = !value;
            }

        }
        #endregion

    }
}

