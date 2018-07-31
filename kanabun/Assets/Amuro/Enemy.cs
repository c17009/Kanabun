using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<Score>().Addpoint(10);

            Destroy(this.gameObject);
        }
    }
}
