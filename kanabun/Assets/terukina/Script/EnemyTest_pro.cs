using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest_pro : MonoBehaviour
{
    public Transform Target;
    public float EnemySpeed;
    public Transform escape;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (gameObject.transform.childCount == 1)
        {
            Invoke("Escape", 2f);
            print("ok");

        } else {

            Move();
            //print("non");
        }
                
    }

    void Escape()
    {
        transform.LookAt(escape);
        transform.position += transform.forward * EnemySpeed;
    }

    void Move()
    {
        transform.LookAt(Target);
        transform.position += transform.forward * EnemySpeed;
    }

}
