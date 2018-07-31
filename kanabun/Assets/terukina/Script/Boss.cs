using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {
    public int BossLife = 90;
    public Transform Player;
    public Transform TargetPoint;
    private float Bossspeed = 0.1f;
    bool Change = true;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (BossLife <= 60 && BossLife >=50)
        {
            Change = false;
            Target();
        }
        else if (BossLife<= 0)
        {
             Destroy(this.gameObject);
        }
        if(Change == true)
        {
            Move();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            BossLife -= 1;
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
        transform.LookAt(TargetPoint);
        transform.position += transform.forward * Bossspeed;
        if(this.transform.position == TargetPoint.position)
        {
            Change = true;
        }
    }

}
