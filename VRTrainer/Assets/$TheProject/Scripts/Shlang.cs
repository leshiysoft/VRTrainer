using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shlang : MonoBehaviour
{
    public Transform pivot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pivot.position;
        //transform.rotation = pivot.rotation;
    }
}
