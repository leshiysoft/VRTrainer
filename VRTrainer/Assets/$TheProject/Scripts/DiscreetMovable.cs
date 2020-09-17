using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class DiscreetMovable : MonoBehaviour
{

    protected Interactable interactable;
    protected Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    protected virtual void HandAttachedUpdate(Hand hand)
    {
        //Vector3 theT = hand.transform.position;
        //Vector3 newPos = new Vector3(Mathf.Round(theT.x * 10) / 10, Mathf.Round(theT.y * 10) / 10, Mathf.Round(theT.z * 10) / 10);
        //transform.position = newPos;
        transform.position = hand.transform.position;

        if (hand.IsGrabEnding(this.gameObject))
        {
            hand.DetachObject(gameObject);
        }
    }


    protected virtual void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();

        if (interactable.attachedToHand == null && startingGrabType != GrabTypes.None)
        {
            hand.AttachObject(gameObject, startingGrabType, attachmentFlags);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
