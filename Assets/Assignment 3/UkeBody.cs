using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkeBody : MonoBehaviour
{
    AudioSource audio;
    public AudioClip G;
    public AudioClip C;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayG()
    {
        Debug.Log("play G");
        audio.PlayOneShot(G);
    }

    public void PlayC()
    {
        Debug.Log("play C");
        audio.PlayOneShot(C);
    }
}
