using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    private int  Damege = 0;
    public Transform Player;
    public Transform TargetPoint;
    private float Bossspeed = 0.1f;
    private int RandomPoint;
    private int BossLife = 5;
    private int Roty;


    // Use this for initialization
    void Start () {
        Damege = 0;
        StartCoroutine(Delay());
    }
    
    // Update is called once per frame
    void Update()
    {
        print(BossLife);
        if(Damege <= 29)
        {
            Move();
        }
        else if(Damege >= 30)
        {
            Target();
        }
        
        if(BossLife == 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Damege += 1;
        }
        if(other.gameObject.tag == "MainCamera")
        {
            Destroy(other.gameObject);
        }
    }
    void Move()
    {
        transform.LookAt(Player);
        transform.position += transform.forward * Bossspeed;
    }
    void Target()
    {
        Bossspeed = 0.5f;
        transform.rotation = Quaternion.Euler(0,Roty,0);
        transform.position += transform.forward * Bossspeed;
        Invoke("WaitBoss", 3);
    }
    void WaitBoss()
    {
        Bossspeed = 0.1f;
        Damege = 0;
    }

    IEnumerator Delay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(10);
        }
    }
    void SetRandomPosition()
    {
        int RandomRoty = Random.Range(0, 3);
        if(RandomRoty == 0)
        {
            Roty = -60;
        }
        else if(RandomRoty == 1)
        {
            Roty = 0;
        }
        else if(RandomRoty == 2)
        {
            Roty = 30;
        }
       //Roty = Random.Range(-60, 30);
    }
}
