using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatFlight : MonoBehaviour
{
    public float speed = 10;
    public AnimationCurve heartBeat;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.right * speed * Time.deltaTime;
        Vector2 pos = transform.position;

        Vector3 tmpPos = Camera.main.WorldToScreenPoint(transform.position);


        if (tmpPos.x > Screen.width)
         {
            //transform.position = (transform.position - transform.position);
            pos.x = pos.x * -1;

         }

        transform.position = pos;
    }
}
