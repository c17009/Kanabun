using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float BulletSpeed = 100;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(transform.position.y <= -50)
        {
            Destroy(gameObject);
        }
        //transform.Translate(0, 0, 1 * bspeed);
        //transform.position += transform.forward * bspeed * Time.deltaTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
