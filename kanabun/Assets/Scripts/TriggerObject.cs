using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {
    private GameManager GameManager;
	// Use this for initialization
	void Start () {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "ground" && gameObject.name == "StartTrigger")
        {
            GameManager.GoToPlay();
            Destroy(transform.root.gameObject, 2f);
        }
        if(collider.gameObject.tag == "ground" && gameObject.name =="FinishTrigger")
        {
            GameManager.WaitFinish();
            Destroy(transform.root.gameObject, 1f);
        }
    }

}
