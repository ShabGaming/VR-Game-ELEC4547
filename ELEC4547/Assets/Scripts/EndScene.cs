using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public static int score;
    public TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = "Score:" + score;
    }

    // Check for collision with the quit button and the hand box collider
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Start"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
