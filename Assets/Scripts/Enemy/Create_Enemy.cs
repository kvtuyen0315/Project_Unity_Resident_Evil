using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_Enemy : MonoBehaviour {

    public GameObject Enemy;
   
    public Transform player;
	// Use this for initialization
	void Start () {
        Invoke("CreateEnemy", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateEnemy()
    {
        // phải kéo target player vào để ở dưới instantiate bị null do, chỉ có component từ tự nó tạo ra (này la navmeshagent) rồi kéo vào target không bị null
        Enemy.GetComponent<FollowPlayer>().player = player;
        
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
