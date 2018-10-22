using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Variable.
    // Tranform.
    public Transform _lookAt;
    public Transform _camTranform;

    // Camera.
    private Camera   _cam;

    // String.
    private string _mouseX = "Mouse X";
    private string _mouseY = "Mouse Y";
    private string _turnInputAxis = "Horizontal";

    // Float.
    // Float Zero.
    private float _zero = 0.0f;

    // Float Angel.
    private float _angelY = 180.0f;

    // Float Angel Min & Max of X & Y.
    private float _angelMinX = -50.0f;
    private float _angelMaxX = 50.0f;

    private float _angelMinY    = -50.0f;
    private float _angelMaxY    = 50.0f;
   
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
        // Set CamTranform & Camera.
        _camTranform = transform;
        _cam = Camera.main;
    }
    #endregion

    #region Update.
    // Update.
    private void Update()
    {
        // Set float Move Follow on Horizontal.
        _turnCamera += Input.GetAxis(_turnInputAxis);

        // Set Input Mouse X & Y.
        _currentX += Input.GetAxis(_mouseX);
        _currentY += Input.GetAxis(_mouseY);

        // Set Limit Angel X & Y.
        _currentY = Mathf.Clamp(_currentY,   // Y.
                                _angelMinY,  // MinY.
                                _angelMaxY); // MaxY.

        //_currentX = Mathf.Clamp(_currentX,     // X.
        //                          _angelMinX,  // MinX.
        //                          _angelMaxX); // MaxX.

    }

    // Late Update.
    private void LateUpdate()
    {
        // Create Vector 3 & Quaternion.
        Vector3 dir = new Vector3(_distanceX,   // x.
                                  _distanceY,   // y.
                                  _distanceZ);  // z.

        // Change Angel follow Character when Character turn with Func Quaternion.
        Quaternion rotationTurnCamera = Quaternion.Euler(_currentY, _turnCamera * 1.8f, _zero);

        // Set Camera Tranform Postion & Rotation.
        _camTranform.position = _lookAt.position + rotationTurnCamera * dir;
        _camTranform.LookAt(_lookAt.position);
    }
    #endregion

}
