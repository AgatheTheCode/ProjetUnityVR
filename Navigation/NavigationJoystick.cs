using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Joystick-based navigation
/// </summary>
public class NavigationJoystick : MonoBehaviour
{
    //inputActionProperty on the sticks
    public InputActionProperty leftStick;
    public InputActionProperty rightStick;
    
    [SerializeField, Tooltip("Player to move")]
    /// <summary>Player to move</summary>
    private GameObject Player;

    [SerializeField, Tooltip("Movement speed")]
    /// <summary>Movement speed in m/s</summary>
    private float MoveSpeed = 1;

    // @TODO: Map to input settings

    private void MoveLeftRight(InputAction.CallbackContext context)
    {
        //movement on the x axis
        float x = context.ReadValue<float>();
        if(x != 0)
        {
            Player.transform.position += Player.transform.right * x * MoveSpeed * Time.deltaTime;
        }
        // @TODO: Create function using context.ReadValue<float>()
    }

    private void MoveForwardBackward(InputAction.CallbackContext context)
    {
        //movement on the z axis
        float z = context.ReadValue<float>();
        if (z != 0)
        {
            Player.transform.position += Player.transform.forward * z * MoveSpeed * Time.deltaTime;
        }
        // @TODO: Create function using context.ReadValue<float>()
    }
}
