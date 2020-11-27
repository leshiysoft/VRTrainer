using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RotationInteractable : MonoBehaviour
{

    protected Interactable interactable;
    protected bool driving = false;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private GrabTypes grabbedWithType;

    private void HandHoverUpdate(Hand hand)
    {
        GrabTypes startingGrabType = hand.GetGrabStarting();
        bool isGrabEnding = hand.IsGrabbingWithType(grabbedWithType) == false;

        if (grabbedWithType == GrabTypes.None && startingGrabType != GrabTypes.None)
        {
            grabbedWithType = startingGrabType;

            hand.HoverLock(interactable);

            driving = true;

            updateRotation(hand.transform);

            hand.HideGrabHint();
        }
        else if (grabbedWithType != GrabTypes.None && isGrabEnding)
        {
            hand.HoverUnlock(interactable);

            driving = false;

            grabbedWithType = GrabTypes.None;
        }

        if (driving && isGrabEnding == false && hand.hoveringInteractable == this.interactable)
        {
            updateRotation(hand.transform);
        }
    }

    void updateRotation(Transform hvat)
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
