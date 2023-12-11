using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One roll in the lock
/// </summary>
public class LockRoll : Interactable
{
    /// <summary>
    /// Current displayed digit
    /// </summary>
    public uint currentDigit
    {
        get; private set;
    }

    /// <summary>
    /// Gets the curren digit
    /// </summary>
    /// <returns></returns>
    public uint GetDigit()
    {
        return currentDigit;
    }

    /// <summary>
    /// Goes to the next digit
    /// </summary>
    [ContextMenu("NextDigit (test)")]
    public void NextDigit()
    {
        currentDigit = (currentDigit + 1) % 10;
        transform.Rotate(-36, 0, 0);
    }

    /// <summary>
    /// Interacts with the object
    /// </summary>
    public override void Interact()
    {
        NextDigit();
    }
}
