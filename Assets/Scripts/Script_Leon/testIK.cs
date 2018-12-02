using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testIK : MonoBehaviour {

    public Transform test;
    //public Transform target;
    //Animator anim;
    //Transform leftfoot;
    //Transform rightfoot;

    Ray shootRay_rightfoot;
    RaycastHit shootHit_rightfoot;
    // Use this for initialization


    void Start () {
        //anim = GetComponent<Animator>();
        //leftfoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        //rightfoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

        //Quaternion t = Quaternion.FromToRotation(transform.up, transform.) * transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnAnimatorIK()
    {
        //anim.SetIKPosition(AvatarIKGoal.RightFoot, target.position);
        //anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
    }
    private void LateUpdate()
    {
        //shootRay_rightfoot.origin = rightfoot.position;
        //shootRay_rightfoot.direction = -rightfoot.forward;
       
    }
}
