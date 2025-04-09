using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEditor.PlayerSettings;
using UnityEngine.Assertions;
using UnityEngine.XR;

public class UkeBody : MonoBehaviour
{

    //the uke body is in charge of all the actual audio

    AudioSource audio;

    //public AudioClip[] clips;
    public AudioClip tuneUp;
    //public AudioClip tuneDown;

    //I used to have an array of clips but then I realized that wouldn't work if I wanted to change the pitch of each string separately
    //so now I have an array of audio sources
    public AudioSource[] sources;


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
        //put the name of the note through the machine from above to turn it into a number, call that number in the audiosource array
        //since you can't change the pitch of an individual clip. maybe you can but I'd probably need some new unity addon or whatever. like. naw man I'm tired
        //var clip = clips[GetIndex(data.Note)];
        var source = sources[GetIndex(data.Note)];

        source.pitch = data.Pitch;
        //play the audioSource corresponding in the array
        source.Play(0);
        Debug.Log(data.Note);
    }

    //I had this referenced on each string but that sounded ugly
    //now it's invoked by the input manager
    //this stops the audio at the same time as the string wiggling
    public void OnMute()
    {
        for(int i = 0; i < sources.Length; i++)
        {
            sources[i].Stop();
            Debug.Log("stopping audio");
            //audio.
        }

    }


   /* I met a traveller from an antique land,
    Who said— “Two vast and fruitless attempts at sound
    Stand in the Uke script. . . .Near them, on the sand,
    Half sunk a shattered audioClip lies, whose frown,
    And wrinkled lip, and sneer of cold command,
    Tell that its sculptor well those passions read
    Which yet survive, stamped on these lifeless things,
    The hand that mocked them, and the heart that fed;
    And on the pedestal, these words appear:
    My name is void OnTuned, King of Kings;
    Look on my Works, ye Mighty, and despair!
    Nothing beside remains.Round the decay
    Of that colossal Wreck, boundless and bare
    The lone and level sands stretch far away.”*/


   /* public void OnTuned(float value)
    {
        audio.PlayOneShot(tuneUp);
    }*/

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
