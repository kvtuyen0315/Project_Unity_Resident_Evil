using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class buttonControl : MonoBehaviour {
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onPlayButtonClick()
    {
        if (GetComponent<Animator>().GetInteger("Choice") != 1)
        {
            GetComponent<Animator>().SetInteger("Choice", 1);
        }
        else
        {
            SceneManager.LoadScene("Save_1", LoadSceneMode.Single);
        }
    }

    public void onOptionButtonClick()
    {
        GetComponent<Animator>().SetInteger("Choice", 2);
    }

    public void onBackButtonClick()
    {
        if (GetComponent<Animator>().GetInteger("Choice") != 3 )
        {
            GetComponent<Animator>().SetInteger("Choice", 3);
        }
        else
        {
            var QuitPanel = GameObject.Find("Main Camera/UI/QuitPanel");
            QuitPanel.SetActive(true);
        }
    }
}
