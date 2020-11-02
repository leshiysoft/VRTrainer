using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

//[RequireComponent(typeof(Interactable))]
public class HandOperated : MonoBehaviour
{
    public Transform PositionHand;
    //public Transform RotationHand;

    Vector3 PositionOffset;

    float nearZone = 0.5f;

    //protected Interactable interactable;

    private void Start()
    {
        PositionOffset = transform.position - PositionHand.position;
        //interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        transform.position = PositionHand.position + PositionOffset;
        //transform.rotation = RotationHand.rotation;
        bool leftNear = Vector3.Distance(Player.instance.leftHand.transform.position, PositionHand.position) < nearZone;
        bool rightNear = Vector3.Distance(Player.instance.rightHand.transform.position, PositionHand.position) < nearZone;
        PositionHand.gameObject.SetActive(leftNear || rightNear);
    }

    /*private void OnHandHoverBegin()
    {
        PositionHand.gameObject.SetActive(true);
    }


    //-------------------------------------------------
    private void OnHandHoverEnd()
    {
        PositionHand.gameObject.SetActive(false);
    }*/


}
