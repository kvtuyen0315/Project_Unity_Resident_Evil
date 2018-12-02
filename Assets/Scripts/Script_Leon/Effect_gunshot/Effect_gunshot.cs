using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_gunshot : MonoBehaviour {

    public GameObject firepoint;
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectTospwan;
    float timeTofire = 0f;

    // Use this for initialization
    void Start () {
        effectTospwan = vfx[0];

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)==true && Time.time >=timeTofire )
        {
            timeTofire = Time.time + 1 / effectTospwan.GetComponent<Effect_Move>().fireRate;
            Spawnvfx();
        }
	}
    void Spawnvfx()
    {
        GameObject vfx;
        if (firepoint != null)
        {
            vfx = Instantiate(effectTospwan, firepoint.transform.position, firepoint.transform.rotation);
        }
        else
        {
            Debug.Log("no fire point ");
        }
    }
}
