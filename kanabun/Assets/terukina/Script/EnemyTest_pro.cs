using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest_pro : MonoBehaviour
{
    public Transform Target;
    public float EnemySpeed;
    public static int EnemyDcount;

    public fruitbasket fb;
    

    // Use this for initialization
    void Start()
    {
       //List<GameObject> fruit = fb.fruit;
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.LookAt(Target);
        transform.position += transform.forward * EnemySpeed;*/
    }


    private void OnTriggerEnter(Collider other)
    {
        //切り株に触れたら、フルーツの親になる
        //for (int i = fb.fruit.Count; 0 < i; i--)
        //{

            if (other.gameObject.tag == "Stump")
            {
                GameObject Fruit = GameObject.FindWithTag("Fruit");
                Fruit.transform.parent = transform;
                Fruit.transform.position = transform.position;
                Fruit.transform.position += new Vector3(0, 1, 0);
                fb.fruit.RemoveAt(-1);
                print("OK");
            }
       // }

        if (other.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            EnemyDcount += 1;
        }
    }
}
