using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest: MonoBehaviour {

    void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {


        //Addpointテスト

        /* if (Input.GetKeyDown("a")) {
            FindObjectOfType<GameManager>().Addpoint(10);
            Destroy(this.gameObject);
            print("OK"); 
            } */

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<GameManager>().Addpoint(10);

            Destroy(this.gameObject);
        }
    }

   
}
