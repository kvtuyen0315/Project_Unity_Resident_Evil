using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_angle_shoot : MonoBehaviour {

    Animator anim;
    Transform chest;
    // Use this for initialization

   
    float count =0f;

    Vector3 eulerAngles0_bone;
    Vector3 vec;

    void Start () {
        anim = GetComponent<Animator>();
        chest = anim.GetBoneTransform(HumanBodyBones.Chest);
         eulerAngles0_bone = chest.localRotation.eulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        //chest.LookAt(Target.position);
        //chest.rotation = chest.rotation * Quaternion.Euler(Offset);
        //Debug.Log("Goc quay Y;" + transform.rotation.eulerAngles.y);


        if (Input.GetKey(KeyCode.Mouse1) == true)
        {
            //if (Input.GetKey(KeyCode.W) == true)
            //{
            //    count -= 1;
            //    if (count <= 0)
            //    {
            //        count = 0;
            //    }
            //}

            //if (Input.GetKey(KeyCode.S) == true)
            //{
            //    count += 1;
            //    if (count >= 37)
            //    {
            //        count = 37;
            //    }
            //}
            //chest.localRotation = Quaternion.Euler(new Vector3(Mathf.Clamp(count, 0, 37), 0, 0) + eulerAngles0_bone);

            if (Input.GetKey(KeyCode.W) == true || Input.GetKey(KeyCode.S) == true)
            {
                float angle_x = -Input.GetAxis("Vertical");
                vec = Vector3.right * angle_x;
                chest.localRotation = Quaternion.Euler(new Vector3(Mathf.Clamp(chest.localRotation.eulerAngles.x + vec.x, eulerAngles0_bone.x, 35), eulerAngles0_bone.y, eulerAngles0_bone.z));
            }
            

        }
    }
}
