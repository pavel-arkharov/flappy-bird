using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int Score { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText; // Assign in Inspector

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = Score.ToString();
    }
}