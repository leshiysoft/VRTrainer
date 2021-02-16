using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float offset = 0;
    public float value = 0;

    float prev = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(transform.parent.forward, -prev, Space.Self);
        //transform.rotation = transform.parent.rotation;
        float theValue = value / 35 * 265;
        transform.Rotate(0, 0, -prev);
        transform.Rotate(0,0,offset + theValue);
        prev = offset + theValue;
    }
}
