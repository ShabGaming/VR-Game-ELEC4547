using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand_Attack : MonoBehaviour
{
    public ScoreUpdate scoreUpdate;
    // This script is attached to the LeftHand GameObject (left).
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleJabR") || collision.gameObject.CompareTag("ObstacleR"))
        {
            if (collision.gameObject.CompareTag("ObstacleJabR"))
            {
                Debug.Log("Hit obstacle (JAB)");
                Destroy(collision.gameObject);
                scoreUpdate.AddPoints(1);
            } else
            {
                Debug.Log("Hit obstacle");
                Destroy(collision.gameObject);
                scoreUpdate.AddPoints(1);
            }
        } else
        {
            Debug.Log("Hit obstacle (WRONG COLOR)");
            Destroy(collision.gameObject);
            scoreUpdate.DeductPoints(1);
        }
    }
}
