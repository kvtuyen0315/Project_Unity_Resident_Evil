using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class MoveController : MonoBehaviour
    {
        #region Variable.
        // float.
        private float _rotationRate = 360.0f;
        private float _speedRotation = 0.003f;
        //private float _speedTurn180  = 0.1f;
        private float _zero = 0.0f;
        #endregion

        #region Move.
        public void Move(Vector2 direction)
        {
            // Old way.
            //transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;

            // Fixed.
            transform.position += transform.forward * direction.x * Time.deltaTime;
            transform.Rotate(_zero, direction.y * _rotationRate * _speedRotation, _zero);
        }
        #endregion

        #region Zombie Move.
        public void ZombieMove(Vector2 direction)
        {
            transform.position += transform.forward * direction.x * Time.deltaTime + transform.right * direction.y * Time.deltaTime;
        }
        #endregion

    }
}

