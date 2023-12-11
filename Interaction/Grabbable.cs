using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Objects that can be grabbed
/// Needs a collider and a rigidbody to work
/// </summary>
[RequireComponent(typeof(Collider)), RequireComponent(typeof(Rigidbody))]
public class Grabbable : MonoBehaviour
{
    #region InfoBeforeGrab
    /// <summary>Parent object before being grabbed</summary>
    private Transform initialParent;
    /// <summary>Position before being grabbed</summary>
    private Vector3 initialLocalPosition;
    /// <summary>Rotation before being grabbed</summary>
    private Quaternion initialLocalRotation;
    /// <summary>Physics interaction before being grabbed</summary>
    private bool wasKinematic;
    #endregion

    #region ExternalBehavious
    /// <summary>RigidBody component stored for reuse</summary>
    private Rigidbody rigidBody;
    #endregion

    #region InspectorVariables
    /// <summary>
    /// Should the object go back to where it was if released?
    /// </summary>
    [SerializeField, Tooltip("Should the object go back to where it was if released?")]
    private bool GoBack = false;
    #endregion

    #region UnityMethods
    /// <summary>
    /// Called at the start of the application
    /// </summary>
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }
    #endregion

    #region GrabMethods
    /// <summary>
    /// Grabs the object
    /// </summary>
    /// <param name="grabber">Object at the origin of the grab</param>
    public void OnGrab(Grabber grabber)
    {
        initialParent = transform.parent;
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
        wasKinematic = rigidBody.isKinematic;

        transform.parent = grabber.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        rigidBody.isKinematic = true;
    }

    /// <summary>
    /// Releases the object mid-air or at its original place depending on GoBack
    /// </summary>
    public void Release()
    {
        if (GoBack)
        {
            transform.parent = initialParent;
            transform.localPosition = initialLocalPosition;
            transform.localRotation = initialLocalRotation;
            rigidBody.isKinematic = wasKinematic;
        }
        else
        {
            transform.parent = null;
            rigidBody.isKinematic = false;
        }
    }
    #endregion
}
