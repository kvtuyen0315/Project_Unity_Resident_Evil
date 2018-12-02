using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        #region Camera Rig.
        [System.Serializable]
        public class CameraRig
        {
            #region Variable.
            // float.
            public float _damping;

            // Vector 3.
            public Vector3 _cameraOffset;
            
            #endregion

        }
        #endregion

        #region Variable.
        // float.
        [SerializeField] private float _speedAimPivot_Y;
        private float _rateRotation = 360.0f;

        // CameraRig.
        private CameraRig _cameraRig;
        [SerializeField] private CameraRig _defaultCamera;
        [SerializeField] private CameraRig _aimCamera;

        // Vector 3.
        private Vector3 _targetPosition;

        // Quaternion.
        private Quaternion _targetRotation;

        // Transform.
        [SerializeField] private Transform _cameraLookTarget;

        // Class.
        [SerializeField] private Player _localPlayer;

        private InputController m_PlayerInput;
        public InputController _playerInput
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

        private PlayerAim m_PlayerAim;
        public PlayerAim _playerAim
        {
            get
            {
                if (m_PlayerAim == null)
                {
                    m_PlayerAim = GameManager._instance._localPlayer._playerAnim;
                }
                return m_PlayerAim;
            }
        }

        #endregion

        #region Awake.
        private void Awake()
        {
            GameManager._instance._onLocalPlayerJoined += HandlerOnLocalPlayerJoined;
        }
        #endregion

        #region Handler On Local Player Joined.
        private void HandlerOnLocalPlayerJoined(Player player)
        {
            // .
            _localPlayer = player;

            // .
            //_cameraLookTarget = _localPlayer.transform.Find("cameraLookTarget"); // Old way.
            if (_cameraLookTarget == null)
            {
                _cameraLookTarget = _localPlayer.transform;
            }
        }
        #endregion

        #region Set Camera.
        private void SetCamera()
        {
            _cameraRig = _defaultCamera;

            if ((_localPlayer._playerState.e_MoveState   == PlayerState.E_MoveState.AIMING &&
                 _playerInput._fire2) ||
               (_localPlayer._playerState.e_WeaponState == PlayerState.E_WeaponState.AIMED_FIRING &&
                (_playerInput._fire2 &&
                 _playerInput._fire1)))
            {
                //Debug.Log(_playerAim.GetAngel());

                _cameraRig = _aimCamera;

                if (_playerAim.GetAngel() > 0.0f)
                {
                    _cameraRig._cameraOffset.y = _playerAim.GetAngel() / _rateRotation * _speedAimPivot_Y;
                }
                else
                {
                    _cameraRig._cameraOffset.y = _playerAim.GetAngel() / _rateRotation * _speedAimPivot_Y;
                }
                
            }
        }
        #endregion

        #region Set Postion.
        private void SetPosition()
        {
            // Set Target Position.
            _targetPosition = _cameraLookTarget.position                                   + // Positon Object.
                              _localPlayer.transform.forward * _cameraRig._cameraOffset.z  + // z.
                              _localPlayer.transform.up * _cameraRig._cameraOffset.y       + // y.
                              _localPlayer.transform.right * _cameraRig._cameraOffset.x;     // x.

            // Postion.
            transform.position = Vector3.Lerp(transform.position,                    // Vector3 A.
                                              _targetPosition,                       // Vector3 B.
                                              _cameraRig._damping * Time.deltaTime); // Time.
        }
        #endregion

        #region Set Rotation.
        private void SetRotation()
        {
            // Set Target Rotation.
            _targetRotation = Quaternion.LookRotation(_cameraLookTarget.position - _targetPosition, // Forward.
                                                      Vector3.up); // UpForward.

            // Rotation.
            transform.rotation = Quaternion.Lerp(transform.rotation,                    // Angel A.
                                                 _targetRotation,                       // Angel B.
                                                 _cameraRig._damping * Time.deltaTime); // Time.
        }
        #endregion

        #region Update.
        private void LateUpdate()
        {
            if (_localPlayer == null)
            {
                return;
            }

            SetCamera(); // Camera;

            SetPosition(); // Postion.
            SetRotation(); // Rotation.

        }
        #endregion
    }
}

