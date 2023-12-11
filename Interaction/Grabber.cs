using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private Grabbable ObjectToGrab = null;
    private bool grabbing = false;

    private void OnTriggerEnter(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();

        // Check if the collided object is grabbable
        if (grabbable != null && !grabbing)
        {
            ObjectToGrab = grabbable;
            // TODO: Notify or show some UI indication that the object can be grabbed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Grabbable grabbable = other.GetComponent<Grabbable>();

        // Check if the collided object is the currently grabbable object
        if (grabbable != null && grabbable == ObjectToGrab)
        {
            ObjectToGrab = null;
            // TODO: Remove any UI indication that the object can be grabbed
        }
    }

    // Call this method to grab the currently available object
    public void Grab()
    {
        if (ObjectToGrab != null && !grabbing)
        {
            grabbing = true;
            ObjectToGrab.OnGrab(this); // Pass the grabber reference to the Grabbable object
            // TODO: Implement the logic to attach the object to the hand or controller
        }
    }

    // Call this method to release the currently grabbed object
    public void Release()
    {
        if (grabbing)
        {
            grabbing = false;
            ObjectToGrab.Release();
            // TODO: Implement the logic to detach the object from the hand or controller
            ObjectToGrab = null;
        }
    }
}