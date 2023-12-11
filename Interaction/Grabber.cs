using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Object with the capacity to grab
/// </summary>
public class Grabber : MonoBehaviour
{
    /// <summary>Currently grabbed object or available object</summary>
    private Grabbable ObjectToGrab = null;
    /// <summary>Are we currently grabbing an object?</summary>
    private bool grabbing = false;

    /// <summary>
    /// Called when doing a collision with a trigger object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        // @TODO: Keep the link to currently available object
    }

    // @TODO: Detect when the object is no longer available (end of collision)

    // @TODO: Add the properties and methods to grasp the object and release it
}
