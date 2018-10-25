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
    private Vector3 _camAims;

    // String.
    private string _mouseX = "Mouse X";
    private string _mouseY = "Mouse Y";
    private string _turnInputAxis = "Horizontal";

    // Float.
    // Float Zero.
    private float _zero     = 0.0f;

    // float Time.
    private float _timeAtoB = 2.0f; 

    // Speed.
    private float _speed    = 1.8f;

    // Float Angel.
    private float _angelY   = 180.0f;

    // Float Angel Min & Max of X & Y.
    // X.
    private float _angelMinX    = -50.0f;
    private float _angelMaxX    = 50.0f;
    // Y.
    private float _angelMinY    = -50.0f;
    private float _angelMaxY    = 40.0f;

    // Float Distance of Camera with Charater.
    // XYZ Vector A.
    private float _distanceA_X  = 0.0f;
    private float _distanceA_Y  = 0.0f;
    private float _distanceA_Z  = 0.5f;
    // XYZ Vector B.
    private float _distanceB_X  = -0.1f;
    private float _distanceB_Y  = 0.0f;
    private float _distanceB_Z  = 0.5f;

    // Float Current.
    private float _currentX     = 0.0f;
    private float _currentY     = 0.0f;

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

            _currentY = Mathf.Clamp(_currentY,   // Y.
                                    _angelMinY,  // MinY.
                                    _angelMaxY); // MaxY.

            //_currentX = Mathf.Clamp(_currentX,     // X.
            //                          _angelMinX,  // MinX.
            //                          _angelMaxX); // MaxX.

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
        _camDefault = new Vector3(_distanceA_X,   // x.
                                  _distanceA_Y,   // y.
                                  _distanceA_Z);  // z.

        if (_LeonMoving.getTargetIsPistolAims() == true ||
            _LeonMoving.getTargetIdleKnife()    == true)
        {
            // Set Vector3 B.
            _camAims = new Vector3(_distanceB_X,  // x.
                                   _distanceB_Y,  // y.
                                   _distanceB_Z); // z.

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

}
