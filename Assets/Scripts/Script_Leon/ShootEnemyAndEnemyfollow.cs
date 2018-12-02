using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemyAndEnemyfollow : MonoBehaviour {

    public GameObject Enemy;
    public Animator Enemy_Anim;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Enemy.transform.Translate((transform.position - Enemy.transform.position)*0.05f);
        //Enemy_Anim.SetFloat("vertical", 0.5f);
        Enemy.transform.rotation = Quaternion.LookRotation(transform.position - Enemy.transform.position);
    }
}
