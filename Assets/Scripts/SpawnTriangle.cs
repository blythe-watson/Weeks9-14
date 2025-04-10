using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnTriangle : MonoBehaviour
{
    public float t = 0;
    public float duration = 5;

    public GameObject prefab;
    public CinemachineImpulseSource shaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefab, mousePos, Quaternion.identity);
            shaker.GenerateImpulse();
        }

    }
}
