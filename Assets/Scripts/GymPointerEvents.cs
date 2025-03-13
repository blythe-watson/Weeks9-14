using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymPointerEvents : MonoBehaviour
{
    public RectTransform size;
    public Image colour;
    public GameObject prefab;
    public Transform space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseEnterImage()
    {
        Debug.Log("mouse has entered image");
        size.localScale = Vector3.one * 1.2f;
    }

    public void MouseExitImage()
    {
        size.localScale = Vector3.one;
        colour.color = Random.ColorHSV();
    }

    public void OnClick()
    {
        Vector3 ranpos = Random.insideUnitCircle * 500;
        GameObject arrow = Instantiate(prefab, space);
        arrow.transform.position = ranpos;
    }
}
