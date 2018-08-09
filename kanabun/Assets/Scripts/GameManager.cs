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
    private Text InfoText;
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
    private GameObject CSVReader;


    void Start()
    {
        InfoText = GameObject.Find("InfoText").GetComponent<Text>();
        CSVReader = GameObject.Find("CSVReader");
        StartPanel = GameObject.Find("StartPanel");
        PlayPanel = GameObject.Find("PlayPanel");
        ResultPanel = GameObject.Find("ResultPanel");
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
        ResultPanel.SetActive(false);
        StartPanel.SetActive(true);
        CSVReader.SetActive(false);
        InfoText.text = "これをたおすとスタート\n↓";
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
        InfoText.text = "Ready...";
        StartCoroutine(WaitCount(3f));
        StartPanel.SetActive(false);
        CSVReader.SetActive(true);
        isPlaying = true;
    }

    IEnumerator WaitCount(float time)
    {
        yield return new WaitForSeconds(time);
    }

    private void GoToResult() //time0になるとResultPanelが開く,FinishTriggerを生成
    {
        InfoText.text = "Finish!!";
        CSVReader.SetActive(false);
        isPlaying = false;
        ResultPanel.SetActive(true);
        StartCoroutine(WaitCount(3f));
        Instantiate(FinishObject, new Vector3(0, 0.5f, 7.674f), Quaternion.identity);
    }
 }

