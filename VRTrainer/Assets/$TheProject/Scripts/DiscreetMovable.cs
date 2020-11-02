using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
public class DiscreetMovable : MonoBehaviour
{

    protected Interactable interactable;
    protected Hand.AttachmentFlags attachmentFlags = Hand.AttachmentFlags.DetachFromOtherHand;

    public float discreetStep = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
        gameObject.SetActive(false);
    }

    protected virtual void HandAttachedUpdate(Hand hand)
    {
        //Vector3 theT = hand.transform.position;
        //Vector3 newPos = new Vector3(Mathf.Round(theT.x * 10) / 10, Mathf.Round(theT.y * 10) / 10, Mathf.Round(theT.z * 10) / 10);
        //transform.position = newPos;
        transform.position = hand.transform.position;
        //transform.rotation = hand.transform.rotation;

        if (hand.IsGrabEnding(this.gameObject))
        {
            hand.DetachObject(gameObject);
            Vector3 theT = hand.transform.position;
            float dStep = 1.0f / discreetStep;
            Vector3 newPos = new Vector3(Mathf.Round(theT.x * dStep) / dStep, Mathf.Round(theT.y * dStep) / dStep, Mathf.Round(theT.z * dStep) / dStep);
            transform.position = newPos;
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
