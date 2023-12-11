using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// Interacts with the object
    /// </summary>
    public abstract void Interact();

    #region KeyboardDebug
    /// <summary>
    /// Keyboard key to interact with the object (for debug purpose)
    /// </summary>
    [Tooltip("Keyboard key to interact with the object (for debug purpose)")]
    public KeyCode key;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
#if UNITY_EDITOR    // If in the editor
        if (Input.GetKeyDown(key)) Interact();  // Interacts when the keyboard key is pressed
#endif
    }
    #endregion
}
