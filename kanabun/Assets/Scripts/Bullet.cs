using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameManager GameManager;//Script宣言

    public Animator anim;

	// Use this for initialization
	void Start () {
       // GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(this.gameObject, 10f);
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
            // GameManager.Addpoint(10);
            anim.SetTrigger("death");
            Destroy(other.gameObject, 2.5f);
            Destroy(gameObject);
        }
    }

}
