using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonControl : MonoBehaviour {
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPlayButtonClick()
    {
        GetComponent<Animator>().SetInteger("Choice",1);
    }

    public void onOptionButtonClick()
    {
        GetComponent<Animator>().SetInteger("Choice", 2);
    }

    public void onBackButtonClick()
    {
        GetComponent<Animator>().SetInteger("Choice", 3);
    }
}
