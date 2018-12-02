using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Move : MonoBehaviour {

    public float speed;
    public float fireRate;
    public GameObject Effect_BulletMuzzle;
    public GameObject Effect_BulletHit;
    // Use this for initialization
    void Start () {
        if (Effect_BulletMuzzle!=null)
        {
            var BulletMuzzle = Instantiate(Effect_BulletMuzzle, transform.position, transform.rotation);
            var PS_BulletMuzzle = BulletMuzzle.GetComponent<ParticleSystem>();
            if (PS_BulletMuzzle!=null)
            {
                Destroy(BulletMuzzle, PS_BulletMuzzle.main.duration);

            }
            else
            {
                var PS_child = BulletMuzzle.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(BulletMuzzle, PS_child.main.duration);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No speed effect_gunshot");
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint pointContact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, pointContact.normal);
        Vector3 pos = pointContact.point;
        if (Effect_BulletHit!=null)
        {
            var Bullet_Hit = Instantiate(Effect_BulletHit, pos, rot);
            var PS_BulletHit = Bullet_Hit.GetComponent<ParticleSystem>();
            if (PS_BulletHit != null)
            {
                Destroy(Bullet_Hit, PS_BulletHit.main.duration);

            }
            else
            {
                var PS_child = Bullet_Hit.transform.GetChild(0).GetComponent<ParticleSystem>();
                Destroy(Bullet_Hit, PS_child.main.duration);
            }

        }
        Destroy(gameObject);

    }
}
