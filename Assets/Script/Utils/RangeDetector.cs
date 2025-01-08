// RangeDetector.cs
using UnityEngine;
using System;

public class RangeDetector : MonoBehaviour
{
    private string searchTag;
    private Action<GameObject> onPlayerDetected;

    /// <summary>
    /// Initialize the range detector with a tag filter and callback.
    /// </summary>
    /// <param name="searchTag">Tag to detect.</param>
    /// <param name="onPlayerDetected">Callback invoked when the player is detected.</param>
    public void Initialize(string searchTag, Action<GameObject> onPlayerDetected)
    {
        this.searchTag = searchTag;
        this.onPlayerDetected = onPlayerDetected;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Enter collision with tag {other.tag}");
        if (other.CompareTag(searchTag))
        {
            Debug.Log($"Found {searchTag}");
            onPlayerDetected?.Invoke(other.gameObject); // Pass the detected player GameObject
        }
    }
}
