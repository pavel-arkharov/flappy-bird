// 9/2/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // Speed at which the background scrolls
    public float backgroundWidth = 20f; // Width of the background sprite

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the background to the left
        transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

        // Check if the background has moved off-screen
        if (transform.position.x <= -backgroundWidth)
        {
            // Reset the position to create a looping effect
            transform.position += new Vector3(backgroundWidth * 2, 0, 0);
        }
    }
}