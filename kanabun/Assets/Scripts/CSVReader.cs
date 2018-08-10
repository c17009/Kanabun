using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CSVReader : MonoBehaviour {
    public GameObject[] Enemies;
    private float[] _timing;
    private int[] _posNum;
    private int[] _enemyNum;
    private int _enemiesCount;
    public string filePass;
    private Vector3[] spawnPos = {new Vector3(-4,1.5f,10),new Vector3(-2,1.5f,10),new Vector3(0,1.5f,10),
                                  new Vector3 (2,1.5f,10),new Vector3 (4,1.5f,10)};

    private float _startTime = 0;

    public float timeOffset = -1;

    private bool _isPlaying = false;
	// Use this for initialization
	void Start () {
        _timing = new float[1024];
        _posNum = new int[1024];
        _enemyNum = new int[1024];
        _startTime = Time.time;
        LoadCSV();
	}
	
	// Update is called once per frame
	void Update () {
        CheckNextNotes();
    }

    void LoadCSV()
    {
        int i = 0, j;
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _posNum[i] = int.Parse(values[1]);
                _enemyNum[i] = int.Parse(values[2]);
            }
            i++;
        }
    }

    void CheckNextNotes()
    {
        while (_timing[_enemiesCount] + timeOffset < GetGameTime() && _timing[_enemiesCount] != 0)
        {
            SpawnEnemy(_posNum[_enemiesCount],_enemyNum[_enemiesCount]);
            _enemiesCount++;
        }
    }

    void SpawnEnemy(int posNum,int enemyNum)
    {
        Instantiate(Enemies[enemyNum], spawnPos[posNum], Quaternion.identity);
    }

    float GetGameTime()
    {
        return Time.time - _startTime;
    }
}
