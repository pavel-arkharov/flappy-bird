using UnityEngine;

public class AddPoints : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			ScoreManager.Instance.AddScore(1);
			Destroy(gameObject);
		}
	}
}
