using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public AudioSource collideSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * GameManager.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "SpawnChecker")
            return;

        if (other.tag == "MainCamera")
        {
            collideSound.PlayOneShot(collideSound.clip);
            ScreenShakeVR.TriggerShake(0.65f, .5f);
            GameManager.percentComplete -= .04f;
        }
    }
}
