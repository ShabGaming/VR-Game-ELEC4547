using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    // First check what the total time is for the game. (it depends on the song)
    int totalTime = 204 + 2; // seconds by default
    void SetTimer()
    {
        // Set the timer to the total time of the song.
        if (ArenaInitialize.songSelected == 1)
        {
            totalTime = 204 + 2;
        } else if (ArenaInitialize.songSelected == 2)
        {
            totalTime = 169 + 5;
        } else if (ArenaInitialize.songSelected == 3)
        {
            totalTime = 189 + 1;
        } else if (ArenaInitialize.songSelected == 4)
        {
            totalTime = 156 + 0;
        }
    }

    // The goal of this script is to start when the game starts and run until the timer reaches 0. When the timer reaches 0, switch to the end screen scene. Before that we should reterive the score from the score script to display it on the end screen.
    public ScoreUpdate scoreUpdate;
    void EndGame()
    {
        // Get the score from the score script
        int score = scoreUpdate.GetScore();
        // Switch to the end screen scene
        EndScene.score = score;
        SceneManager.LoadScene(2);
    }

    // Start the timer and count down until it reaches 0. When it reaches 0, switch to the end screen scene using the EndGame() function.
    void Start()
    {
        SetTimer();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (totalTime > 0)
        {
            yield return new WaitForSeconds(1);
            totalTime--;
        }
        EndGame();
    }
}
