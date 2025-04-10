using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheMouse : MonoBehaviour
{
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var color = UnityEngine.Random.ColorHSV();
            sprite.color = color;
        }
    }
}
