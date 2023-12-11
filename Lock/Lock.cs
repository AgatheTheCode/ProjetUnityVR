using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{
    /// <summary>
    /// Code solution
    /// </summary>
    private uint[] code = { 2, 3, 8, 9 };

    [SerializeField, Tooltip("First roll, for thousands")]
    /// <summary>First roll, for thousands</summary>
    private LockRoll Roll1;
    [SerializeField, Tooltip("Second roll, for hundreds")]
    /// <summary>Second roll, for hundreds</summary>
    private LockRoll Roll2;
    [SerializeField, Tooltip("Third roll, for tens")]
    /// <summary>Third roll, for tens</summary>
    private LockRoll Roll3;
    [SerializeField, Tooltip("Fourth roll, for units")]
    /// <summary>Fourth roll, for units</summary>
    private LockRoll Roll4;

    /// <summary>
    /// Events launched when entering the correct code
    /// </summary>
    public UnityEvent OnUnlockedEvent;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Roll1.currentDigit == code[0] &&
            Roll2.currentDigit == code[1] &&
            Roll3.currentDigit == code[2] &&
            Roll4.currentDigit == code[3])
        {
            OnUnlockedEvent.Invoke();
        }
    }
}
