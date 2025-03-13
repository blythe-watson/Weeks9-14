using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 1;

    public SpriteRenderer sr;

    public AnimationCurve curve;
    public float t;
    bool isDead = false;

    //TargetSpawner is the name of the script itself - in the inspector, we can drop in anything holding that script, and it'll grab it
    //spawner is how we refer to the grabbed script within THIS script
    public TargetSpawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //get the current position
        Vector2 pos = transform.position;
        //convert it to screen position
        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        //the x position changes based on speed and delta time
        pos.x += speed * Time.deltaTime;

        //if it goes off the edge of the screen it reverses
        if(screenPos.x < 0)
        {
            speed = speed * -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        }

        if(screenPos.x > Screen.width)
        {
            speed = speed * -1;
            pos.x = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        }

        transform.position = pos;

        if(Input.GetMouseButtonDown(0))
        {
            //handy dandy function - bounds is the bounds of the sprite
            //contains sees if the value you pass is contained within those bounds
            
            //get the mouse position, make it into a vector variable
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(sr.bounds.Contains(mousePos))
            {
                sr.color = Color.red;
                isDead = true;
                Destroy(gameObject, 1);
                //please refer back to the TargetSpawner script and enact the TargetHit function with me as the subject
                spawner.TargetHit(gameObject);
            }
        }

        if(isDead)
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.one * curve.Evaluate(t);
        }

    }
}
