using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Pitching : MonoBehaviour
{
    public enum ScenePitcher { IsScene, IsPitcher };

    public ScenePitcher scenePitcher = Pitching.ScenePitcher.IsScene;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float time = 0;

    public float xAmplitude = 1;
    public float xfreq = 1;
    public float zAmplitude = 1;
    public float zfreq = 1.3f;

    // Update is called once per frame
    void Update()
    {
        if (scenePitcher == ScenePitcher.IsScene)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
            time += Time.deltaTime;
            transform.rotation = Quaternion.EulerAngles(xAmplitude*Mathf.PI/180*Mathf.Sin(xfreq*time), 0f, zAmplitude * Mathf.PI / 180 * Mathf.Sin(zfreq * time));
        } else
        {
            transform.position = new Vector3(gameObject.transform.parent.position.x -player.position.x, transform.position.y, gameObject.transform.parent.position.z - player.position.z);
        }
    }
}
