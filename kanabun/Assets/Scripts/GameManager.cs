using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    private int Stage;
    private float Score;
    Text frame;
	// Use this for initialization
	void Start () {
        frame = GameObject.Find("Frame").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        frame.text = (1f / Time.deltaTime).ToString();
	}
}
