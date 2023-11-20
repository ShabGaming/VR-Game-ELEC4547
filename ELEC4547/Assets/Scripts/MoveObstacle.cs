using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    // This script is used to move the obstacle in the game. This script is attached to the obstacle prefab hence it is used to move the all of the instances of the obstacle prefab.

    // The speed at which the obstacle moves
    public float speed = 8f;

    // The obstacle is to be moved constantly in the negative z direction
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
