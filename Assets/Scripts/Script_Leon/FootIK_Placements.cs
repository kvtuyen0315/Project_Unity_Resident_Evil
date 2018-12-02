using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootIK_Placements : MonoBehaviour {

   
    public LayerMask rayMask;
    public Transform cube;
    Animator anim;
    Transform leftfoot;
    Transform rightfoot;

    Ray shootRay_rightfoot;
    RaycastHit shootHit_rightfoot;
    Ray shootRay_leftfoot;
    RaycastHit shootHit_leftfoot;

    float weight_RightfootIK;
    float weight_LeftfootIK;
    public float feetOffet;
    Vector3 rightFoot_IKpos;
    Vector3 leftFoot_IKpos;
    Quaternion rightFoot_IKrot;
    Quaternion leftFoot_IKrot;



    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        leftfoot=anim.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightfoot= anim.GetBoneTransform(HumanBodyBones.RightFoot);

        //rightFoot_IKpos = rightfoot.position;
        //rightFoot_IKrot = rightfoot.rotation;
        //leftFoot_IKrot = leftfoot.rotation;
    }
    
    
    // Update is called once per frame
    void Update () {

        //rightFoot_IKpos = rightfoot.TransformPoint(Vector3.zero);
        //leftFoot_IKpos = leftfoot.TransformPoint(Vector3.zero);

        //shootRay_rightfoot.origin = rightfoot.position;
        //shootRay_rightfoot.direction = Vector3.down;
        //shootRay_leftfoot.origin = leftfoot.position;
        //shootRay_leftfoot.direction = Vector3.down;
        //if (Physics.Raycast(shootRay_rightfoot, out shootHit_rightfoot))
        //{

        //    if (shootHit_rightfoot.collider.tag == "Stair")
        //    {


        //        Debug.DrawLine(rightfoot.position, shootHit_rightfoot.point,Color.red);
        //        rightFoot_IKpos = shootHit_rightfoot.point + feetOffet * Vector3.up;

        //        rightFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * transform.rotation;
        //        //anim.SetIKPosition(AvatarIKGoal.RightFoot, shootHit_rightfoot.point + feetOffet * Vector3.up);
        //        //anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

        //        //anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * transform.rotation);
        //        //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

        //        //Debug.Log("Shoothit rfnormal" + shootHit_rightfoot.normal);

        //        //Quaternion test = Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * gameobj.rotation;
        //        ////test= Quaternion.Euler(new Vector3(test.eulerAngles.x, test.eulerAngles.y, test.eulerAngles.z) + transform.eulerAngles);
        //        //anim.SetIKRotation(AvatarIKGoal.RightFoot, gameobj.rotation);
        //    }

        //}

        //shootRay_leftfoot.origin = leftfoot.position;
        //shootRay_leftfoot.direction = Vector3.down;

        //if (Physics.Raycast(shootRay_leftfoot, out shootHit_leftfoot))
        //{
        //    if (shootHit_leftfoot.collider.tag == "Stair")
        //    {
        //        leftFoot_IKpos = shootHit_leftfoot.point + feetOffet * Vector3.up;
        //        leftFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_leftfoot.normal) * transform.rotation;
        //        Debug.DrawLine(leftfoot.position, shootHit_leftfoot.point, Color.red);

        //        //anim.SetIKPosition(AvatarIKGoal.LeftFoot, shootHit_leftfoot.point + feetOffet * Vector3.up);
        //        //anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);

        //        //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.FromToRotation(transform.up, shootHit_leftfoot.normal) * transform.rotation);
        //        //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);



        //        //point_hit_lf = shootHit_leftfoot.point;
        //        //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0)));
        //        //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        //        //leftfoot.localRotation = Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0));



        //    }
        //}

    }
    void OnAnimatorIK()
    {
        //weight_RightfootIK = anim.GetFloat("RightFootIK");
        //weight_LeftfootIK = anim.GetFloat("LeftFootIK");

        //anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot_IKpos);
        //anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

        //anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot_IKrot);
        //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

        //anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot_IKpos);
        //anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);

        //anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot_IKrot);
        //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);
       
        //Debug.Log("rightfoot o onAnim " + rightfoot.position);

        weight_RightfootIK = anim.GetFloat("RightFootIK");
        weight_LeftfootIK = anim.GetFloat("LeftFootIK");
        shootRay_rightfoot.origin = rightfoot.position;
        shootRay_rightfoot.direction = Vector3.down;

        if (Physics.Raycast(shootRay_rightfoot, out shootHit_rightfoot))
        {

            if (shootHit_rightfoot.collider.tag == "Stair")
            {

                Debug.DrawLine(rightfoot.position, shootHit_rightfoot.point, Color.red);
                anim.SetIKPosition(AvatarIKGoal.RightFoot, shootHit_rightfoot.point + feetOffet * Vector3.up);
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

                anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * transform.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

                //rightFoot_IKpos = shootHit_rightfoot.point + feetOffet * Vector3.up;

                //rightFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * transform.rotation;
                //anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot_IKpos);
                //anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

                //anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot_IKrot);
                //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, weight_RightfootIK);

                //Quaternion test = Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * gameobj.rotation;
                ////test= Quaternion.Euler(new Vector3(test.eulerAngles.x, test.eulerAngles.y, test.eulerAngles.z) + transform.eulerAngles);
                //anim.SetIKRotation(AvatarIKGoal.RightFoot, gameobj.rotation);
            }
            //else
            //{
            //    rightFoot_IKpos = shootHit_rightfoot.point + feetOffet * Vector3.up;

            //    rightFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_rightfoot.normal) * transform.rotation;
            //}

        }

        shootRay_leftfoot.origin = leftfoot.position;
        shootRay_leftfoot.direction = Vector3.down;

        if (Physics.Raycast(shootRay_leftfoot, out shootHit_leftfoot))
        {
            if (shootHit_leftfoot.collider.tag == "Stair")
            {

                Debug.DrawLine(leftfoot.position, shootHit_leftfoot.point, Color.red);

                anim.SetIKPosition(AvatarIKGoal.LeftFoot, shootHit_leftfoot.point + feetOffet * Vector3.up);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);

                anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.FromToRotation(transform.up, shootHit_leftfoot.normal) * transform.rotation);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);

                //leftFoot_IKpos = shootHit_leftfoot.point + feetOffet * Vector3.up;
                //leftFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_leftfoot.normal) * transform.rotation;

                //anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot_IKpos);
                //anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);

                //anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot_IKrot);
                //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, weight_LeftfootIK);
                //point_hit_lf = shootHit_leftfoot.point;
                //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0)));
                //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                //leftfoot.localRotation = Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0));



            }
            //else
            //{
            //    leftFoot_IKpos = shootHit_leftfoot.point + feetOffet * Vector3.up;
            //    leftFoot_IKrot = Quaternion.FromToRotation(transform.up, shootHit_leftfoot.normal) * transform.rotation;
            //}
        }


    }


    void LateUpdate()
    {
        //shootRay_rightfoot.origin = rightfoot.position;
        ////shootRay_rightfoot.direction = -rightfoot.forward;
        //shootRay_rightfoot.direction = Vector3.down;

        //if (Physics.Raycast(shootRay_rightfoot, out shootHit_rightfoot))
        //{
        //    if (shootHit_rightfoot.collider.tag == "Stair")
        //    {

        //        is_footIK_rf = true;
        //        Debug.Log("da vao stair phai");
        //        //Gizmos.DrawLine(rightfoot.position, shootHit_rightfoot.point);

        //        //rightfoot.position = shootHit_rightfoot.point;
        //        Debug.DrawLine(rightfoot.position, shootHit_rightfoot.point);
        //        //point_hit_rf = shootHit_rightfoot.point;

        //        //anim.SetIKPosition(AvatarIKGoal.RightFoot, shootHit_rightfoot.point);
        //        //anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);

        //        //anim.SetIKRotation(AvatarIKGoal.RightFoot, Quaternion.Euler(rightfoot.localRotation.eulerAngles + new Vector3(shootHit_rightfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0)));
        //        //anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
        //        //rightfoot.localRotation = Quaternion.Euler(rightfoot.localRotation.eulerAngles + new Vector3(shootHit_rightfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0));

        //    }
        //}
        //else
        //{
        //    is_footIK_rf = false;
        //}

        //shootRay_leftfoot.origin = leftfoot.position;
        ////shootRay_leftfoot.direction = -leftfoot.forward;
        //shootRay_leftfoot.direction = Vector3.down;

        //if (Physics.Raycast(shootRay_leftfoot, out shootHit_leftfoot))
        //{
        //    if (shootHit_leftfoot.collider.tag == "Stair")
        //    {
        //        is_footIK_lf = true;
        //        Debug.DrawLine(leftfoot.position, shootHit_leftfoot.point);

        //        //Gizmos.DrawLine(leftfoot.position, shootHit_leftfoot.point);

        //        //leftfoot.position = shootHit_leftfoot.point;

        //        //anim.SetIKPosition(AvatarIKGoal.LeftFoot, shootHit_leftfoot.point);
        //        //anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);

        //        //point_hit_lf = shootHit_leftfoot.point;

        //        //anim.SetIKRotation(AvatarIKGoal.LeftFoot, Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0)));
        //        //anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
        //        //leftfoot.localRotation = Quaternion.Euler(leftfoot.localRotation.eulerAngles + new Vector3(shootHit_leftfoot.collider.gameObject.transform.rotation.eulerAngles.x, 0, 0));



        //    }
        //}
        //else
        //{
        //    is_footIK_lf = false;
        //}
    }
 
   
   
}
