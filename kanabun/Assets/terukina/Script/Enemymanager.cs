using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymanager : MonoBehaviour {

    public GameObject Boss;
    public GameObject SpawnPoint;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyTest.EnemyDcount == 20)
        {
            foreach(GameObject enemy in enemys)
            {
                Destroy(enemy);
            }

            EnemyTest.EnemyDcount = 0;
            Instantiate(Boss,transform.position, Quaternion.identity);
            SpawnPoint.SetActive(false);
        }
    }
}
