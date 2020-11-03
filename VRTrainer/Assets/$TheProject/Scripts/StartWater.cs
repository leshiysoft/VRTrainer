using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWater : MonoBehaviour
{

    public GameObject water;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            water.SetActive(!water.activeSelf);
        }
    }
}
