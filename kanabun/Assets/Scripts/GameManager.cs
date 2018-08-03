using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoretext;
    public int score;
    
    // Use this for initialization
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = score.ToString();
    }

    void Initialize()
    {
        score = 0;
    }

    public void Addpoint(int point)
    {
        score = score + point;
    }

    /*public void aaaa()
    {
        FindObjectOfType<Score>().Addpoint(score);
    }*/
}
