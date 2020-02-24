using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelector : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip jazz;
    [SerializeField] AudioClip techno;
    [SerializeField] AudioClip flylo;
    [SerializeField] AudioClip retrofunk;
    [SerializeField] AudioClip tmcferrin;

    public void SelectJazz()
    {
        audioSource.Stop();
        audioSource.clip = jazz;
        audioSource.Play();
    }

    public void SelectTechno()
    {
        audioSource.Stop();
        audioSource.clip = techno;
        audioSource.Play();
    }

    public void SelectFlyLo()
    {
        audioSource.Stop();
        audioSource.clip = flylo;
        audioSource.Play();
    }

    public void SelectRetroFunk()
    {
        audioSource.Stop();
        audioSource.clip = retrofunk;
        audioSource.Play();
    }

    public void SelectTMcferrin()
    {
        audioSource.Stop();
        audioSource.clip = tmcferrin;
        audioSource.Play();
    }
}
