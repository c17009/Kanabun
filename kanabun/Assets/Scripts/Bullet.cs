using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private GameObject Gamemanager;
    private GameManager GameManager;//Script宣言
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

        StartCoroutine(Wait(10f));
        Destroy(gameObject);
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
            StartCoroutine(Wait(2f));
            GameManager.GoToPlay();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "FinishTrigger")
        {
            StartCoroutine(Wait(2f));
            GameManager.GameFinish();
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
