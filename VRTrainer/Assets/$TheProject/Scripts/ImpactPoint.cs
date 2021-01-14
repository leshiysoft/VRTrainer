using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform WaterSurface;

    // Update is called once per frame
    void Update()
    {
        WaterSurface.GetComponent<MeshRenderer>().material.SetVector("_CenterPoint", transform.position);
    }

    void OnDisable()
    {
        WaterSurface.GetComponent<MeshRenderer>().material.SetVector("_CenterPoint", new Vector4(1000, 0, 0, 0));
    }
}
