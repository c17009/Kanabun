using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCamera : MonoBehaviour {
    [SerializeField]
    GameObject mainCam;

    Transform Cam;
    Vector3 v = Vector3.zero;
    Vector3 r = Vector3.zero;
	// Use this for initialization
	void Start () {
        Cam = mainCam.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        v = transform.position;

        v.x = Cam.position.x + 10000;
        v.y = Cam.position.y;
        v.z = Cam.position.z + 10000;
        transform.position = v;

        transform.rotation = Cam.transform.rotation;

	}
}
