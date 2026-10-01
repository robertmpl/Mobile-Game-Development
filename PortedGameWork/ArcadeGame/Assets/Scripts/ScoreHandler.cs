using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    public float score; // Overall score

    public TMP_Text scoreText;
    public TMP_Text gameOverScoreText;

    void UpdateScoreText() // Updates user interface
    {
        scoreText.text = score.ToString();
        gameOverScoreText.text = "Final Score: " + score;
    }

    public void AddScore(float scoreAddition) // Add score 
    {
        score += Mathf.Round(scoreAddition); // Round the score to prevent decimals
        
        UpdateScoreText();
    }
}
