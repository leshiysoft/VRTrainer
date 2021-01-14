using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y -= 0.0005f * Time.deltaTime;
        if (pos.y < minLevel)
            pos.y = minLevel;
        if (pos.y > maxLevel)
            pos.y = maxLevel;
        transform.position = pos;
        recalcAlpha();
    }

    private float maxLevel = 0.1f;
    private float minLevel = 0.048f;
    private float maxAlpha = 0.76f;

    public void incLevel()
    {
        Vector3 pos = transform.position;
        pos.y += 0.0015f * Time.deltaTime;
        if (pos.y < minLevel)
            pos.y = minLevel;
        if (pos.y > maxLevel)
            pos.y = maxLevel;
        transform.position = pos;
        recalcAlpha();
    }

    void recalcAlpha()
    {
        float newAlpha;
        newAlpha = (transform.position.y - minLevel) / (maxLevel - minLevel) * maxAlpha;
        Material mat = GetComponent<MeshRenderer>().material;
        Color col = mat.GetColor("_Color");
        col.a = newAlpha;
        mat.SetColor("_Color", col);
    }

}
