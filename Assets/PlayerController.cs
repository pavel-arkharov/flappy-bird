// 9/2/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    private Rigidbody2D rb;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Initialize the Input Actions
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        // Enable the input actions
        inputActions.Gameplay.Enable();
        // Subscribe to the "Flap" action
        inputActions.Gameplay.Flap.performed += OnFlap;
    }

    private void OnDisable()
    {
        // Disable the input actions
        inputActions.Gameplay.Disable();
        // Unsubscribe from the "Flap" action
        inputActions.Gameplay.Flap.performed -= OnFlap;
    }

    private void OnFlap(InputAction.CallbackContext context)
    {
        // Apply upward velocity when the "Flap" action is performed
        rb.linearVelocity = Vector2.up * jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Killzone"))
        {
            Object.FindFirstObjectByType<GameOver>().TriggerGameOver(gameObject);
        }
    }
}