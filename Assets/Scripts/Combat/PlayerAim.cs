using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PlayerAim : MonoBehaviour
    {
        #region Variable.
        // float.
        private float _angle;
        private float _rateAngle = 180.0f;

        // Class.
        private InputController m_PlayerInput;
        public  InputController _playerInput
        {
            get
            {
                if (m_PlayerInput == null)
                {
                    m_PlayerInput = GameManager._instance._inputController;
                }
                return m_PlayerInput;
            }
        }
        #endregion

        #region Set Rotation.
        public void SetRotation(float amount)
        {
            if (_playerInput._fire2)
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x - amount, // x.
                                                transform.eulerAngles.y,              // y.
                                                transform.eulerAngles.z);             // z.
            }
            else
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x * amount, // x.
                                                transform.eulerAngles.y * amount,     // y.
                                                transform.eulerAngles.z * amount);    // z.
            }
            

        }
        #endregion

        #region Get & Set Angel.
        public float GetAngel()
        {
            return CheckAngle(transform.eulerAngles.x);
        }
        #endregion

        #region Check Angle.
        public float CheckAngle(float value)
        {
            _angle = value - _rateAngle;

            if (_angle > 0.0f)
            {
                return _angle - _rateAngle;
            }

            return _angle + _rateAngle;
            
        }
        #endregion

        #region Update.
        private void Update()
        {
            //Debug.Log(GetAngel());
        }
        #endregion

    }
}

