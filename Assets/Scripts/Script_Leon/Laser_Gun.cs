﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Gun : MonoBehaviour {

  
    public float range = 100.0f;
    public float damage_Shooting = 10f;
    Ray shootRay;
    RaycastHit shootHit;
    LineRenderer Laser_gunLine;

    public GameObject Effect_Impact;
    bool _isPlay_effect = false;

    Animator ani;

    void Awake()
    {
        //shootabkeMask = LayerMask.GetMask("Shootable");
        Laser_gunLine = GetComponent<LineRenderer>();
        Laser_gunLine.enabled = false;
    }

    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Mouse1)==true)
        {
            Shoot();
            
        }
        else
        {
            Laser_gunLine.enabled = false;
        }

      
      
    }

    void Shoot()
    {
        Laser_gunLine.enabled = true;
        Laser_gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        Laser_gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);

       
        if (Input.GetKey(KeyCode.Mouse0) == true)
        {
            
            if (Physics.Raycast(shootRay, out shootHit))
            {
                if (_isPlay_effect == false)
                {
                    ChangeHealth_fromCollider target = shootHit.transform.GetComponent<ChangeHealth_fromCollider>();
                    if (target != null)
                    {
                        Debug.Log(shootHit.transform.name);
                        Debug.Log("mau con lai :" + target.GetHealth());

                        target.TakeDamage(damage_Shooting);
                    }
                    var obj = Instantiate(Effect_Impact, shootHit.point, Quaternion.LookRotation(shootHit.normal));
                    obj.GetComponent<ParticleSystem>().Play();
                    _isPlay_effect = true;

                }
            }

        }
        else
        {
            _isPlay_effect = false;
        }

    }
}
