using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePistol : MonoBehaviour {

    public GameObject Pistol;
    public float delaytime_active = 0.3f;
    float _countTime=0.0f;

	// Use this for initialization
	void Start () {
        //transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 1));
        //Debug.Log("kich thuoc laser" + sung.GetComponent<Renderer>().bounds.size);
    }
    
    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.Mouse1) == true)
        {
            _countTime += Time.deltaTime;
            if (_countTime>=delaytime_active)
            {
                Pistol.SetActive(true);
                
            }
        }
        else
        {
            _countTime = 0.0f;
            Pistol.SetActive(false);

        }
    }
}
