using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPractice : MonoBehaviour
{
    public Vector3 mousePos;

    [Range(0, 1)]
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 path = mousePos - transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            Vector2 currentPos = transform.position;

            currentPos.x = Mathf.Lerp(currentPos.x, mousePos.x, t);
        }
    }
}
