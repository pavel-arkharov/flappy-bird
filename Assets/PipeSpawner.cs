// 9/2/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float minSpawnRate = 0.7f; // Minimum time between spawns
    public float maxSpawnRate = 2f;   
	public float maxY = -5.7f;
	public float minY = -10f;
	
	private bool spawning = true;

    private void Start()
	{
		StartCoroutine(SpawnPipeRoutine());
	}
	IEnumerator SpawnPipeRoutine()
    {
        while (spawning)
        {
            float yPosition = Random.Range(minY, maxY);
            Instantiate(pipePrefab, new Vector3(10, yPosition, 0), Quaternion.identity);

            // Get current score (replace with your ScoreManager reference)
            int score = ScoreManager.Instance != null ? ScoreManager.Instance.Score : 0;

            // Calculate spawn rate: higher score = faster spawn
            float spawnRate = Mathf.Lerp(maxSpawnRate, minSpawnRate, score / 50f); // Adjust 50 for difficulty curve
            yield return new WaitForSeconds(spawnRate);
        }
    }

	public void StopSpawning()
	{
		spawning = false;
		StopAllCoroutines();
	}
    
}