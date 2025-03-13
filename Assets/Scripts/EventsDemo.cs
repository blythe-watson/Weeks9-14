 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsDemo : MonoBehaviour
{
    public RectTransform sushi;

    public UnityEvent TimerFinished;
    public float timerLength = 3;
    public float t;

    public void MouseEnterImage()
    {
        Debug.Log("The mouse just entered the image");
        sushi.localScale = Vector3.one * 1.2f;
    }

    public void MouseExitImage()
    {
        Debug.Log("The mouse just exited the image");
        sushi.localScale = Vector3.one;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if(t > timerLength)
        {
            t = 0;
            TimerFinished.Invoke();
        }
    }
}
