using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest_pro : MonoBehaviour
{
    public Transform Target;
    public float EnemySpeed;
  

    // Use this for initialization
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.LookAt(Target);
        transform.position += transform.forward * EnemySpeed;*/
        
    }


    /*private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            EnemyDcount += 1;
        }
    }*/
}
