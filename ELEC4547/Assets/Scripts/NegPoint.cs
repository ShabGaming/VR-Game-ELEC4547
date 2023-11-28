using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegPoint : MonoBehaviour
{
    // Reference to the ScoreUpdate script
    public ScoreUpdate scoreUpdate;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleB") ||
            collision.gameObject.CompareTag("ObstacleR") ||
            collision.gameObject.CompareTag("ObstacleJabR") ||
            collision.gameObject.CompareTag("ObstacleJabB"))
        {
            Debug.Log("Hit obstacle");
            Destroy(collision.gameObject);
            // Deduct point here
            scoreUpdate.DeductPoints(1);
        }
    }
}
