using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leon_Moving : MonoBehaviour
{
#region All Variable.
    // Rigidbody.
    public Rigidbody _rb;

    // Animation.
    private Animator _anim;

    // String.
    private string _moveInputAxis = "Vertical";
    private string _turnInputAxis = "Horizontal";

    // Name bool of Actions.
    private string _nameTurnRight       = "Is_Turn_Right";
    private string _nameTurnLeft        = "Is_Turn_Left";
    private string _nameWalkingBack     = "Is_Walking_Back";
    private string _nameIdleKnife       = "Is_Ide_Knife";
    private string _nameAttackKnife     = "Is_Attack_Knife";
    private string _namePistolAims      = "Is_Pistol_Aims";

    // Float.
    private float _zero = 0.0f;

    // float Time to Action Attack Knife.
    private float _timeAttackKnife = 0.0f;

    // float move & turn.
    public float moveAxis = 0.0f;
    public float turnAxis = 0.0f;

    public float _rotationRate  = 360.0f;
    public float _moveSpeedWalk = 0.1f;
    public float _moveSpeedRun  = 0.3f;

    public float _speedRotation = 0.005f;

    // Float for Walk & Run.
    [Range(0.0f, 1.0f)]
    public float    _valueChangeAnimation   = 0.0f;

    // float weight.
    private float   _weightTurnRight        = 0.0f;
    private float   _weightTurnLeft         = 0.0f;
    private float   _weightWalkingBack      = 0.0f;
    private float   _weightInputHoldAction  = 0.0f;
    private float   _weightAttackKnife      = 0.0f;

    private const float _weightMax          = 1.0f;
    private const float _weightMin          = 0.0f;
    private const float _minusWeight        = 0.05f;

    // Int.
    // Int Id Action.
    private int _idTurnRight            = 1;
    private int _idTurnLeft             = 2;
    private int _idWalkingBack          = 3;
    private int _idInputHoldAction      = 4;
    private int _idInputAttackKnife     = 5;

    // Int is Action Change.
    private int _changeAction   = 1;
    private const int _isKnife  = 1;
    private const int _isGun    = 2;

    // Bool.
    public bool _isTurnRight;
    public bool _isTurnLeft;
    public bool _isTurn_180;
    public bool _isWalkingBack;
    public bool _isPistolAims;
    public bool _isIdleKnife;
    public bool _isAttackKnife;

    // bool.
    private bool _isAttack;

    // Keyboard.
    // Left Shift.
    public  bool _isRuning;
    private bool _minusRun;

    // bool Input Mouse Right & Left.
    public bool _mouseRight;
    public bool _mouseLeft;

    // Vector3 Zero.
    Vector3 _vetorZero = Vector3.zero;

#endregion

#region Start.
    void Start()
    {
        // Set Rigidbody.
        _rb = GetComponent<Rigidbody>();

        // Set Animation.
        _anim = GetComponent<Animator>();

        // Set bool Aniamtion Pistol Aims.
        _isTurnRight    = false;
        _isTurnLeft     = false;
        _isTurn_180     = false;
        _isWalkingBack  = false;
        _isPistolAims   = false;
        _isIdleKnife    = false;
        _isAttackKnife  = false;

        _isAttack       = false;

        // Set bool Runing.
        _isRuning       = false;
        _minusRun       = false;

        // Set Interger Animation.
        //_anim.SetInteger("Turn_Right",       _idTurnRight);
        //_anim.SetInteger("Turn_Left",        _idTurnLeft);
        //_anim.SetInteger("WalkingBack",      _idWalkingBack);
        //_anim.SetInteger("InputHoldActions", _idInputHoldAction);
        //_anim.SetInteger("Attack_Knife",     _idInputAttackKnife);
    }
#endregion

#region Update.
    // Update is called once per frame
    void Update()
    {
        // Set float Move & Turn Axis.
        moveAxis = Input.GetAxis(_moveInputAxis);
        turnAxis = Input.GetAxis(_turnInputAxis);

        // Set Runing.
        _isRuning = Input.GetKey(KeyCode.LeftShift);

        // Set Input Mouse Right & Left.
        _mouseRight = Input.GetKeyDown(KeyCode.Mouse0);
        _mouseLeft  = Input.GetKey(KeyCode.Mouse1);

        // Set Input.
        applyInput(ref moveAxis,
                   ref turnAxis);

    }
#endregion

#region ApplyInput.
    private void applyInput(ref float move,
                            ref float turn)
    {
        // Set Input Change Action.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _changeAction = _isKnife;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _changeAction = _isGun;
        }

        // Set Mouse Left Click.
        if (_mouseLeft == true)
        {
            // Set Walking Back = false because is Action to stand.
            _isWalkingBack = false;

            if (_changeAction == _isKnife)
            {
                _isIdleKnife = true;
            }
            else if (_changeAction == _isGun)
            {
                    
                _isPistolAims = true;
            }

            // Set Rigidbody Velocity.
            _rb.AddForceAtPosition(_vetorZero, _vetorZero, ForceMode.Impulse);

        }
        else
        {
            // Set All Action to false.
            _isWalkingBack  = false;

            if (_changeAction == _isKnife)
            {
                _isIdleKnife = false;
            }
            else if (_changeAction == _isGun)
            {
                _isPistolAims = false;
            }
               
        }

        // Set Mouse Right Click.
        if (_mouseRight == true)
        {
            if (_changeAction == _isKnife)
            {
                if (_isAttack == false)
                {
                    if (_isIdleKnife == true)
                    {
                        // Set Time Action.
                        _timeAttackKnife = _weightMax;

                        _isAttackKnife = true;

                    }
                }
                
            }
            else if (_changeAction == _isGun)
            {
                // Set bool Fire Pistol.
            }
        }
        else
        {
            if (_changeAction == _isKnife)
            {

            }
            else if (_changeAction == _isGun)
            {
                // Set bool Fire Pistol.
            }
        }

        // Move & Turn.
        ifMoveAndTurn(ref move,  // float Move.
                      ref turn); // float Turn.

        // Walking Back.
        actionWalkingBack(ref _nameWalkingBack,    // string nameAnim.
                          ref _isWalkingBack,      // bool isAnim.
                          ref _idWalkingBack,      // int idAnim.
                          ref _weightWalkingBack); // float weight.

        // Action Turn Right.
        actionTurn(ref _nameTurnRight,   // string nameAnim.
                   ref _isTurnRight,     // bool isAnim.
                   ref _idTurnRight,     // int idAnim.
                   ref _weightTurnRight, // float weight.
                   ref move);            // float move.

        // Action Turn Left.
        actionTurn(ref _nameTurnLeft,   // string nameAnim.
                   ref _isTurnLeft,     // bool isAnim.
                   ref _idTurnLeft,     // int idAnim.
                   ref _weightTurnLeft, // float weight.
                   ref move);           // float move.

        if (_changeAction == _isKnife)
        {
            // Action Idle Knife.
            actionInput(ref _nameIdleKnife,         // string nameAnim.
                        ref _isIdleKnife,           // bool isAnim.
                        ref _idInputHoldAction,     // int idAnim.
                        ref _weightInputHoldAction, // float weight.
                        ref move);                  // float move.

            // Set Action Attack Knife wiht Hold Idle Knife.
            setAnimationAttacKnife(ref move);
        }
        else if (_changeAction == _isGun)
        {
            // Action Pistol Aims.
            actionInput(ref _namePistolAims,        // string nameAnim.
                        ref _isPistolAims,          // bool isAnim.
                        ref _idInputHoldAction,     // int idAnim.
                        ref _weightInputHoldAction, // float weight.
                        ref move);                  // float move.
        }

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
        if (_mouseLeft == true)
        {
            // Do nothing.
        }
        else
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
    }

    // Turn.
    private void Turn(float inputTurn)
    {
        if (_mouseLeft == true)
        {
            // Do nothing.
        }
        else
        {
            transform.Rotate(_zero, inputTurn * _rotationRate * _speedRotation, _zero);
        }
    }
