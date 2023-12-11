using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandTrackingVR : MonoBehaviour
{
    public InputActionProperty positionAction;
    public InputActionProperty rotationAction;

    public InputActionProperty primaryButton;

    // @TODO: Add an action for interactions

    public HandRayCast handRay;

    // Start is called before the first frame update
    void Start()
    {
        positionAction.action.Enable();
        rotationAction.action.Enable();
        // @TODO: Enable other actions
        primaryButton.action.Enable();


        positionAction.action.performed += UpdatePos;
        rotationAction.action.performed += UpdateRot;
        // @TODO: Add event listeners for (1) Starting a raycast for interaction (2) Stopping the raycast and interacting



        primaryButton.action.started += StartRayCast;
        primaryButton.action.canceled += Interact;


        primaryButton.action.performed += ctx => Interact(ctx);

    }

    private void OnDestroy()
    {
        positionAction.action.performed -= UpdatePos;
        rotationAction.action.performed -= UpdateRot;
        // @TODO: Destroy event listeners

    }

    private void Interact(InputAction.CallbackContext obj)  // @TODO: Use this function
    {
        Interactable interactableObject = handRay.ObjectInRay();
        if (interactableObject != null) interactableObject.Interact();
        handRay.gameObject.SetActive(false);
    }

    private void StartRayCast(InputAction.CallbackContext obj) // @TODO: Use this function
    {
        handRay.gameObject.SetActive(true);
    }

    private void UpdatePos(InputAction.CallbackContext obj)
    {
        transform.localPosition = obj.ReadValue<Vector3>();
    }

    private void UpdateRot(InputAction.CallbackContext obj)
    {
        transform.localRotation = obj.ReadValue<Quaternion>();
    }
}
