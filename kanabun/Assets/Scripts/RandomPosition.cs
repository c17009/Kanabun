﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(RePositionWithDelay());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RePositionWithDelay()
    {
        while (true)
        {
            SetRandomPositon();
            yield return new WaitForSeconds(5);
        }
    }

    public void SetRandomPositon()
    {
        float x = Random.Range(-5.0f,5.0f);
        float z = Random.Range(-5.0f,5.0f);
        Debug.Log("x,z: " + x.ToString("F2") + ", " + z.ToString("F2"));
        transform.position = new Vector3(x, 0.0f, z);
    }
}
