using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    private GameObject StartPanel;
    private GameObject PlayPanel;
    public GameObject StartObject;
    private Text scoretext;
    private Text StartText;
    public int score;
    private Text MainTime;
    [SerializeField]
    private float time;
    private float oldtime;
    private int oldscore;
    [SerializeField]
    private bool isPlaying = false;
    [SerializeField]
    private GameObject CSVReader;


    void Start()
    {
        CSVReader = GameObject.Find("CSVReader");
        StartText = GameObject.Find("StartText").GetComponent<Text>();
        StartPanel = GameObject.Find("StartPanel");
        PlayPanel = GameObject.Find("PlayPanel");
        MainTime = GameObject.Find("timeText").GetComponent<Text>();
        scoretext = GameObject.Find("Score").GetComponent<Text>();
        Initialize();
    }


    void Update()
    {
        if (isPlaying) { Gameplay(); }
    }

    void Initialize()
    {
        score = 0;
        isPlaying = false;
        time = 60;
        PlayPanel.SetActive(false);
        StartPanel.SetActive(true);
        StartText.text = "これをたおすとスタート\n↓";
    }

    public void Addpoint(int point)
    {
        score = score + point;
    }

    private void Gameplay()
    {
            if (Mathf.CeilToInt(time) <= 0f)
            {
                return;
            }

            time -= Time.deltaTime;

            if ((int)oldtime != (int)time)
            {
                MainTime.text = (Mathf.CeilToInt(time)).ToString("00");
            }
            if (oldscore != score)
            {
                scoretext.text = score.ToString();
            }

            oldscore = score;
            oldtime = time;
    }

    public void GoToPlay()
    {
        StartCoroutine(WaitCount());
        StartPanel.SetActive(false);
        CSVReader.SetActive(true);
        isPlaying = true;
    }

    IEnumerator WaitCount()
    {
        StartText.text = "Ready...";
        yield return new WaitForSeconds(3f);
    }
 }