#endregion

#region If Move & Turn.
    private void ifMoveAndTurn(ref float move,
                               ref float turn)
    {
        if (move > _zero)
        {
            // Set Turn Right & Left.
            _isTurnRight = false;
            _isTurnLeft  = false;

            // Set bool Action.
            _isWalkingBack = false;

            // Set Animation Walk & Run.
            setAniamtionWalkAndRun();
        }
        else if (move < _zero)
        {
            // Set Turn Right & Left.
            _isTurnRight = false;
            _isTurnLeft  = false;

            // Set bool Action.
            _isWalkingBack = true;

            _valueChangeAnimation = _zero;
        }
        else
        {
            // Set Animation Turn Right & Left.
            setAnimationTurnRightAndLeft(ref turn);

            // Set bool Action.
            _isWalkingBack = false;

            // Set Animation Walk & Run.
            _valueChangeAnimation -= _minusWeight;
            if (_valueChangeAnimation <= _zero)
            {
                _valueChangeAnimation = _zero;
            }
        }
    }
#endregion

#region Set Animation.
    // Walking & Runing.
    private void setAniamtionWalkAndRun()
    {
        _valueChangeAnimation += _minusWeight;

        if (_valueChangeAnimation >= _weightMax)
        {
            _valueChangeAnimation = _weightMax;
        }

        if (_isRuning == true)
        {
            if (_valueChangeAnimation >= _weightMax && _minusRun == false)
            {
                _valueChangeAnimation = _weightMax;
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

    // Turn Right & Left.
    private void setAnimationTurnRightAndLeft(ref float turn)
    {
        // Set Turn Right & Left.
        if (turn > 0.0f)
        {
            _isTurnRight = true;
            _isTurnLeft  = false;
            _weightTurnLeft -= _minusWeight;
            if (_weightTurnLeft <= 0.0f)
            {
                _weightTurnLeft = 0.0f;
            }
        }
        else if (turn < 0.0f)
        {
            _isTurnRight = false;
            _isTurnLeft  = true;
            _weightTurnRight -= _minusWeight;
            if (_weightTurnRight <= 0.0f)
            {
                _weightTurnRight = 0.0f;
            }
        }
        else
        {
            _isTurnRight = false;
            _isTurnLeft = false;
        }
    }

    // Attack Knife.
    private void setAnimationAttacKnife(ref float move)
    {
        if ((_changeAction  == _isKnife) &&
            (_isIdleKnife   == true)     &&
            (_isAttackKnife == true))
        {
            _isAttack = true;

            // Action Idle Knife.
            actionAttackKnife(ref _nameAttackKnife,     // string nameAnim.
                              ref _isAttackKnife,       // bool isAnim.
                              ref _isAttack,            // bool isAction.
                              ref _idInputAttackKnife,  // int idAnim.
                              ref _weightAttackKnife,   // float weight.
                              ref _timeAttackKnife,     // float time to Action.
                              ref move);                // float move.
        }
        else
        {
            // Set Weight Attack Knife Minus to Zero.
            _weightAttackKnife -= _minusWeight;
            if (_weightAttackKnife <= _weightMin)
            {
                _weightAttackKnife = _weightMin;
            }

            _anim.SetLayerWeight(_idInputAttackKnife, _weightAttackKnife);

        }
    }
#endregion

#region Set All Action.
    // Action Pistol Aims.
    private void actionInput(ref string nameAnim,  
                                ref bool isAnim,      
                                ref int idAnim,       
                                ref float weight,     
                                ref float move)       
    {
        if (isAnim == true)
        {
            weight += _minusWeight;
            if (weight >= _weightMax)
            {
                weight = _weightMax;

                move = _zero;
            }
        }
        else
        {
            weight -= _minusWeight;
            if (weight <= _weightMin)
            {
                weight = _weightMin;

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
            weight += _minusWeight;
            if (weight >= _weightMax)
            {
                weight = _weightMax;
            }
        }
        else
        {
            weight -= _minusWeight;
            if (weight <= _weightMin)
            {
                weight = _weightMin;
            }
        }
        _anim.SetLayerWeight(idAnim, weight);
        _anim.SetBool(nameAnim, isAnim);
    }

    // Action Turn Right & Left.
    private void actionTurn(ref string nameAnim,
                            ref bool isAnim,
                            ref int idAnim,
                            ref float weight,
                            ref float move)
    {
        if (isAnim == true)
        {
            weight += _minusWeight;
            if (weight >= _weightMax)
            {
                weight = _weightMax;
            }
        }
        else
        {
            weight -= _minusWeight;
            if (weight <= _weightMin)
            {
                weight = _weightMin;
            }
        }
        _anim.SetLayerWeight(idAnim, weight);
        _anim.SetBool(nameAnim, isAnim);
    }

    // Action Attack Knife.
    private void actionAttackKnife(ref string nameAnim,
                                   ref bool isAnim,
                                   ref bool isAction,
                                   ref int idAnim,
                                   ref float weight,
                                   ref float timeMinus,
                                   ref float move)
    {
        if (isAction == true)
        {
            timeMinus -= Time.deltaTime;

            if (timeMinus < _zero)
            {
                // Debug.
                Debug.Log("Time Action <= 0.0f");

                isAnim      = false;
                isAction    = false;
                timeMinus   = _zero;

                //weight = _weightMin;
            }
            else
            {
                // Debug.
                Debug.Log("Time Action > 0.0f");

                weight += _minusWeight;

                if (weight >= _weightMax)
                {
                    weight = _weightMax;
                }
            }
        }

        _anim.SetLayerWeight(idAnim, weight);
        _anim.SetBool(nameAnim, isAnim);
    }
#endregion

    #region Get Target.
    // Target Pistol Aims.
    public bool getTargetIsPistolAims() 
    {
        return _isPistolAims;
    }
    
    // Target Idle Knife.
    public bool getTargetIdleKnife()
    {
        return _isIdleKnife;
    }

#endregion

}

