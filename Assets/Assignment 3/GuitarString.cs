using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class GuitarString : MonoBehaviour
{
    //needed a hard reference to remove the listener since for some reason RemoveListener and RemoveAllListeners weren't working?
    public UkeBody body;

    //to keep track of how tight the string is. when it's too tight or loose it will snap
    //this specific value doesn't affect the pitch of the notes, that's ukebody's job
    public float pitch = 1;
    public float maxPitch = 2;
    public float minPitch = 0.2f;

    //how long the string will wiggle when strummed
    public float duration = 2;
    //how fast and how high the string will wiggle when strummed
    public float amplitude = 0.005f;
    public float frequency = 40;
    //once the pitch reaches a certain threshold this will be true, which will remove the string as a listener to the peg and disable its sprite renderer.
    public bool snapped = false;

    //for fixing the string's local position when wiggling, since it was sticking in place after wiggling
    Vector2 offset;

    private Coroutine coroutine;    //shockingly, it's a coroutine

    //the name of the note. on each string I will type this in manually so the string knows what note it is (G, C, A, E)
    public string note;


    //this gets invoked by the OnStrummed method of the string, which gets activated when the mouse goes over the corresponding sensor
    //it activates the OnStrummed method in the body of the ukulele, which then plays the note
    //GuitarStringData is something I set up below that takes a note name and a pitch integer
    public UnityEvent<GuitarStringData> Strummed;

    //gets called when the string gets too tight
    public UnityEvent<GuitarStringData> Snapped;

    //so I can turn off the string's sprite later
    public SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
        //the original position of the string; it will return to this when finished wiggling.
        offset = new Vector2(transform.localPosition.x, transform.localPosition.y);

        Strummed.AddListener(body.OnStrummed);
    }

    // Update is called once per frame
    void Update()
    {

    }


    //when the tuning pegs invoke tuned, this changes the string's value of pitch and activates onpitchchanged
    public void ChangePitch(float value)
    {
        pitch = value;
        OnPitchChanged();
    }

    //this function checks to see if the pitch is outside of a certain threshold, and activates snapped if it is
    public void OnPitchChanged()
    {
        if(pitch > maxPitch || pitch < minPitch)
        {
            //remove the ukebody as a listener - can no longer play audio
            Strummed.RemoveListener(body.OnStrummed);
            snapped = true;
            //turn off that string sprite
            sprite.enabled = false;
            //invoke that snapped event
            Snapped.Invoke(new GuitarStringData(note, pitch));
        }
    }

    //this gets called by a UI component when the mouse goes over the strings
    //if the string is snapped, the coroutine does not run at all
    public void OnStrummed()
    {
        if (snapped)
        {
            return;
        }
        //if the coroutine is active, call the muting function to cut the sound so you can play the sound again
        if (coroutine != null)
        {
            OnMute();
        }
        //invoke the strummed event, which I listed up above
        //give it the note name I typed in and the pitch of the string
        Strummed.Invoke(new GuitarStringData(note, pitch));
        //start the coroutine that makes it wiggle
        coroutine = StartCoroutine(DoStrum());

    }

    //when the input manager senses a mouse click, it invokes an event that activates this method
    public void OnMute()
    {
        //if the coroutine isn't happening anyway, just ignore this
        if (coroutine == null) return;
        //if the coroutine is happening, stop it midway and run the cleanup
        StopCoroutine(coroutine);
        DoComplete();
    }

    //this makes the string wiggle when strummed
    private IEnumerator DoStrum()

    {
        yield return null;
        //elapsed is how much time the string has been wiggling for
        float elapsed = 0f;

        //as long as elapsed is less than the time we set for the duration of the wiggle, the coroutine will happen
        while (elapsed < duration)

        {
            //add onto elapsed over time
            elapsed += Time.deltaTime;
            
            //change the y pos based on a sin curve with those values we set earlier
            float y = Mathf.Sin(elapsed * frequency) * amplitude;
            transform.localPosition = new Vector3(offset.x, offset.y + y, 0);
            yield return null;

        }

        DoComplete();
    }


    //for ending the coroutine
    private void DoComplete()
    {
        coroutine = null;
        //return the string to its original position
        transform.localPosition = offset;
    }

  
}

//fancy lil trick I learned. A guitarstringdata takes the name of a note and the integer of a pitch.
//this will be placed within a unity event and sent to the ukebody
public struct GuitarStringData
{
    public string Note;
    public float Pitch;
    public GuitarStringData(string note, float pitch)
    {
        Note = note;
        Pitch = pitch;
    }
}
