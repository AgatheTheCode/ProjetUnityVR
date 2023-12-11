using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the line rendering for a ray
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class RayLine : MonoBehaviour
{
    [SerializeField, Tooltip("Material when ray is invalid")]
    /// <summary>Material when ray is invalid</summary>
    private Material InvalidMaterial;

    [SerializeField, Tooltip("Material when ray is valid")]
    /// <summary>Material when ray is valid</summary>
    private Material ValidMaterial;

    /// <summary>
    /// Changes the color depending on the ray validity
    /// </summary>
    /// <param name="valid">Is the ray considered valid?</param>
    public void MakeValid(bool valid)
    {
        GetComponent<LineRenderer>().material = valid ? ValidMaterial : InvalidMaterial;
    }

    /// <summary>
    /// Sets the positions of the points along the line
    /// </summary>
    /// <param name="positions">List of positions</param>
    public void SetLinePoints(List<Vector3> positions)
    {
        // Update the ray
        GetComponent<LineRenderer>().positionCount = positions.Count;
        GetComponent<LineRenderer>().SetPositions(positions.ToArray());
    }

    /// <summary>
    /// Sets the positions of the points along the line
    /// </summary>
    /// <param name="positions">Array of positions</param>
    public void SetLinePoints(Vector3[] positions)
    {
        // Update the ray
        GetComponent<LineRenderer>().positionCount = positions.Length;
        GetComponent<LineRenderer>().SetPositions(positions);
    }
}
