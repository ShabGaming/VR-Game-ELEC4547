using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand_Attack : MonoBehaviour
{
    public ScoreUpdate scoreUpdate;
    // This script is attached to the RightHand GameObject (blue).
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleJabB") || collision.gameObject.CompareTag("ObstacleB"))
        {
            if (collision.gameObject.CompareTag("ObstacleJabB"))
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
        } else {
            Debug.Log("Hit obstacle (WRONG COLOR)");
            Destroy(collision.gameObject);
            scoreUpdate.DeductPoints(1);
        }
    }
}
