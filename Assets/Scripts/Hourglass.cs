using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    AudioSource pickupSound;
    float origYPos;

    // Start is called before the first frame update
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
        origYPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, origYPos + Mathf.Sin(Time.time * 0.8f) * 0.5f, transform.localPosition.z);
        this.transform.position += transform.forward * GameManager.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            pickupSound.PlayOneShot(pickupSound.clip);
            GameManager.Score();
        }
    }
}
