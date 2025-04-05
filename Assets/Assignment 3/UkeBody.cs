using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UkeBody : MonoBehaviour
{

    //the uke body is in charge of all the actual audio

    AudioSource audio;
    public AudioClip[] clips; 


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //a machine for converting strings of the note names into integers
    private int GetIndex(string Note)
    {
        //if the note that we fed into the machine matches any of these letters, convert them to a number. if it's any other letter it's 0.
        switch (Note)
        {
            case G:
                return 0;
            case C:
                return 1;
            case E:
                return 2;
            case A:
                return 3;
            default: return 0;
        }
    }

    
    //I would have used an enumerator but I think that's out of project scope
    public const string G = "G";
    public const string C = "C";
    public const string E = "E";
    public const string A = "A";

    //when this is invoked by the strummed event on the string, it receives the guitarstringdata
    public void OnStrummed(GuitarStringData data)
    {
        //put the name of the note through the machine from above to turn it into a number, call that number clip
        var clip = clips[GetIndex(data.Note)];
        //play the clip corresponding in the array
        audio.PlayOneShot(clip);
        Debug.Log(data.Note);
    }

    //I had this referenced on each string but that sounded ugly
    //now it's invoked by the input manager
    //this stops the audio at the same time as the string wiggling
    public void OnMute()
    {
        audio.Stop();
        Debug.Log("stopping audio");
        //audio.
    }

    /*public void PlayG()
    {
        Debug.Log("play G");
        audio.PlayOneShot(clips[0]);
    }

    public void PlayC()
    {
        Debug.Log("play C");
        audio.PlayOneShot(clips[1]);
    }
    public void PlayE()
    {
        Debug.Log("play E");
        audio.PlayOneShot(clips[2]);
    }
    public void PlayA()
    {
        Debug.Log("play A");
        audio.PlayOneShot(clips[3]);
    }*/

    public void ChangePitch(float increment)
    {
        //increment;
    }


}
