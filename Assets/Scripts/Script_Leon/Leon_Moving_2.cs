using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leon_Moving_2 : MonoBehaviour {
    #region All Variable 
    private Rigidbody _rb;
    //Animator
    private Animator _anim;

    private float _speed = 0.0f;
    private float _speed_Walking = 0.5f;
    private float _speed_Running = 1.0f;
    private float _speed_WalkinngBack = -0.5f;

    //private bool _is_Running ;
    //All varible press on keyboard
    private bool _is_Pressing_LeftShift;
    private bool _is_Pressing_W;
    private bool _is_Pressing_MouseLeft=false;
    private bool _is_Pressing_MouseRight = false;

    //private bool _is_Lastest_Run;
    private bool _is_MaxSpeed = false;
    
    #endregion
    // Use this for initialization
    void Start () {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        

    }
	
	// Update is called once per frame
	void Update () {
        if (_speed>0)
        {
            //Debug.Log("speed :" + _speed);

        }
        
        Update_ALLAnimation();
        MoveAndTurn();
    }
    void MoveAndTurn()
    {
        //Debug.Log("_is_Pressing_MouseRight :" + _is_Pressing_MouseRight);

        if (_is_Pressing_MouseRight==false)
        {
            if (Input.GetKey(KeyCode.LeftShift) == true)
            {
                _rb.AddForce(transform.forward * _speed * _speed_Running, ForceMode.VelocityChange);
            }
            else
            {
                _rb.AddForce(transform.forward * _speed * _speed_Walking, ForceMode.VelocityChange);
            }
        }
       
        Turn();

    }
    void Turn()
    {
        if (_speed>0)
        {
            transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);
            
        }
        else if (_speed <0)
        {
            transform.Rotate(0.0f, -Input.GetAxis("Horizontal"), 0.0f);

        }

    }

    //Update All animation
    void Update_ALLAnimation()
    {
        UpdateAnim_Movement();
        UpdateAnim_TurnAtStdanding();
        UpdateAnim_Attack();
    }
  
    void UpdateAnim_Movement()
    {
        #region solution1 for move run
        //_is_Running = Input.GetKey(KeyCode.LeftShift);
        //if (_is_Running == false)
        //{

        //    if (_is_Lastest_Run == false)
        //    {
        //        _speed = Input.GetAxis("Vertical");
        //        if (_speed > 0.5f)
        //        {
        //            _speed = 0.5f;
        //        }
        //    }
        //    if (_is_Lastest_Run == true)
        //    {
        //        _speed -= Time.deltaTime * 3;
        //        if (_speed <= 0.5f)
        //        {

        //            _is_Lastest_Run = false;
        //        }
        //    }

        //}
        //else
        //{

        //    if (_speed >= 0.5f)
        //    {
        //        if (Input.GetKey(KeyCode.W) == true)
        //        {
        //            _is_Lastest_Run = true;
        //            _speed += Time.deltaTime * 3;
        //            if (_speed >= 1.0f)
        //            {
        //                _speed = 1.0f;
        //            }
        //        }
        //        else
        //        {
        //            _speed -= Time.deltaTime * 3;
        //            if (_speed <= 0)
        //            {
        //                _speed = 0;
        //            }
        //        }

        //    }
        //    else if (_speed < 0.5f)
        //    {
        //        _speed = Input.GetAxis("Vertical");

        //    }


        //}
        #endregion

        //Debug.Log("press W :" + Input.GetKey(KeyCode.W));
        if (Input.GetKey(KeyCode.W) == true)
        {
            if (_is_MaxSpeed == false)
            {
                _speed += Time.deltaTime * 3;
                if (Input.GetKey(KeyCode.LeftShift) == false)
                {
                    if (_speed >= _speed_Walking)
                    {
                        if (_speed >= _speed_Running)
                        {
                            _is_MaxSpeed = true;
                        }
                        else
                        {
                            _speed = _speed_Walking;

                        }
                    }

                }
                else
                {
                    if (_speed >= 1.0f)
                    {
                        _speed = 1.0f;
                    }
                }
            }
            else
            {
                _speed -= Time.deltaTime * 3;
                if (_speed <= _speed_Walking)
                {
                    _speed = _speed_Walking;
                    _is_MaxSpeed = false;
                }
            }

            _anim.SetBool("Is_Turn_Left", false);
            _anim.SetBool("Is_Turn_Right", false);

        }
        else if (Input.GetKey(KeyCode.S) == true)
        {
            _speed -= Time.deltaTime * 3;
            if (_speed <= _speed_WalkinngBack)
            {
                _speed = _speed_WalkinngBack;
            }

            _anim.SetBool("Is_Turn_Left", false);
            _anim.SetBool("Is_Turn_Right", false);
        }
        else
        {
            _speed -= Time.deltaTime * 3;
            if (_speed <= 0)
            {
                _speed = 0;
            }
        }
        _anim.SetFloat("Speed", _speed);

    }


    void UpdateAnim_TurnAtStdanding()
    {
        if (_speed == 0.0f)
        {

            if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);

                //Debug.Log("Hor > 0 " + Input.GetAxis("Horizontal"));
                _anim.SetBool("Is_Turn_Right", true);

                _anim.SetBool("Is_Turn_Left", false);

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                //Debug.Log("Hor < 0 " + Input.GetAxis("Horizontal"));
                transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);

                _anim.SetBool("Is_Turn_Left", true);
                _anim.SetBool("Is_Turn_Right", false);

            }
            else
            {
                _anim.SetBool("Is_Turn_Left", false);
                _anim.SetBool("Is_Turn_Right", false);
            }
        }
    }

    void UpdateAnim_Attack()
    {
        _is_Pressing_MouseLeft= Input.GetKey(KeyCode.Mouse0);
        _is_Pressing_MouseRight = Input.GetKey(KeyCode.Mouse1);

        _anim.SetBool("Is_Idle_Pistol", _is_Pressing_MouseRight);

        if (_is_Pressing_MouseRight==true)
        {
            //_anim.SetLayerWeight(1, 1);
            //_anim.SetLayerWeight(2, 0);
            _anim.SetBool("Is_Attack_Pistol", _is_Pressing_MouseLeft);
        }
        else
        {
        }
    }
}
