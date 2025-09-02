// 9/2/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;

public class PipeMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which pipes move
    public float destroyXPosition = -10f; // X position where pipes are destroyed

    private bool isStopped = false;

    public void StopMoving()
    {
        isStopped = true;
    }

    void Update()
    {
        if (!isStopped)
        {
            // Move the pipe to the left
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }

        // Destroy the pipe if it moves off-screen
        if (transform.position.x <= destroyXPosition)
        {
            Destroy(gameObject);
        }
    }
}