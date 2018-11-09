using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class Leon_Custom : MonoBehaviour
    {
        #region Variable.
        // Rigidbody.
        private Rigidbody _rb;

        // Animator.
        private Animator _anim;

        // string.
        private string _moveInputAxis = "Vertical";
        private string _turnInputAxis = "Horizontal";

        // string Animation bool name.
        private string _nameRuning       = "Runing";
        private string _nameWalking      = "Walking";
        private string _nameTurnRight    = "Turn_Right";
        private string _nameTurnLeft     = "Turn_Left";
        private string _nameWalkingBack  = "Walking_Back";
        private string _nameIdleKnife    = "Idle_Knife";
        private string _nameAttackKnife  = "Attack_Knife";
        private string _nameIdlePistol   = "Idle_Pistol";
        private string _nameAttackPistol = "Attack_Pistol";

        // bool Animation.
        public bool _runing         = false;
        public bool _walking        = false;
        public bool _turnRight      = false;
        public bool _turnLeft       = false;
        public bool _walkingBack    = false;
        public bool _idleKnife      = false;
        public bool _attackKnife    = false;
        public bool _idlePistol     = false;
        public bool _attackPistol   = false;

        // bool Keyboard.
        public bool _isRuning   = false; // Left Shift.
        // Mouse.
        public bool _mouseRight = false; // Mouse Right.
        public bool _mouseLeft  = false; // Mouse Left.

        // float.
        private float _zero = 0.0f;

        // float Rotation rate.
        private float _rotationRate = 360.0f;

        // float Move.
        public float _moveAxis = 0.0f;
        public float _turnAxis = 0.0f;

        // float Move & Rotation Speed.
        private float _moveSpeedWalk = 0.25f;
        private float _moveSpeedRun  = 0.5f;
        private float _speedRotation = 0.005f;

        // Int.
        public int _changeWeapon = 1; // Set Knife Begin.
        // Int Weapon.
        private int _knife  = 1;
        private int _pistol = 2;

        // Vector 3.
        Vector3 _zeroVector = Vector3.zero;

        #endregion

        #region Start.
        // Use this for initialization
        void Start()
        {
            // Set Rigidbody.
            _rb = GetComponent<Rigidbody>();

            // Set Animator.
            _anim = GetComponent<Animator>();
        }
        #endregion

        #region Get Target.
        public bool getTargetIdleKnife() // Idle Knife.
        {
            return _idleKnife;
        }

        public bool getTargetIsPistolAims() // Idle Pistol.
        {
            return _idlePistol;
        }

        public bool getTargetIsRuning() // Runing.
        {
            return _isRuning;
        }

        public float getTargetMoveAxis() // Move Axis.
        {
            return _moveAxis;
        }

        #endregion

        #region Update.
        // Update is called once per frame
        void Update()
        {
            // Set float Move & Turn Axis.
            _moveAxis = Input.GetAxis(_moveInputAxis);
            _turnAxis = Input.GetAxis(_turnInputAxis);

            // Set Run.
            _isRuning = Input.GetKey(KeyCode.LeftShift);

            // Set Input Mouse Right & Left.
            _mouseLeft  = Input.GetKey(KeyCode.Mouse0);
            _mouseRight = Input.GetKey(KeyCode.Mouse1);

            // Set Apply Input.
            applyInput(ref _moveAxis,
                       ref _turnAxis);

        }
        #endregion

        #region Apply Input.
        private void applyInput(ref float move,
                                ref float turn)
        {
            // Set Weapon.
            changeWeapon();

            // Set Move & Turn.
            MoveAndTurn(ref move,   // float move.
                        ref turn);  // float turn.

            // Set Input Mouse.
            inputMouse();

            // Set bool Animation.
            boolAnimation();

            // Apply Force Move & Rotation.
            applyMoveForce(ref move);
            applyTurn(ref turn);
        }

        #endregion

        #region Input Change Weapon.
        private void changeWeapon()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))      // Knife.
            {
                _changeWeapon = _knife;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) // Pistol Gun.
            {
                _changeWeapon = _pistol;
            }
        }
        #endregion

        #region Move & Turn.
        private void MoveAndTurn(ref float move,
                                 ref float turn)
        {
            // Turn.
            if (turn > _zero)
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Run & Walk & Turn Right & Left & Walking Back.
                    _runing      = false;
                    _walking     = false;
                    _turnRight   = true;
                    _turnLeft    = false;
                    _walkingBack = false;

                }
            }
            else if (turn < _zero)
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Run & Walk & Turn Right & Left & Walking Back.
                    _runing      = false;
                    _walking     = false;
                    _turnRight   = false;
                    _turnLeft    = true;
                    _walkingBack = false;

                }
            }
            else
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Turn Right & Left & Walking Back.
                    _turnRight = false;
                    _turnLeft  = false;

                }
            }

            // Move.
            if (move > _zero)
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Run & Walk & Turn Right & Left & Walking Back.
                    if (_isRuning == true)
                    {
                        if (_walking == true)
                        {
                            _runing  = true;
                        }
                        else
                        {
                            _walking = false;
                            _runing  = true;
                        }
                    }
                    else
                    {
                        _runing  = false;
                        _walking = true;
                    }
                    _turnRight   = false;
                    _turnLeft    = false;
                    _walkingBack = false;

                }
            }
            else if (move < _zero)
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Run & Walk & Turn Right & Left & Walking Back.
                    _runing      = false;
                    _walking     = false;
                    _turnRight   = false;
                    _turnLeft    = false;
                    _walkingBack = true;

                }
            }
            else
            {
                // Get Idle Weapon.
                if (_idleKnife  == true ||
                    _idlePistol == true)
                {
                    // Do nothing.
                }
                else
                {
                    // Set Run Walk & Walking Back.
                    _runing      = false;
                    _walking     = false;
                    _walkingBack = false;

                }
            }
            
        }
        #endregion

        #region Bool Animation.
        private void boolAnimation()
        {
            // Animation Runing.
            playAnimation(ref _nameRuning, // string name Animation.
                          ref _runing);    // bool Animation.

            // Animation Walking.
            playAnimation(ref _nameWalking, // string name Animation.
                          ref _walking);    // bool Animation.

            // Animation Turn Right.
            playAnimation(ref _nameTurnRight, // string name Animation.
                          ref _turnRight);    // bool Animation.

            // Animation Turn Left.
            playAnimation(ref _nameTurnLeft, // string name Animation.
                          ref _turnLeft);    // bool Animation.

            // Animation Walking Back.
            playAnimation(ref _nameWalkingBack, // string name Animation.
                          ref _walkingBack);    // bool Animation.

            // Aniamtion Idle Knife.
            playAnimation(ref _nameIdleKnife, // string name Animation.
                          ref _idleKnife);    // bool Animation.

            // Aniamtion Attack Knife.
            playAnimation(ref _nameAttackKnife, // string name Animation.
                          ref _attackKnife);    // bool Animation.

            // Aniamtion Idle Pistol.
            playAnimation(ref _nameIdlePistol, // string name Animation.
                          ref _idlePistol);    // bool Animation.

            // Aniamtion Attack Pistol.
            playAnimation(ref _nameAttackPistol, // string name Animation.
                          ref _attackPistol);    // bool Animation.
        }

        // Set bool Play Animation.
        private void playAnimation(ref string nameAnim,
                                   ref bool   isAnim)
        {
            _anim.SetBool(nameAnim, isAnim);
        }
        #endregion

        #region Apply Force.
        // Move.
        private void applyMoveForce(ref float move) // Move Walking & Runing & Walking Back.
        {
            if (_mouseRight == true)
            {
                // Do nothing.
            }
            else
            {
                if (_isRuning == true)
                {
                    _rb.AddForce(transform.forward * move * _moveSpeedRun, ForceMode.Impulse);
                }
                else
                {
                    _rb.AddForce(transform.forward * move * _moveSpeedWalk, ForceMode.Impulse);
                }
            }
            
        }

        // Turn.
        private void applyTurn(ref float turn) // Rotation.
        {
            if (_mouseRight == true)
            {
                // Do nothing.
            }
            else
            {
                transform.Rotate(_zero, turn * _rotationRate * _speedRotation, _zero);
            }
        }
        #endregion

        #region Input Mouse.
        private void inputMouse()
        {
            // Set Input Mouse Right.
            if (_mouseRight == true)
            {
                // Set Idle Weapon.
                if (_changeWeapon == _knife)
                {
                    _idleKnife = true;
                }
                else if (_changeWeapon == _pistol)
                {
                    _idlePistol = true;
                }

                // Set Rigidbody Velocity.
                _rb.AddForce(_zeroVector, ForceMode.Impulse);

                // Set Input Mouse Left.
                if (_mouseLeft == true)
                {
                    // Set Idle Weapon.
                    if (_changeWeapon == _knife)
                    {
                        _attackKnife = true;
                    }
                    else if (_changeWeapon == _pistol)
                    {
                        _attackPistol = true;
                    }
                }
                else
                {
                    // Set Idle Weapon.
                    if (_changeWeapon == _knife)
                    {
                        _attackKnife = false;
                    }
                    else if (_changeWeapon == _pistol)
                    {
                        _attackPistol = false;
                    }
                }
            }
            else
            {
                // Set Idle Weapon.
                if (_changeWeapon == _knife)
                {
                    _idleKnife = false;
                }
                else if (_changeWeapon == _pistol)
                {
                    _idlePistol = false;
                }
            }
        }
        #endregion
    }

}