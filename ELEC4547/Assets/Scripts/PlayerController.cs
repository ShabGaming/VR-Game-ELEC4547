using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Script to control the player's movement (that is, the camera's movement)
    // This script is attached to the Main Camera parent object

    // Reference to the game object that is the player
    public GameObject player;
    public static float rotationoffset = 0;
    public static bool offset_enabled = false;

    // Use WASD to move the player
    void Update()
    {
        // Move forward
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }

        // Move backward
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * Time.deltaTime * 5);
        }

        // Move left
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * Time.deltaTime * 5);
        }

        // Move right
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 5);
        }

        // Height up
        if (Input.GetKey(KeyCode.Space))
        {
            player.transform.Translate(Vector3.up * Time.deltaTime * 5);
        }

        // Height down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.transform.Translate(Vector3.down * Time.deltaTime * 5);
        }

        // Use the 'insert' key to enable or disable the offset
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            offset_enabled = !offset_enabled;
        }

        // We are using a VR for orientation, so we can can not just rotate the camera but rather we have to continously offset rotation
        if (Input.GetKey(KeyCode.Q))
        {
            rotationoffset += 1;
        } else if (Input.GetKey(KeyCode.E))
        {
            rotationoffset -= 1;
        }

        // continuously rotate the camera by the offset in the y axis
        if (offset_enabled) {
            player.transform.Rotate(0, rotationoffset, 0);
        }
    }



}
