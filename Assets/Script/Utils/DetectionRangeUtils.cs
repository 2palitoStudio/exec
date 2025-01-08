// DetectionRangeUtils.cs
using UnityEngine;
using System;

public static class DetectionRangeUtils
{
    /// <summary>
    /// Creates a circle detection range with a trigger collider and optional visual border.
    /// </summary>
    /// <param name="parent">The parent GameObject to attach the range object.</param>
    /// <param name="radius">Radius of the detection range.</param>
    /// <param name="borderColor">Color of the visual border.</param>
    /// <param name="searchTag">Tag to detect the player.</param>
    /// <param name="onPlayerDetected">Callback when the player is detected.</param>
    /// <returns>The created GameObject with the detection range.</returns>
    public static GameObject CreateDetectionRange(
        GameObject parent,
        float radius,
        Color borderColor,
        string searchTag,
        Action<GameObject> onPlayerDetected)
    {
        // Create a new child GameObject
        GameObject rangeObject = new GameObject("DetectionRange");
        rangeObject.transform.parent = parent.transform;
        rangeObject.transform.localPosition = Vector3.zero;

        // Add CircleCollider2D as a trigger
        CircleCollider2D rangeCollider = rangeObject.AddComponent<CircleCollider2D>();
        rangeCollider.radius = radius;
        rangeCollider.isTrigger = true;

        // Add visual border using LineRenderer
        // LineRenderer lineRenderer = rangeObject.AddComponent<LineRenderer>();
        // lineRenderer.positionCount = 50;
        // lineRenderer.loop = true;
        // lineRenderer.startWidth = 0.05f;
        // lineRenderer.endWidth = 0.05f;
        // lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        // lineRenderer.startColor = borderColor;
        // lineRenderer.endColor = borderColor;

        // // Draw the circle outline
        // for (int i = 0; i < lineRenderer.positionCount; i++)
        // {
        //     float angle = i * 2 * Mathf.PI / lineRenderer.positionCount;
        //     Vector3 position = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
        //     lineRenderer.SetPosition(i, position);
        // }

        // Add detection behavior
        RangeDetector rangeDetector = rangeObject.AddComponent<RangeDetector>();
        rangeDetector.Initialize(searchTag, onPlayerDetected);

        return rangeObject;
    }
}
