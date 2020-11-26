using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInteractable : MonoBehaviour
{

    public Transform hvat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m;

        Vector3 n = transform.forward;
        Vector3 h = hvat.position;
        Vector3 a = transform.position;

        m = h + (-Vector3.Dot(h, n) + Vector3.Dot(n, a)) * n;

        Vector3 s = transform.up;
        Vector3 p = (m - transform.position).normalized;

        float angle = Mathf.Sign(Vector3.Dot(Vector3.Cross(s, p), transform.forward)) * Mathf.Asin(Vector3.Cross(s, p).magnitude);

        transform.RotateAround(transform.parent.position, transform.parent.forward, angle / Mathf.PI * 180);

    }
}
