using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpGrower : MonoBehaviour
{
    public AnimationCurve curve;
    public float minSize = 0;
    public float maxSize = 1;
    public float t;
    public bool startGrowing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //the thing that keeps the engine running instead of lighting up once and stopping
        if (startGrowing)
        {
            Grow();
        }
    }

    //the switch
    public void StartGrowing()
    {
        t = 0;
        startGrowing = true;
    }

    //the engine
    public void Grow()
    {
        if (t < 1)
        {
            t += Time.deltaTime;
        }
        else
        {
            startGrowing = false;
        }

        transform.localScale = Vector3.one * maxSize * curve.Evaluate(t);

    }


}
