using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Casts a parabolic ray to find objects
/// </summary>
public class HandRayCastParabolic : MonoBehaviour
{
    [SerializeField, Tooltip("Line to show the ray")]
    /// <summary>Line to show the ray</summary>
    private RayLine Line;

    [SerializeField, Tooltip("Max ray distance (horizontally)")]
    /// <summary>Max ray distance (horizontally)</summary>
    private float MaxDistance = 5;

    [SerializeField, Tooltip("Distance step (horizontally)")]
    /// <summary>Distance step (horizontally)</summary>
    private float SpaceInterval = .05f;

    /// <summary>Points defining the parabol</summary>
    private List<Vector3> CurveControlPoints = new List<Vector3>();

    /// <summary>First encountered object. Declared as a nullable RaycastHit</summary>
    private RaycastHit? collision;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    public void Update()
    {
        // Initialize object lookup
        collision = null;
        float coveredDistance = 0;

        // Initialize positions list for ray rendering
        CurveControlPoints.Clear();
        CurveControlPoints.Add(transform.position);

        // Check step by step for objects
        while (coveredDistance < MaxDistance && collision == null)
        {
            // Find starting position (moving forward by the covered distance and setting height to thrown object height)
            Vector3 startPos = transform.position + transform.forward * coveredDistance;
            startPos.y = HeightAt(coveredDistance);

            // Find starting position (moving forward by the covered distance+interval and setting height to thrown object height)
            Vector3 endPos = transform.position + transform.forward * (coveredDistance + SpaceInterval);
            endPos.y = HeightAt(coveredDistance + SpaceInterval);

            collision = ObjectInSection(startPos, endPos);

            // Add next position to the ray
            if (collision != null)    // Object found, set next position to this object's center
            {
                CurveControlPoints.Add(collision.Value.point);
            }
            else    // No object found, set next position to next step
            {
                CurveControlPoints.Add(endPos);
            }

            // Move to next section
            coveredDistance += SpaceInterval;
        }

        // Update the ray
        Line.SetLinePoints(CurveControlPoints);
        Line.MakeValid(collision != null);

    }

    /// <summary>
    /// Checks for objects within a given line
    /// </summary>
    /// <param name="start">Start of the line</param>
    /// <param name="end">End of the line</param>
    /// <returns>The objects's colliding info if there is one, null otherwise</returns>
    public RaycastHit? ObjectInSection(Vector3 start, Vector3 end)
    {
        // @TODO: Complete this function to look for objects between the start and end positions. Check only for objects with the "Walk" layer
        return null;
    }

    /// <summary>
    /// Returns the position of the collision
    /// </summary>
    /// <returns>XYZ coordinates of the collision</returns>
    public Vector3 CollidingPosition()
    {
        return collision.Value.point;
    }

    /// <summary>
    /// Returns the height at a given distance away from the start
    /// Based on the physics equations for a thrown object
    /// </summary>
    /// <param name="x">Distance from the starting point in meters</param>
    private float HeightAt(float x)
    {
        // Find intial speed needed to attain max distance (sqrt(g*dist)), with g being negative in Unity
        float initialSpeed = Mathf.Sqrt(MaxDistance * -Physics.gravity.y);

        // Compute the angle horizontal/direction of the controller : a = acos(|horizontal|.|direction|)
        float a = Mathf.Acos(Vector3.Dot(Vector3.Normalize(new Vector3(transform.forward.x, 0, transform.forward.z)), transform.forward));
        // If not horizontal, check if the angle goes upward or downward
        if (transform.forward.y != 0) a *= (transform.forward.y / Mathf.Abs(transform.forward.y));

        // Get the result : -gx²/2cos²(a)v² + tan(a)x + h (where h is the starting height, g the gravity and v the initial velocity)
        float height = -0.5f * ((-Physics.gravity.y * Mathf.Pow(x, 2)) / (Mathf.Pow(Mathf.Cos(a) * initialSpeed, 2)))
            + (Mathf.Tan(a) * x) + transform.position.y;

        if (float.IsNaN(height))
            return -1000f;
        else
            return height;
    }
}