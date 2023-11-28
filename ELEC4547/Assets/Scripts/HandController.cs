using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    // List of game objects to hide at start but not disable
    public GameObject[] LeftHandPoints;
    public GameObject[] RightHandPoints;

    void Start()
    {
        // Hide the game objects means keep them active but dont render by disabling the mesh renderer
        foreach (GameObject obj in LeftHandPoints)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }
        foreach (GameObject obj in RightHandPoints)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    // Reference to the left and right glove game objects
    public GameObject leftGlove;
    public GameObject rightGlove;

    // Use the 'I' and 'O' keys to scale the gloves up and down. Use the arrow keys to move the gloves around. But if the M key is held while using the arrow keys, or I and O keys, then only the right glove will be affected. If the N key is held while using the arrow keys, or I and O keys, then only the left glove will be affected.
    void Update()
    {
        // If the M key is held down
        if (Input.GetKey(KeyCode.M))
        {
            // If the up arrow key is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move the right glove up
                rightGlove.transform.position += new Vector3(0, 0.1f, 0);
            }
            // If the down arrow key is pressed
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move the right glove down
                rightGlove.transform.position -= new Vector3(0, 0.1f, 0);
            }
            // If the left arrow key is pressed
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move the right glove left
                rightGlove.transform.position -= new Vector3(0.1f, 0, 0);
            }
            // If the right arrow key is pressed
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move the right glove right
                rightGlove.transform.position += new Vector3(0.1f, 0, 0);
            }
        }
        // If the N key is held down
        if (Input.GetKey(KeyCode.N))
        {
            // If the up arrow key is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                leftGlove.transform.position += new Vector3(0, 0.1f, 0);
            }
            // If the down arrow key is pressed
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move the left glove down
                leftGlove.transform.position -= new Vector3(0, 0.1f, 0);
            }
            // If the left arrow key is pressed
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move the left glove left
                leftGlove.transform.position -= new Vector3(0.1f, 0, 0);
            }
            // If the right arrow key is pressed
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move the left glove right
                leftGlove.transform.position += new Vector3(0.1f, 0, 0);
            }
        }
        // Scaling both gloves with the I and O keys
        // If the I key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Scale the left glove up
            leftGlove.transform.localScale += new Vector3(0.0005f, 0.0005f, 0.0005f);
            // Scale the right glove up
            rightGlove.transform.localScale += new Vector3(0.0005f, 0.0005f, 0.0005f);
        }
        // If the O key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            // Scale the left glove down
            leftGlove.transform.localScale -= new Vector3(0.0005f, 0.0005f, 0.0005f);
            // Scale the right glove down
            rightGlove.transform.localScale -= new Vector3(0.0005f, 0.0005f, 0.0005f);
        }
        // if the arrow keys are pressed without the M or N keys being held, move both gloves
        // If the up arrow key is pressed
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Move both gloves up
            leftGlove.transform.position += new Vector3(0, 0.1f, 0);
            rightGlove.transform.position += new Vector3(0, 0.1f, 0);
        }
        // If the down arrow key is pressed
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Move both gloves down
            leftGlove.transform.position -= new Vector3(0, 0.1f, 0);
            rightGlove.transform.position -= new Vector3(0, 0.1f, 0);
        }
        // If the left arrow key is pressed
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move both gloves left
            leftGlove.transform.position -= new Vector3(0.1f, 0, 0);
            rightGlove.transform.position -= new Vector3(0.1f, 0, 0);
        }
        // If the right arrow key is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Move both gloves right
            leftGlove.transform.position += new Vector3(0.1f, 0, 0);
            rightGlove.transform.position += new Vector3(0.1f, 0, 0);
        }

    }
}
