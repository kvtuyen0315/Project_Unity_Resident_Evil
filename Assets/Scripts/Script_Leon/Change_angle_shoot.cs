using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_angle_shoot : MonoBehaviour {
    public Transform Pistol;


    Animator anim;
    Transform chest;

    Transform thumb_distal;
    Transform thumb_2;
    Transform thumb_1;
    Transform rightHand;
    Transform rightLowerArm;
    Transform rightUpperArm;
    Transform rightShoulder;
    Transform upperChest;
    Transform spine;
    Transform hips;
    // Use this for initialization

   
    float count =0f;

    Vector3 eulerAngles0_bone;
    Vector3 vec;

    void Start () {
        anim = GetComponent<Animator>();

        thumb_distal= anim.GetBoneTransform(HumanBodyBones.RightThumbDistal);
        thumb_2 = anim.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
        thumb_1 = anim.GetBoneTransform(HumanBodyBones.RightThumbProximal);
        rightHand = anim.GetBoneTransform(HumanBodyBones.RightHand);
        rightLowerArm = anim.GetBoneTransform(HumanBodyBones.RightLowerArm);
        rightUpperArm = anim.GetBoneTransform(HumanBodyBones.RightUpperArm);
        rightShoulder = anim.GetBoneTransform(HumanBodyBones.RightShoulder);
        upperChest= anim.GetBoneTransform(HumanBodyBones.UpperChest);

        chest = anim.GetBoneTransform(HumanBodyBones.Chest);
        spine = anim.GetBoneTransform(HumanBodyBones.Spine);
        hips = anim.GetBoneTransform(HumanBodyBones.Hips);

        eulerAngles0_bone = new Vector3(2.632f, 360f - 7.893001f, 360f - 0.6020001f);


    }

    // Update is called once per frame
    void Update () {
		
	}

    void LateUpdate()
    {
        //-0.09667458 , 0.6243112 , 0.1506499
        //chest.LookAt(target.position);
        //chest.rotation = chest.rotation * Quaternion.Euler(Offset);
        //Vector3 vec= thumb_distal.localRotation.eulerAngles + thumb_1.localRotation.eulerAngles + thumb_2.localRotation.eulerAngles +
        //rightHand.localRotation.eulerAngles + rightLowerArm.localRotation.eulerAngles + rightUpperArm.localRotation.eulerAngles + rightShoulder.localRotation.eulerAngles +
        //upperChest.localRotation.eulerAngles + chest.localRotation.eulerAngles + spine.localRotation.eulerAngles + hips.localRotation.eulerAngles + new Vector3(-0.00932542f, -0.0425112f, 0.0293501f);
        //Pistol.localRotation = Quaternion.Euler(vec);

        //Pistol.localRotation = hips.localRotation;

        //Pistol.localPosition = thumb_distal.localPosition +  thumb_1.localPosition + thumb_2.localPosition + 
        //rightHand.localPosition + rightLowerArm.localPosition + rightUpperArm.localPosition + rightShoulder.localPosition +
        //upperChest.localPosition + chest.localPosition + spine.localPosition + hips.localPosition + new Vector3(-0.00932542f, -0.0425112f, 0.0293501f);

        Pistol.localRotation = Quaternion.Euler(new Vector3(0, -110.95f, 0));  // xoay pistol theo huong cua player
        Pistol.position = thumb_distal.position;  //xet vi tri cua pistol o vi tri tay cam cua player
        //Pistol.localPosition += new Vector3(-0.00932542f, -0.0425112f, 0.0293501f);
       

        if (Input.GetKey(KeyCode.Mouse1) == true)
        {
            
            if (Input.GetKey(KeyCode.W) == true)
            {
                count -= 1;
                if (count <= 0)
                {
                    count = 0;
                }
            }

            if (Input.GetKey(KeyCode.S) == true)
            {
                count += 1;
                if (count >= 37)
                {
                    count = 37;
                }
            }
            //Debug.Log("chest local  :x " + chest.localRotation.eulerAngles.x); vi animation no se thay doi euleranges nen khong dung cach o duoi dc
            chest.localRotation = Quaternion.Euler(new Vector3(Mathf.Clamp(count, eulerAngles0_bone.x, 37), 0, 0) + eulerAngles0_bone);
            Pistol.position = thumb_distal.position;
            Pistol.localRotation = Quaternion.Euler(new Vector3(0, -110.95f, -Mathf.Clamp(count , 0, 37)));


            //Debug.Log("chest local sau :x " + chest.localRotation.eulerAngles.x);
            //float angle_x = -Input.GetAxis("Vertical");
            //chest.localRotation = Quaternion.Euler(new Vector3(Mathf.Clamp(chest.localRotation.eulerAngles.x + angle_x, eulerAngles0_bone.x, 100), eulerAngles0_bone.y, eulerAngles0_bone.z));

        }
    }
}
