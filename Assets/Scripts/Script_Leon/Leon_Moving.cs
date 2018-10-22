using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leon_Moving : MonoBehaviour
{
    #region All Variable.
        // Rigidbody.
        private Rigidbody _rb;

        // Animation.
        private Animator _anim;

        // String.
        private string _moveInputAxis = "Vertical";
        private string _turnInputAxis = "Horizontal";
  
        // Name bool of Actions.
        private string _nameWalkingBack = "Is_Walking_Back";
        private string _namePistolAims  = "Is_Pistol_Aims";

        // Float.
        public float _rotationRate  = 360.0f;
        public float _moveSpeedWalk = 0.1f;
        public float _moveSpeedRun  = 0.3f;

        // Float for Walk & Run.
        [Range(0.0f, 1.0f)]
        public float    _valueChangeAnimation   = 0.0f;

        // float weight.
        private float   _weightWalkingBack      = 0.0f;
        private float   _weightPistolAims       = 0.0f;

        // Int.
        private int _idWalkingBack  = 1;
        private int _idPistolAims   = 2;

        // Bool.
        public bool _isTurn_180;
        public bool _isIdleKnife;
        public bool _isAttackKnife;
        public bool _isPistolAims;
        public bool _isWalkingBack;

        // Keyboard.
        // Left Shift.
        public bool _isRuning;
        public bool _minusRun;

        // Vector3 Zero.
        Vector3 vetorZero = Vector3.zero;

        #endregion

    #region Start.
        void Start()
        {
            // Set Rigidbody.
            _rb = GetComponent<Rigidbody>();

            // Set Animation.
            _anim = GetComponent<Animator>();

            // Set bool Aniamtion Pistol Aims.
            _isIdleKnife    = false;
            _isAttackKnife  = false;
            _isPistolAims   = false;
            _isWalkingBack  = false;
            _isTurn_180     = false;

            // Set bool Runing.
            _isRuning       = false;
            _minusRun       = false;

            // Set Interger Animation.
            _anim.SetInteger("WalkingBack", _idWalkingBack);
            _anim.SetInteger("InputActions", _idPistolAims);
        }
        #endregion

    #region Update.
        // Update is called once per frame
        void Update()
        {
            
            // Set float Move & Turn Axis.
            float moveAxis = Input.GetAxis(_moveInputAxis);
            float turnAxis = Input.GetAxis(_turnInputAxis);

            // Set Runing.
            _isRuning = Input.GetKey(KeyCode.LeftShift);

            // Set Input.
            applyInput(moveAxis,
                       turnAxis);

        }
        #endregion

    #region ApplyInput.
        private void applyInput(float move,
                                float turn)
        {
            // Set Animation Pistol Aims.
            if (Input.GetButtonDown("HoldPistolAims"))
            {
                _isWalkingBack = false;
                _isPistolAims = true;

                // Set Rigidbody Velocity.
                _rb.AddForceAtPosition(vetorZero, vetorZero, ForceMode.Impulse);
            }
            else if (Input.GetButtonUp("HoldPistolAims"))
            {
                _isWalkingBack = false;
                _isPistolAims = false;

            }
            else
            {
                // Move.
                if (move > 0.0f)
                {
                    // Set bool Action.
                    _isWalkingBack  = false;

                    // Set Animation Walk & Run.
                    setAniamtionWalkAndRun();
                }
                else if (move < 0.0f)
                {
                    // Set bool Action.
                    _isWalkingBack  = true;

                    _valueChangeAnimation = 0.0f;
                }
                else
                {
                    // Set bool Action.
                    _isWalkingBack  = false;

                    // Set Animation Walk & Run.
                    _valueChangeAnimation -= 0.05f;
                    if (_valueChangeAnimation <= 0.0f)
                    {
                        _valueChangeAnimation = 0.0f;
                    }
                }
                // Walking Back.
                actionWalkingBack(ref _nameWalkingBack,     // string nameAnim.
                                  ref _isWalkingBack,       // bool isAnim.
                                  ref _idWalkingBack,       // int idAnim.
                                  ref _weightWalkingBack);  // float weight.
                
            }

            // Action Pistol Aims.
            actionPistolAims(ref _namePistolAims,       // string nameAnim.
                             ref _isPistolAims,         // bool isAnim.
                             ref _idPistolAims,         // int idAnim.
                             ref _weightPistolAims,     // float weight.
                             ref  move);                // float move.


            // Set Animation for Walk.
            _anim.SetFloat("vertical", _valueChangeAnimation);

            // Move Walk & Run.
            Move(move);

            // Move Turn.
            Turn(turn);
        }

        // Move.
        private void Move(float inputMove)
        {
           
            if (_isRuning == true)
            {
                _rb.AddForce(transform.forward * inputMove * _moveSpeedRun, ForceMode.VelocityChange);
            }
            else
            {
                _rb.AddForce(transform.forward * inputMove * _moveSpeedWalk, ForceMode.VelocityChange);
            }
        }

        // Turn.
        private void Turn(float inputTurn)
        {
            transform.Rotate(0.0f, inputTurn * _rotationRate * 0.005f, 0.0f);
        }
        #endregion

    #region Set Animation.
        private void setAniamtionWalkAndRun()
        {
            _valueChangeAnimation += 0.05f;

            if (_valueChangeAnimation >= 1.0f)
            {
                _valueChangeAnimation = 1.0f;
            }

            if (_isRuning == true)
            {
                if (_valueChangeAnimation >= 1.0f && _minusRun == false)
                {
                    _valueChangeAnimation = 1.0f;
                    _minusRun = true;
                }

            }
            else
            {
                if (_valueChangeAnimation >= 0.5f && _minusRun == false)
                {
                    _valueChangeAnimation = 0.5f;

                }
                else if (_valueChangeAnimation >= 0.5f && _minusRun == true)
                {
                    _valueChangeAnimation -= 0.12f;
                    if (_valueChangeAnimation <= 0.5f)
                    {
                        _valueChangeAnimation = 0.5f;
                        _minusRun = false;
                    }
                }
            }
        }
        #endregion

    #region Set All Action.
        // Action Pistol Aims.
        private void actionPistolAims(ref string nameAnim,  
                                      ref bool isAnim,      
                                      ref int idAnim,       
                                      ref float weight,     
                                      ref float move)       
        {
            if (isAnim == true)
            {
                weight += 0.05f;
                if (weight >= 1.0f)
                {
                    weight = 1.0f;

                    move = 0.0f;
                }
            }
            else
            {
                weight -= 0.05f;
                if (weight <= 0.0f)
                {
                    weight = 0.0f;

                }
            }
            _anim.SetLayerWeight(idAnim, weight);
            _anim.SetBool(nameAnim, isAnim);
        }

        // Action Idle Knife.
        private void actionWalkingBack(ref string nameAnim,
                                       ref bool isAnim,
                                       ref int idAnim,
                                       ref float weight)
        {
            if (isAnim == true)
            {
                weight += 0.05f;
                if (weight >= 1.0f)
                {
                    weight = 1.0f;
                }
            }
            else
            {
                weight -= 0.05f;
                if (weight <= 0.0f)
                {
                    weight = 0.0f;
                }
            }
            _anim.SetLayerWeight(idAnim, weight);
            _anim.SetBool(nameAnim, isAnim);
        }

        #endregion

}

