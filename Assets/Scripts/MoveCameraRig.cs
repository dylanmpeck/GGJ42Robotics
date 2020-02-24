using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MoveCameraRig : MonoBehaviour
{
    public List<Transform> lanes;
    List<Vector3> lanePositions = new List<Vector3>();
    int currentLane = 1;
    public Transform head;

    bool lanePosSet;

    public Text debug;
    public GameObject rightController;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.bikePathPlaced)
        {
            if (!lanePosSet)
            {
                lanePosSet = true;
                SetLanePositions();
            }
            //Debug.Log(head.localEulerAngles);
            if (head.localEulerAngles.z > 15.0f && head.localEulerAngles.z < 100.0f)
            {
                float speedPercantage = Mathf.Clamp(head.localEulerAngles.z / 45.0f, 0f, 1f);
                float speed = speedPercantage * 8.0f;
                if (currentLane == 0)
                    return;
                /*                this.transform.position =
                                    Vector3.MoveTowards(transform.position, new Vector3(lanePositions[currentLane - 1].x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                                if (Mathf.Approximately(transform.position.x, lanePositions[currentLane - 1].x))
                                    currentLane--;*/
                this.transform.position = Vector3.MoveTowards(transform.position, lanePositions[currentLane - 1], speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, lanePositions[currentLane - 1]) <= 0.4f)
                    currentLane--;
            }
            if (head.localEulerAngles.z < 354.0f && head.localEulerAngles.z > 300.0f)
            {
                float speedPercantage = Mathf.Clamp(head.localEulerAngles.z / 45.0f, 0f, 1f);
                float speed = speedPercantage * 8.0f;
                if (currentLane == lanePositions.Count - 1)
                    return;
                /*                this.transform.position =
                                    Vector3.MoveTowards(transform.position, new Vector3(lanePositions[currentLane + 1].x, transform.position.y, transform.position.z), speed * Time.deltaTime);
                                if (Mathf.Approximately(transform.position.x, lanePositions[currentLane + 1].x))
                                    currentLane++;*/

                this.transform.position = Vector3.MoveTowards(transform.position, lanePositions[currentLane + 1], speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, lanePositions[currentLane + 1]) <= 0.4f)
                    currentLane++;
            }
        }
    }

    void SetLanePositions()
    {
        foreach (Transform l in lanes)
        {
            lanePositions.Add(l.position);
        }
    }
}
