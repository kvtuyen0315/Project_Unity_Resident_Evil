using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [RequireComponent(typeof(MoveController))]
    [RequireComponent(typeof(PlayerState))]
    public class Player : MonoBehaviour
    {
        #region System Serializable.
        [System.Serializable]
        public class MouseInput
        {
            #region Variable.
            // Vector 2.
            public Vector2 _damping;
            public Vector2 _sensitivity;
            #endregion
        }

        #endregion

        #region Variable.
        // float.
        private float _zero = 0.0f;
        [SerializeField] private MovingSettings _settings;

        // Class.
        [SerializeField] private MouseInput _mouseController;
        [SerializeField] private WeaponReloader _weaponReloaderRifle;
        [SerializeField] private WeaponReloader _weaponReloaderShotgun;

        public PlayerAim _playerAnim;

        private MoveController m_MoveController;
        public MoveController _moveController
        {
            get
            {
                if (m_MoveController == null)
                {
                    m_MoveController = GetComponent<MoveController>();
                }
                return m_MoveController;
            }
        }

        private InputController _playerInput;
        [SerializeField] private AudioController _audioFootSteps;

        private PlayerShooter m_PlayerShooter;
        public PlayerShooter _playerShooter
        {
            get
            {
                if (m_PlayerShooter == null)
                {
                    m_PlayerShooter = GetComponent<PlayerShooter>();
                }
                return m_PlayerShooter;
            }
        }

        private PlayerState m_PlayerState;
        public  PlayerState _playerState
        {
            get
            {
                if (m_PlayerState == null)
                {
                    m_PlayerState = GetComponent<PlayerState>();
                }
                return m_PlayerState;
            }
        }

        // Vector2.
        private Vector2 _direction;
        private Vector2 _mouseInput;

        // Vector3.
        private Vector3 _previousPosition;

        #endregion

        #region Awake.
        private void Awake()
        {
            _playerInput = GameManager._instance._inputController;
            GameManager._instance._localPlayer = this;
        }
        #endregion

        #region Move.
        private void Move()
        {
            if (_playerInput._isRuning &&
                _playerInput._vertical > _zero)
            {
                // Move Vertical.
                _direction = new Vector2(_playerInput._vertical * _settings._leonRunSpeed,      // x.
                                         _playerInput._horizontal * _settings._leonRotationSpeed); // y.
            }
            else if (_playerInput._isRuning &&
                     _playerInput._vertical < _zero)
            {
                // Move Vertical.
                _direction = new Vector2(_playerInput._vertical * _zero,          // x.
                                         _playerInput._vertical * _settings._leonTurn180Speed); // y.
            }
            else
            {
                // Move Vertical.
                _direction = new Vector2(_playerInput._vertical * _settings._leonWalkSpeed,     // x.
                                         _playerInput._horizontal * _settings._leonRotationSpeed); // y.
            }

            // Audio Sound FootSteps.
            if (Vector3.Distance(transform.position, _previousPosition) > _settings._leonMiniumMoveTreshold)
            {
                _audioFootSteps.Play();
            }

            _previousPosition = transform.position;
        }
        #endregion

        #region Turn.
        private void Turn()
        {
            // Aiming.
            if (_playerInput._fire2                         ||
                _weaponReloaderRifle._isReloading   == true ||
                _weaponReloaderShotgun._isReloading == true)
            {
                // Mouse turn.
                _mouseInput.x = Mathf.Lerp(_mouseInput.x,                       // A.
                                           _playerInput._mouseInput.x,          // B.
                                           1.0f / _mouseController._damping.x); // Time.

                _mouseInput.y = Mathf.Lerp(_mouseInput.y,                       // A.
                                           _playerInput._mouseInput.y,          // B.
                                           1.0f / _mouseController._damping.y); // Time.

                // Move Vertical.
                _direction = new Vector2(_playerInput._vertical * _zero,    // x.
                                         _playerInput._horizontal * _zero); // y.

                // Rotation.
                transform.Rotate(Vector3.up * _mouseInput.x * _mouseController._sensitivity.x); // x.
                _playerAnim.SetRotation(_mouseInput.y * _mouseController._sensitivity.y); // y.
            }
            else
            {
                // Rotation.
                transform.Rotate(Vector3.up * _mouseInput.x * _mouseController._sensitivity.x * _zero); // x.
                _playerAnim.SetRotation(_zero); // y.
            }

            
        }
        #endregion

        #region Update.
        private void Update()
        {
            Move();
            Turn();

            // Moving.
            _moveController.Move(_direction);

            // Character Controller.
            //_moveController.SimpleMove(transform.forward * _direction.x);
            //transform.Rotate(_zero,_direction.y * 360.0f, _zero);
        }
        #endregion
    }
}
