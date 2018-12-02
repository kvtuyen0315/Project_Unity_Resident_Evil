using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class PlayerState : MonoBehaviour
    {
        #region Enum.
        public enum E_MoveState
        {
            STAND,
            WALKING_FORWARD,
            WALKING_BACKWARD,
            RUNNING_FORWARD,
            TURN_LEFT,
            TURN_RIGHT,
            TURN_180,
            RELOAD,
            AIMING
        }

        public enum E_WeaponState
        {
            IDLE_AIMING,
            AIMED_FIRING
        }
        #endregion

        #region Variable.
        // enum.
        public E_MoveState e_MoveState;
        public E_WeaponState e_WeaponState;

        // Class.
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

        #endregion

        #region Set Move State.
        private void SetMoveState()
        {
            e_MoveState = E_MoveState.STAND; // Stand.

            if (_playerInput._isRuning &&       // Runing.
                _playerInput._vertical > 0.0f)
            {
                e_MoveState = E_MoveState.RUNNING_FORWARD;
            }

            if (_playerInput._isRuning &&       // Turn 180.
                _playerInput._vertical < 0.0f)
            {
                e_MoveState = E_MoveState.TURN_180;
            }

            if (!_playerInput._isRuning &&       // Walking.
                 _playerInput._vertical > 0.0f)
            {
                e_MoveState = E_MoveState.WALKING_FORWARD;
            }

            if (!_playerInput._isRuning &&       // Walking Back.
                 _playerInput._vertical < 0.0f)
            {
                e_MoveState = E_MoveState.WALKING_BACKWARD;
            }

            if (_playerInput._horizontal > 0.0f) // Turn Right.
            {
                e_MoveState = E_MoveState.TURN_RIGHT;
            }

            if (_playerInput._horizontal < 0.0f) // Turn Left.
            {
                e_MoveState = E_MoveState.TURN_LEFT;
            }

            if (_playerInput._fire2)             // Aiming.
            {
                e_MoveState = E_MoveState.AIMING;
            }

            if (_playerInput._reload)            // Reload.
            {
                e_MoveState = E_MoveState.RELOAD;
            }

        }
        #endregion

        #region Set Weapon State.
        private void SetWeaponState()
        {
            e_WeaponState = E_WeaponState.IDLE_AIMING; // Aim.

            if (_playerInput._fire2 && _playerInput._fire1) // Firing.
            {
                e_WeaponState = E_WeaponState.AIMED_FIRING;
            }

        }
        #endregion

        #region Update.
        private void Update()
        {
            SetMoveState();   // Move.
            SetWeaponState(); // Weapon.
        }
        #endregion
    }
}

