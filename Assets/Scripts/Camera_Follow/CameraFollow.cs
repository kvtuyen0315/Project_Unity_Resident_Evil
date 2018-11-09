using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class CameraFollow : MonoBehaviour
    {
        #region Variable.
        // Set Target Character Leon.
        [SerializeField]
        private Leon_Custom _LeonMoving = new Leon_Custom();

        // Tranform.
        public Transform _lookAt;
        public Transform _camTranform;

        // Camera.
        private Camera _cam;

        // Vector 3.
        private Vector3 _camDefault;
        private Vector3 _camAims;

        // String.
        private string _mouseX = "Mouse X";
        private string _mouseY = "Mouse Y";
        private string _turnInputAxis = "Horizontal";

        // Float.
        // Float Zero.
        private float _zero = 0.0f;

        // float Time.
        private float _timeAtoB = 1.0f;

        // Speed.
        private float _speed = 1.8f;

        // Float Angel.
        private float _angelY = 180.0f;

        // Float Angel Min & Max of X & Y.
        // X.
        private float _angelMinX = -50.0f;
        private float _angelMaxX = 50.0f;
        // Y.
        private float _angelMinY = -50.0f;
        private float _angelMaxY = 40.0f;

        // Float Distance of Camera with Charater.
        // XYZ Vector.
        private float _distanceX = 0.0f; // -0.1f
        private float _distanceY = 0.0f;
        private float _distanceZ = 0.5f;

        // Float Current.
        private float _currentX = 0.0f;
        private float _currentY = 0.0f;

        // Float Turn Camera.
        private float _turnCamera = 0.0f;

        // Rotation Rate.
        private float _rotationRate = 360.0f;

        #endregion

        #region Start.
        private void Start()
        {
            // Set Target character Leon.
            _LeonMoving.getTargetIsPistolAims();
            _LeonMoving.getTargetIdleKnife();

            // Set CamTranform & Camera.
            _camTranform = transform;
            _cam = Camera.main;
        }
        #endregion

        #region Update.
        // Update.
        private void Update()
        {
            if (_LeonMoving.getTargetIsPistolAims() == true ||
                _LeonMoving.getTargetIdleKnife()    == true)
            {
                // Set Input Mouse X & Y.
                _currentX += Input.GetAxis(_mouseX);
                _currentY += Input.GetAxis(_mouseY);

                _currentY = Mathf.Clamp(_currentY,   // Y normal.
                                        _angelMinY,  // Min Y.
                                        _angelMaxY); // Max Y.

                //_currentX = Mathf.Clamp(_currentX,     // X normal.
                //                          _angelMinX,  // Min X.
                //                          _angelMaxX); // Max X.

            }
            else
            {
                // Set float Move Follow on Horizontal.
                _turnCamera += Input.GetAxis(_turnInputAxis);

                // Set Input Mouse Y.
                _currentY += Input.GetAxis(_mouseY);

                // Set Limit Angel X & Y.
                _currentY = Mathf.Clamp(_currentY,   // Y normal.
                                        _angelMinY,  // MinY.
                                        _angelMaxY); // MaxY.

            }

        }

        // Late Update.
        private void LateUpdate()
        {
            if (_LeonMoving.getTargetIsPistolAims() == true ||
                _LeonMoving.getTargetIdleKnife()    == true)
            {
                // Minus Distance.
                minusdistanceToAims(ref _distanceX,  // x.
                                    ref _distanceY,  // y.
                                    ref _distanceZ); // z.

                // Set Vector3 B.
                _camAims = new Vector3(_distanceX,  // x.
                                       _distanceY,  // y.
                                       _distanceZ); // z.

                Vector3 ChangCamera = Vector3.Lerp(_camDefault, // Vector3 A.
                                                   _camAims,    // Vector3 B.
                                                   _timeAtoB);  // Time.

                // Change Angel follow Character when Character turn with Func Quaternion. 
                Quaternion rotationTurnCamera = Quaternion.Euler(_currentY,             // x.
                                                                 _turnCamera * _speed,  // y.
                                                                 _zero);                // z.

                // Set Camera Tranform Postion & Rotation.
                _camTranform.position = _lookAt.position + rotationTurnCamera * ChangCamera;
                _camTranform.LookAt(_lookAt.position);
            }
            else
            {
                returnMinusdistance(ref _distanceX,  // x.
                                    ref _distanceY,  // y.
                                    ref _distanceZ); // z.

                // Set Vector3 A.
                _camDefault = new Vector3(_distanceX,   // x.
                                          _distanceY,   // y.
                                          _distanceZ);  // z.

                // Return to Camera.
                if (_LeonMoving.getTargetMoveAxis() > _zero ||
                        _LeonMoving.getTargetMoveAxis() < _zero)
                {
                    if (_currentY > _zero)
                    {
                        _currentY -= 0.8f;
                        if (_currentY < _zero)
                        {
                            _currentY = _zero;
                        }
                    }
                    else
                    {
                        _currentY += 0.8f;
                        if (_currentY > _zero)
                        {
                            _currentY = _zero;
                        }
                    }

                }

                // Change Angel follow Character when Character turn with Func Quaternion.
                Quaternion rotationTurnCamera = Quaternion.Euler(_currentY,             // x.
                                                                 _turnCamera * _speed,  // y.
                                                                 _zero);                // z.

                // Set Camera Tranform Postion & Rotation.
                _camTranform.position = _lookAt.position + rotationTurnCamera * _camDefault;
                _camTranform.LookAt(_lookAt.position);
            }
            
        }
        #endregion

        #region Minus Distance.
        private void minusdistanceToAims(ref float distanceX,
                                         ref float distanceY,
                                         ref float distanceZ)
        {
            // Distance X.
            distanceX -= 0.01f;
            if (distanceX < -0.1f)
            {
                distanceX = -0.1f;
            }

            // Free Distance Y.

            // Distance Z.
            if (distanceZ >= 0.5f)
            {
                distanceZ -= 0.01f;
                if (distanceZ < 0.4f)
                {
                    distanceZ = 0.4f;
                }
            }

        }

        private void returnMinusdistance(ref float distanceX,
                                         ref float distanceY,
                                         ref float distanceZ)
        {
            // Distance X.
            distanceX += 0.01f;
            if (distanceX > _zero)
            {
                distanceX = _zero;
            }

            // Free Distance Y.

            // Distance Z.
            if (_LeonMoving.getTargetIsRuning() == true)
            {
                distanceZ += 0.01f;
                if (distanceZ > 0.7f)
                {
                    distanceZ = 0.7f;
                }
            }
            else
            {
                if (distanceZ > 0.5f)
                {
                    distanceZ -= 0.005f;
                    if (distanceZ < 0.5f)
                    {
                        distanceZ = 0.5f;
                    }
                }
                else
                {
                    distanceZ += 0.005f;
                    if (distanceZ > 0.5f)
                    {
                        distanceZ = 0.5f;
                    }
                }
                
            }
            
        }
        #endregion

    }
}

