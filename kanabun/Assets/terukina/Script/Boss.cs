using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public int BossLife = 60;
    public Transform Player;
    private float Bossspeed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);
        transform.position += transform.forward * Bossspeed;
		if(BossLife == 0)
        {
            Destroy(this.gameObject);
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            BossLife -= 1;
        }
        if(other.gameObject.tag == "MainCamera")
        {
            Destroy(other.gameObject);

        }
    }

}
