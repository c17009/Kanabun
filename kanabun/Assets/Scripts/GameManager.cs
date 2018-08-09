using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    private GameObject StartPanel;
    private GameObject ResultPanel;
    private GameObject PlayPanel;
    public GameObject StartObject;
    public GameObject FinishObject;
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
    private bool isFinish = false;
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
        if (isFinish) { GameFinish(); }
    }

    void Initialize()
    {
        score = 0;
        isPlaying = false;
        isFinish = false;
        time = 60;
        PlayPanel.SetActive(false);
        StartPanel.SetActive(true);
        CSVReader.SetActive(false);
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

    public void GameFinish()
    {
        Instantiate(StartObject, new Vector3(0, 0.5f, 7.674f), Quaternion.identity);
        Initialize();
    }

    public void GoToPlay()
    {
        StartCoroutine(WaitCount("Ready..."));
        StartPanel.SetActive(false);
        CSVReader.SetActive(true);
        isPlaying = true;
    }

    IEnumerator WaitCount(string str)
    {
        StartText.text = str;
        yield return new WaitForSeconds(3f);
    }

    private void GoToResult() //time0になるとResultPanelが開く,FinishTriggerを生成
    {
        CSVReader.SetActive(false);
        isPlaying = false;
        StartCoroutine(WaitCount("Finish!!"));
        ResultPanel.SetActive(true);
        Instantiate(FinishObject, new Vector3(0, 0.5f, 7.674f), Quaternion.identity);
    }
 }

