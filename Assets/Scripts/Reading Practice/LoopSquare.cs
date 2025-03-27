using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopSquare : MonoBehaviour
{
    public float t;

    void Start()
    {
        GetBigger();
    }

    private void Update()
    {
        //GetBigger();
    }

    // Update is called once per frame
    IEnumerator GetBigger()
    {
        while (t < 1)
        {
            t += Time.deltaTime;
        }

        transform.localScale = Vector3.one * t;

        yield return null;
    }
}
