using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates a ray from the hand to find interactive objects
/// </summary>
public class HandRayCast : MonoBehaviour
{
    [SerializeField, Tooltip("Line to show the ray")]
    /// <summary>Line to show the ray</summary>
    private RayLine Line;

    [SerializeField, Tooltip("Max ray distance")]
    /// <summary>Max ray distance</summary>
    private float MaxDistance = 5;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        Line.SetLinePoints(new Vector3[] { transform.position, transform.position + transform.up * MaxDistance });
        Line.MakeValid(ObjectInRay() != null);
    }

    /// <summary>
    /// Finds the first valid object in ray
    /// </summary>
    /// <returns>The object if there is one, null otherwise</returns>
    public Interactable ObjectInRay()
    {
        Ray ray = new Ray(origin: transform.position,
                            direction: transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray: ray,
                            hitInfo: out hit,
                            maxDistance: MaxDistance,
                            layerMask: LayerMask.GetMask("Interactable")))
        {
            return hit.collider.gameObject.GetComponent<Interactable>();
        }
        return null;
    }
}
