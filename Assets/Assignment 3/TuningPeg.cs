using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TuningPeg : MonoBehaviour
{
    public float increment;
    public UnityEvent<float> Tuned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //up buttons activate the tighten function, down buttons activate the loosen function
    //both functions will assign a value to increment, then send increment to both ukebody and guitarstring
    //both will add increment to their current pitch
    //guitarstring uses pitch to keep track of how tight it is
    //ukebody uses pitch to know what pitch it should play a note at
    public void Tighten()
    {
        Debug.Log("String tightened");
        increment = 0.1f;
        Tuned.Invoke(increment);
    }

    
    public void Loosen()
    {
        Debug.Log("String loosened");
        increment = -0.1f;
        Tuned.Invoke(increment);
    }
}
