using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject Enemy;
    private int spawncount;
    public int IntervalCount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawncount += 1;
        if (spawncount % IntervalCount == 0)
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
