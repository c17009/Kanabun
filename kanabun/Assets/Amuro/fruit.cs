using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour {

    public int score;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "xxxx")
        {
            FindObjectOfType<GameManager>().Addpoint(score);

            Destroy(this.gameObject);
        }
    }
}
