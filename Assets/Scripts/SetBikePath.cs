using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBikePath : MonoBehaviour
{
    [SerializeField] GameObject BikePath;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject SelectSong;

    public void PlaceBikePath()
    {
        Arrow.SetActive(false);
        BikePath.transform.position = Camera.main.transform.position;
        BikePath.transform.forward = Camera.main.transform.forward;
        BikePath.gameObject.SetActive(true);
        GameManager.bikePathPlaced = true;
        RestartButton.SetActive(true);
        SelectSong.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
