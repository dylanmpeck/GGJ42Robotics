using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WebSocketSharp;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject headTiltText;
    [SerializeField] GameObject timePieceText;
    static GameObject timePieceTextRef;
    [SerializeField] GameObject bikePath;

    Vector3 startDirToHeadTiltText;
    float startDirZ;

    static public float moveSpeed = 0f;

    static public int currentScore = 0;

    public static bool bikePathPlaced;

    public static bool begin;
/*    public static bool lose;
    public static bool win;*/

    public AudioSource winSound;

    public string urlToRefresh;
    WebSocket ws;

    float unitySpeedMax = 30.0f;
    float bikeSpeedMax = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0f;
        begin = true;
        startDirToHeadTiltText = (headTiltText.transform.position - player.transform.position).normalized;
        startDirZ = startDirToHeadTiltText.z;

        timePieceTextRef = timePieceText;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Mathf.Clamp(moveSpeed, 0.0f, 20f);

        if (!Mathf.Approximately(moveSpeed, 0))
            begin = false;

/*        if (startDirZ < 0.0f && (headTiltText.transform.position - player.transform.position).normalized.z > 0.0f ||
            startDirZ > 0.0f && (headTiltText.transform.position - player.transform.position).normalized.z < 0.0f)
        {
            timePieceText.SetActive(true);
        }*/
    }

    public static void Score()
    {
        currentScore++;
        timePieceTextRef.GetComponent<TextMesh>().text = "TP: " + currentScore.ToString();

        if (currentScore == 1)
            timePieceTextRef.SetActive(true);
    }

    /*    IEnumerator WinGame()
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
        }*/

    private void OnEnable()
    {
        ws = new WebSocket("ws://192.168.4.1:8765");
        ws.OnOpen += (sender, e) => Debug.Log("Listening to WebSocket " + urlToRefresh);
        ws.OnMessage += (sender, e) => SetSpeed(e);
        ws.OnError += (sender, e) => Debug.Log("WebSocket Error: " + e.Message);
        ws.OnClose += (sender, e) => Debug.Log("WebSocket Close " + e.Code);
        ws.OnMessage += (sender, e) => Debug.Log("Received Message");

        ws.Connect();
    }

    private void OnDisable()
    {
        if (ws != null && ws.ReadyState == WebSocketState.Open)
        {
            ws.Close();
        }
    }

    void SetSpeed(MessageEventArgs e)
    {
        if (bikePathPlaced == false) return;
        Debug.Log("Received " + e.Data + " " + e.Data.GetType());
        if (float.Parse(e.Data) <= 0.0f)
        {
            moveSpeed = 0.0f;
            return;
        }

        moveSpeed = (float.Parse(e.Data) / bikeSpeedMax) * unitySpeedMax;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
