using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class InputController : MonoBehaviour
    {
        #region Variable.
        // float.
        public float _vertical;
        public float _horizontal;
        public float _mouseX;
        public float _mouseY;

        // bool.
        public bool _fire1;
        public bool _fire2;
        public bool _reload;
        public bool _isRuning;
        public bool _isTurn180;
        public bool _mouseWheelUp;
        public bool _mouseWheelDown;
        public bool _pickupItems;

        // Vector2.
        public Vector2 _mouseInput;

        #endregion


        #region Update.
        private void Update() // Update.
        {
            // Set mouse X & Y.
            _mouseX = Input.GetAxis("Mouse X");
            _mouseY = Input.GetAxis("Mouse Y");

            // Set Input.
            _vertical   = Input.GetAxis("Vertical");
            _horizontal = Input.GetAxis("Horizontal");
            _mouseInput = new Vector2(_mouseX, _mouseY);
            _fire1      = Input.GetButton("Fire1");
            _fire2      = Input.GetButton("Fire2");
            _reload     = Input.GetKeyDown(KeyCode.R);
            _isRuning   = Input.GetKey(KeyCode.Space);
            _mouseWheelUp   = Input.GetAxis("Mouse ScrollWheel") > 0;
            _mouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0;
            _pickupItems = Input.GetKeyDown(KeyCode.F);
        }
        #endregion
    }
}

