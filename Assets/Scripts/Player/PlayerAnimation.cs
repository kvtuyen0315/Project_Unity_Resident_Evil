using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PlayerAnimation : MonoBehaviour
    {
        #region Variable.
        // float.
        //private float m_AimAngle;
        //public float _aimAgle
        //{
        //    get
        //    {
        //        return m_AimAngle;
        //    }
        //}
        

        // Animator.
        private Animator _animator;
        public Animator _getAnimator
        {
            get
            {
                return _animator;
            }
            set
            {
                if (_animator == null)
                {
                    _animator = value;
                }
            }
        }

        // Class.
        private PlayerAim m_PlayerAim;
        public  PlayerAim _playerAim
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

        // bool.
        private bool _isAiming  = true;
        private bool _isWalking = true;
        private bool _isRuning  = true;

        #endregion

        #region Awake.
        private void Awake()
        {
            _animator = GetComponentInChildren<Animator>();
        }
        #endregion

        #region Update.
        private void Update()
        {
            if (_playerInput._fire2)
            {
                // Aiming.
                _animator.SetBool("RifleIdleAiming", _isAiming);

                // Aiming Up & Down.
                _animator.SetFloat("AimAngle", _playerAim.GetAngel());
                //Debug.Log(_playerAim.GetAngel());

                // Walking.
                _animator.SetBool("Walk", !_isWalking);

                // Runing.
                _animator.SetBool("Run", !_isRuning);
            }
            else if (_playerInput._isRuning)
            {
                // Aiming.
                _animator.SetBool("RifleIdleAiming", !_isAiming);

                // Walking.
                _animator.SetBool("Walk", !_isWalking);

                // Runing.
                _animator.SetBool("Run", _isRuning);

                if (_isRuning)
                {
                    // Runing.
                    _animator.SetFloat("VerticalRun", GameManager._instance._inputController._vertical);
                    _animator.SetFloat("HorizontalRun", GameManager._instance._inputController._horizontal);
                }
            }
            else
            {
                // Aiming.
                _animator.SetBool("RifleIdleAiming", !_isAiming);

                // Aiming Up & Down.
                _animator.SetFloat("AimAngle", _playerAim.GetAngel());
                

                // Walking.
                _animator.SetBool("Walk", _isWalking);

                if (_isWalking)
                {
                    // Walking.
                    _animator.SetFloat("VerticalWalk", GameManager._instance._inputController._vertical);
                    _animator.SetFloat("HorizontalWalk", GameManager._instance._inputController._horizontal);
                }

                // Runing.
                _animator.SetBool("Run", !_isRuning);
                
            }
        }
        #endregion
    }
}

