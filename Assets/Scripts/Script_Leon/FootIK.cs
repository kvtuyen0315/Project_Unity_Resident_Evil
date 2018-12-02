using UnityEngine;
using System.Collections;

public class FootIK : MonoBehaviour
{
    public LayerMask rayMask;
    public float baseOffset;
    public float alignSpeed = 5.0f;
    public bool automaticFixY = true;
    float lIKh;
	float rIKh;
    float lIKw;
    float rIKw;
	bool lHit;
	bool rHit;
	bool useLIK;
	bool useRIK;
	Vector3 lNrm;
	Vector3 rNrm;

    bool groundHit;
    float groundHeight;
    RaycastHit groundInfo;
    
    bool grounded;
	Animator anim;
	CharacterController controller;

	void Start()
	{
		anim = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
       
	}

	void OnAnimatorIK(int layer)
	{
        GatherGroundInfo();

        if (!groundHit)
            return;

        RayCastLeg(AvatarIKGoal.LeftFoot);
		RayCastLeg(AvatarIKGoal.RightFoot);

		Transform leftHeel = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
		Transform rightHeel = anim.GetBoneTransform(HumanBodyBones.RightFoot);

		if(!lHit) lIKh = leftHeel.position.y;
		if(!rHit) rIKh = rightHeel.position.y;
        
        SetFootPosition(lHit, AvatarIKGoal.LeftFoot, leftHeel.position, lNrm, lIKh, ref lIKw);
        SetFootPosition(rHit, AvatarIKGoal.RightFoot, rightHeel.position, rNrm, rIKh, ref rIKw);
	}

    void LateUpdate()
    {
        if(automaticFixY)
            FixY();
    }

    private void GatherGroundInfo()
    {
        Vector3 cBase = transform.TransformPoint(controller.center) + Vector3.down * (controller.height * 0.5f - controller.radius);
        groundHit = Physics.SphereCast(cBase, controller.radius, Vector3.down, out groundInfo, Mathf.Infinity, rayMask.value);
        groundHeight = cBase.y - groundInfo.distance - controller.radius;
    }
    
	private void RayCastLeg(AvatarIKGoal ag)
	{
		if(ag == AvatarIKGoal.LeftHand || ag == AvatarIKGoal.RightHand) return;
		bool h = false;
        float baseHeight = GetBaseHeight();
        float rayheight = (transform.TransformPoint(controller.center).y - (controller.height * 0.5f - controller.radius)) - baseHeight;
		RaycastHit hit;
		Transform heel = anim.GetBoneTransform(ag == AvatarIKGoal.LeftFoot?HumanBodyBones.LeftFoot:HumanBodyBones.RightFoot);
		Vector3 heelPos = heel.position;
        heelPos.y = groundHeight + rayheight;
		if(Physics.Raycast(heelPos,Vector3.down,out hit, rayheight * 2.0f,rayMask.value))
		{
			h = true;
			if(ag == AvatarIKGoal.LeftFoot)
			{
				lHit = true;
				lIKh = hit.point.y;
				lNrm = hit.normal;
			}
			else
			{
				rHit = true;
                rIKh = hit.point.y;
				rNrm = hit.normal;
			}
		}
		if(!h)
		{
			if(ag == AvatarIKGoal.LeftFoot) lHit = false;
			else rHit = false;
		}
	}

    private void SetFootPosition(bool use, AvatarIKGoal ag, Vector3 heelPos, Vector3 nrm, float IKh, ref float weight)
	{
		if(ag == AvatarIKGoal.LeftHand || ag == AvatarIKGoal.RightHand) return;
        weight += (use ? 1.0f : -1.0f) * Time.deltaTime * alignSpeed;
        weight = Mathf.Clamp01(weight);

		if(use)
		{
            Vector3 rotAxis = Vector3.Cross(Vector3.up, nrm);
            float angle = Vector3.Angle(Vector3.up, nrm);
            Quaternion rot = Quaternion.AngleAxis(angle * weight, rotAxis);
            anim.SetIKRotationWeight(ag, weight);
            anim.SetIKRotation(ag, rot * anim.GetIKRotation(ag));

            float baseHeight = GetBaseHeight();
            float animHeight = (heelPos.y - baseHeight) / (rot * Vector3.up).y;
            Vector3 pos = new Vector3(heelPos.x, Mathf.Max(IKh, baseHeight) + animHeight, heelPos.z);
			anim.SetIKPositionWeight(ag, weight);
			anim.SetIKPosition(ag, pos);
		}
		else
		{
            anim.SetIKPositionWeight(ag, weight);
            anim.SetIKRotationWeight(ag, weight);
        }
	}

    public void FixY()
    {
        if (!groundHit)
            return;

        float min = groundHeight;
        if (lHit && lIKh < min)
            min = lIKh;

        if (rHit && rIKh < min)
            min = rIKh;

        Vector3 pos = transform.position;
        if (GetBaseHeight() <= min)
        {
            pos.y = min - baseOffset;
            transform.position = pos;
            grounded = true;
        }
        else
            grounded = false;
    }

	public bool isGrounded()
	{
		Vector3 tempNRM;
		return isGrounded(out tempNRM);
	}

	public bool isGrounded(out Vector3 nrm)
	{
		nrm = Vector3.up;
        if (!groundHit)
            return false;

        nrm = groundInfo.normal;
        return grounded;
    }

    private float GetBaseHeight()
    {
        return transform.position.y + baseOffset;
    }
}