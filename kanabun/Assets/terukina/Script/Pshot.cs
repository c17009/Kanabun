using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pshot : MonoBehaviour {

    private float BulletPower = 500;
    public GameObject bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
	}

    void Shot()
    {
        var BulletIns = GameObject.Instantiate(bullet,transform.position, Quaternion.identity) as GameObject;
        BulletIns.GetComponent<Rigidbody>().AddForce(BulletIns.transform.forward * BulletPower);
        Destroy(BulletIns, 5f);
    }
}
