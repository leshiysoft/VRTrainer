using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOperated : MonoBehaviour
{
public Transform PositionHand;
    public Transform RotationHand;

    Vector3 PositionOffset;

    private void Start()
    {
        PositionOffset = transform.position - PositionHand.position;
    }

    void Update()
    {
        transform.position = PositionHand.position + PositionOffset;
        transform.rotation = RotationHand.rotation;
    }
}
