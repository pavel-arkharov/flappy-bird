using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	[SerializeField] private GameObject deathOverlay; // Assign your Canvas in Inspector
	[SerializeField] private PipeSpawner pipeSpawner; // Assign in Inspector
	private PlayerInputActions inputActions;
	private bool canRestart = false;

	private void Awake()
	{
		inputActions = new PlayerInputActions();
	}

	private void OnEnable()
	{
		inputActions.Gameplay.Enable();
	}

	private void OnDisable()
	{
		inputActions.Gameplay.Disable();
	}

	public void TriggerGameOver(GameObject player)
	{
		Debug.Log("Game Over!");

		Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
		if (rb != null)
		{
			rb.linearVelocity = Vector2.zero;
			rb.bodyType = RigidbodyType2D.Static;
		}

		PlayerController controller = player.GetComponent<PlayerController>();
		if (controller != null)
		{
			controller.enabled = false;
		}

		if (pipeSpawner != null)
		{
			pipeSpawner.StopSpawning();
		}

		foreach (var scroller in Object.FindObjectsByType<BackgroundScroller>(FindObjectsSortMode.None))
		{
			scroller.enabled = false;
		}

		foreach (var pipe in Object.FindObjectsByType<PipeMover>(FindObjectsSortMode.None))
		{
			pipe.StopMoving();
		}

		deathOverlay.SetActive(true);
		canRestart = true;
	}

	private void Update()
	{
		if (canRestart && inputActions.Gameplay.Flap.triggered)
		{
			SceneManager.LoadScene("Game");
		}
	}
}