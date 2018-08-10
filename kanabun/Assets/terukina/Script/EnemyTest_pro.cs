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
        transform.LookAt(Target);
        transform.position += transform.forward * EnemySpeed;

        if(GameObject.Find ("Child").transform.IsChildOf(transform))
        {
            Invoke("Escape", 2f);
            print("ok");
        }
        
    }

    void Escape()
    {
        transform.LookAt(escape);
        transform.position += transform.forward * EnemySpeed;
    }
 
}
