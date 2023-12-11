using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Teleportation-based navigation
/// </summary>
public class NavigationTeleport : MonoBehaviour
{
    //inputActionProperty on the secondary button
    public InputActionProperty secondaryButton;
    //inputActionProperty on the tertiary button
    public InputActionProperty tertiaryButton;
    [SerializeField, Tooltip("Player to move")]
    /// <summary>Player to move</summary>
    private GameObject Player;

    //[SerializeField, Tooltip("Movement speed")]
    /// <summary>Movement speed in m/s</summary>
    //private float MoveSpeed = 1;

    [SerializeField, Tooltip("Show ray and find target destination")]
    /// <summary>Show ray and find target destination</summary>
    private HandRayCastParabolic HandRayCastParabolic;

    // @TODO: Map to input settings

    private void StartTeleportAim(InputAction.CallbackContext context)
    {
        // @TODO: Create function using HandRayCastParabolic
        //on hold of secondary button, show ray
        if (secondaryButton.action.ReadValue<float>() == 1)
        {
            HandRayCastParabolic.gameObject.SetActive(true);

            if (tertiaryButton.action.ReadValue<float>() == 1)
            {
                Teleport(context);
            }
        }
    }

    private void Teleport(InputAction.CallbackContext context)
    {
        // @TODO: Create function using HandRayCastParabolic
        //on release of secondary button, teleport
        if (secondaryButton.action.ReadValue<float>() == 0)
        {
            HandRayCastParabolic.gameObject.SetActive(false);
            // Use ObjectInSection instead of ObjectInRay
            Player.transform.position = HandRayCastParabolic.ObjectInSection(transform.position, transform.forward)?.point ?? Player.transform.position;
        }
    }
}
