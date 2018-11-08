using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealth_fromCollider : MonoBehaviour {

    public float Health = 100.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage (float amount)
    {
        Health -= amount;
        if (Health <=0f)
        {
            Die();
        }
    }

    public float GetHealth()
    {
        return Health;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
