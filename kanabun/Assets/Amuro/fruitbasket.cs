using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruitbasket : MonoBehaviour {
    public List<GameObject> fruit = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(fruit.Count);
	}

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Enemy" && 0 < fruit.Count )
            {                
                //GameObject Enemy = GameObject.FindWithTag("Enemy");
                fruit[0].transform.parent = other.transform;
                fruit[0].transform.position = other.transform.position;
                fruit[0].transform.position += new Vector3(0, 1, 0);
                fruit.RemoveAt(0);
            }
    }
}
