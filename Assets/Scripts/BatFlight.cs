using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFlight : MonoBehaviour
{
    public float speed = 10;
    public AnimationCurve heartBeat;
    public float t;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        Vector2 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        pos.y = heartBeat.Evaluate(t) + 4;

        Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);


        if (tmpPos.x > Screen.width)
         {
            //transform.position = (transform.position - transform.position);
            pos.x = pos.x * -1;
            t = 0;
         }

        transform.position = pos;
    }
}
