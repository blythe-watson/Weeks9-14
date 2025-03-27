using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionalSquare : MonoBehaviour
{
    public float t;

    void Start()
    {
        
    }

    private void Update()
    {
        GetBigger();
    }

    // Update is called once per frame
    void GetBigger()
    {
        if(t < 1)
        {
            t += Time.deltaTime;
        }

        transform.localScale = Vector3.one * t;

    }
}
