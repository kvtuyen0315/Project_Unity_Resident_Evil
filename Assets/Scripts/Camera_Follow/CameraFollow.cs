
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variable.
    // Set Target Character Leon.
    public Leon_Moving _LeonMoving = new Leon_Moving();

    // Tranform.
    public Transform _lookAt;
    public Transform _camTranform;

    // Camera.
    private Camera   _cam;

    // Vector 3.
    private Vector3 _camDefault;
    private Vector3 _camPistolAims;

    // String.
    private string _mouseX = "Mouse X";
    private string _mouseY = "Mouse Y";
    private string _turnInputAxis = "Horizontal";

    // Float.
    // Float Zero.
    private float _zero = 0.0f;

    // Speed.
    private float _speed = 1.8f;

    // Float Angel.
    private float _angelY = 180.0f;

    // Float Angel Min & Max of X & Y.
    private float _angelMinX = -50.0f;
    private float _angelMaxX = 50.0f;

    private float _angelMinY    = -50.0f;
    private float _angelMaxY    = 40.0f;
   
    // Float Distance of Camera with Charater.
    private float _distanceX = 0.0f;
    private float _distanceY = 0.0f;
    private float _distanceZ = 0.5f;

    // Float Current.
    private float _currentX = 0.0f;
    private float _currentY = 0.0f;

    // Float Turn Camera.
    private float _turnCamera;

    // Rotation Rate.
    private float _rotationRate = 360.0f;

    #endregion

    #region Start.
    private void Start()
    {
        // Set Target character Leon.
        _LeonMoving.getTargetIsPistolAims();
        
        // Set CamTranform & Camera.
        _camTranform = transform;
        _cam = Camera.main;
    }
    #endregion

    #region Update.
    // Update.
    private void Update()
    {
        if (_LeonMoving.getTargetIsPistolAims() == true)
        {
            // Set Input Mouse X & Y.
            _currentX += Input.GetAxis(_mouseX);
            _currentY += Input.GetAxis(_mouseY);

            _currentY = Mathf.Clamp(_currentY,   // Y.
                                    _angelMinY,  // MinY.
                                    _angelMaxY); // MaxY.

            _currentX = Mathf.Clamp(_currentX,     // X.
                                      _angelMinX,  // MinX.
                                      _angelMaxX); // MaxX.

        }
        else
        {
            // Set float Move Follow on Horizontal.
            _turnCamera += Input.GetAxis(_turnInputAxis);

            // Set Input Mouse Y.
            _currentY += Input.GetAxis(_mouseY);

            // Set Limit Angel X & Y.
            _currentY = Mathf.Clamp(_currentY,   // Y.
                                    _angelMinY,  // MinY.
                                    _angelMaxY); // MaxY.
            
        }

    }

    // Late Update.
    private void LateUpdate()
    {

        // Set Vector3 A.
        _camDefault = new Vector3(_distanceX,   // x.
                                  _distanceY,   // y.
                                  _distanceZ);  // z.

        if (_LeonMoving.getTargetIsPistolAims() == true)
        {
            // Set Vector3 B.
            _camPistolAims = new Vector3(-0.1f,  // x.
                                         0.1f,   // y.
                                         0.4f);  // z.

            Vector3 ChangCamera = Vector3.Lerp(_camDefault,    // Vector3 A.
                                                _camPistolAims, // Vector3 B.
                                                2.0f);          // Time.

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
            // Create Vector 3 & Quaternion.
            Vector3 dir = new Vector3(_distanceX,   // x.
                                      _distanceY,   // y.
                                      _distanceZ);  // z.

            // Change Angel follow Character when Character turn with Func Quaternion.
            Quaternion rotationTurnCamera = Quaternion.Euler(_currentY,             // x.
                                                             _turnCamera * _speed,  // y.
                                                             _zero);                // z.

            // Set Camera Tranform Postion & Rotation.
            _camTranform.position = _lookAt.position + rotationTurnCamera * dir;
            _camTranform.LookAt(_lookAt.position);
        }
        
    }
    #endregion

}
