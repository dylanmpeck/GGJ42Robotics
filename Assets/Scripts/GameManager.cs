using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WebSocketSharp;

public class GameManager : MonoBehaviour
{
    static public float percentComplete = 0.15f;
    static public float moveSpeed = 0f;
    static public float repairMultiplier = -0.01f;

    public static bool begin;
    public static bool lose;
    public static bool win;

    public Text heartPercentText;
    public Text winText;
    public Text loseText;

    public AudioSource winSound;

    public string urlToRefresh;
    WebSocket ws;

    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0f;
        begin = true;
        win = false;
        lose = false;
        percentComplete = .15f;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Mathf.Clamp(moveSpeed, 0.0f, 20f);

        if (!Mathf.Approximately(moveSpeed, 0))
            begin = false;
        
        if (Mathf.Approximately(percentComplete, 0.0f) && !lose)
        {
            lose = true;
            StartCoroutine(LoseGame());
        }

        if (Mathf.Approximately(percentComplete, 1.0f) && !win)
        {
            win = true;
            StartCoroutine(WinGame());
        }

        if (timer >= 3.3f)
        {
            timer = 0.0f;
            percentComplete -= .01f;
        }
        else
            timer += Time.deltaTime;

        if (PictureManager.forward == false && !heartPercentText.isActiveAndEnabled)
        {
            heartPercentText.enabled = true;
        }

        heartPercentText.text = Mathf.Round((percentComplete * 100)).ToString() + "%";

        //Debug.Log(percentComplete);
        //percentComplete += Time.deltaTime * repairMultiplier;
        percentComplete = Mathf.Clamp(percentComplete, 0.0f, 1.0f);
        //repairMultiplier -= .000001f;
        //Mathf.Clamp(repairMultiplier, -.008f, .008f);
    }

    IEnumerator WinGame()
    {
        moveSpeed = 0.0f;
        winText.enabled = true;
        winSound.PlayOneShot(winSound.clip);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator LoseGame()
    {
        moveSpeed = 0.0f;
        loseText.enabled = true;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }

    //private void OnEnable()
    //{
    //    ws = new WebSocket(urlToRefresh);
    //    ws.OnOpen += (sender, e) => Debug.Log("Listening to WebSocket " + urlToRefresh);
    //    ws.OnMessage += (sender, e) => Debug.Log("Received " + e.Data + " " + e.Data.GetType());
    //    ws.OnError += (sender, e) => Debug.Log("WebSocket Error: " + e.Message);
    //    ws.OnClose += (sender, e) => Debug.Log("WebSocket Close " + e.Code);
    //    ws.OnMessage += (sender, e) => Debug.Log("Received Message");

    //    ws.Connect();
    //}

    //private void OnDisable()
    //{
    //    if (ws != null && ws.ReadyState == WebSocketState.Open)
    //    {
    //        ws.Close();
    //    }
    //}
}
