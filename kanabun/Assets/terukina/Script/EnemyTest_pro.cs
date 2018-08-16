using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest_pro : MonoBehaviour
{
    public Transform Target;
    public float EnemySpeed;
    public Transform escape;

    private Animator anim;
    private GameManager GameManager;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
       // GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


        if (gameObject.transform.childCount == 3)
        {
            
            Invoke("Escape", 2f);
           // print("ok");
           
        } else {

            Move();
            //print("non");
        }
                
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            EnemySpeed = 0;
            anim.SetTrigger("death");
        }

        if(other.gameObject.tag == "Stump")
        {
            transform.GetChild(2).gameObject.transform.position = transform.forward;
            transform.GetChild(2).gameObject.transform.localPosition = new Vector3(0, 5, 5);
        }

        if(other.gameObject.tag == "Escape")
        {
            print("OK");
            PointLoss();
        }
    }

    void Escape()
    {
        anim.SetBool("run", false);
        anim.SetTrigger("have");
        transform.LookAt(escape);
        transform.position += transform.forward * EnemySpeed;
        //print("escape");
    }

    void Move()
    {
        anim.SetBool("run", true);
        transform.LookAt(Target);
        transform.position += transform.forward * EnemySpeed;
    }

    void PointLoss()
    {
            Destroy(gameObject, 1f);
            //GameManager.Addpoint(-10);
    }

}
