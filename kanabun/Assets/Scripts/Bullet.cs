﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject hand;
    private float bspeed = 100;

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
}