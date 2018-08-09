using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private float BulletSpeed = 100;
    [SerializeField]
    private GameObject Gamemanager;
    private GameManager GameManager;
	// Use this for initialization
	void Start () {
        GameManager = Gamemanager.GetComponent<GameManager>();
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "StartTrigger")
        {
            GameManager.GoToPlay();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator BreakWait()
    {
        yield return new WaitForSeconds(2f);
    }
}
