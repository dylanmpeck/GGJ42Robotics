using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    AudioSource pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        pickupSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * 1.5f) * 0.5f, transform.position.z);
        this.transform.position += transform.forward * GameManager.moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainCamera")
        {
            pickupSound.PlayOneShot(pickupSound.clip);
            //GameManager.repairMultiplier += .01f;
            GameManager.percentComplete += 0.04f;
        }
    }
}
