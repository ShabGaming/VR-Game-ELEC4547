using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // Reference to the TextMeshPro component
    public TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        // Set the score text to 0
        scoreText.text = "Score:0";
    }

    // function to add points
    public void AddPoints(int points)
    {
        // Get the current score
        int currentScore = int.Parse(scoreText.text.Substring(6));
        // Add the points
        currentScore += points;
        // Update the score text
        scoreText.text = "Score:" + currentScore;
    }

    // function to deduct points
    public void DeductPoints(int points)
    {
        // Get the current score
        int currentScore = int.Parse(scoreText.text.Substring(6));
        // Deduct the points
        currentScore -= points;
        // Update the score text
        scoreText.text = "Score:" + currentScore;
    }

    public int GetScore()
    {
        // Get the current score
        int currentScore = int.Parse(scoreText.text.Substring(6));
        return currentScore;
    }
}
