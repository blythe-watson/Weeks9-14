using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerScript : MonoBehaviour
{

    public float t = 0;

    public float wait = 3;
    public float lifespan = 6;
    public float speed = 5;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        if (t < wait)
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0;
            Vector2 direction = mouse - transform.position;

            transform.up = direction;
        }
        else
        {
            Vector2 pos = transform.position;
            pos.y += speed * Time.deltaTime;
            transform.position = pos;
        }


        if (t > lifespan)
        {
            Destroy(gameObject);
        }

    }


}
