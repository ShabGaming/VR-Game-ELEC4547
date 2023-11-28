using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Create an array for song options and an index to keep track of the current selected song. Songs are labelled 1 - 4.
    public string[] songOptions = new string[] { "1", "2", "3", "4" };
    public int songIndex = 0;

    // Create an array for arena choices and an index to keep track of the current selected arena. Arenas are labelled 3 - 4.
    public string[] arenaOptions = new string[] { "3", "4" };
    public int arenaIndex = 0;

    // By default the game will start with the first song and arena selected.
    public int DefaultSongSelected = 1;
    public int DefaultArenaSelected = 3;

    // Reterieve collider of controller objects (there are 2, left hand and right hand).
    public GameObject leftHand;
    public GameObject rightHand;
    // Retrieve the collider of the song and arena objects.
    public GameObject song1;
    public GameObject song2;
    public GameObject song3;
    public GameObject song4;
    public GameObject arena3;
    public GameObject arena4;

    // A function to make the material of the selected song and arena objects (planes) to there alternate selection materials.
    // Array of materials for the song and arena objects.
    public Material[] songMaterials;
    public Material[] arenaMaterials;
    // Array of materials for "selected" song and arena objects.
    public Material[] songSelectedMaterials;
    public Material[] arenaSelectedMaterials;
    
    // Function to change the material of the song and arena objects to their alternate selection materials.
    public void ChangeSongMaterial(int songSelected, int ArenaSelected)
    {
        switch (songSelected)
        {
            case 1:
                song1.GetComponent<Renderer>().material = songSelectedMaterials[0];
                song2.GetComponent<Renderer>().material = songMaterials[1];
                song3.GetComponent<Renderer>().material = songMaterials[2];
                song4.GetComponent<Renderer>().material = songMaterials[3];
                break;
            case 2:
                song1.GetComponent<Renderer>().material = songMaterials[0];
                song2.GetComponent<Renderer>().material = songSelectedMaterials[1];
                song3.GetComponent<Renderer>().material = songMaterials[2];
                song4.GetComponent<Renderer>().material = songMaterials[3];
                break;
            case 3:
                song1.GetComponent<Renderer>().material = songMaterials[0];
                song2.GetComponent<Renderer>().material = songMaterials[1];
                song3.GetComponent<Renderer>().material = songSelectedMaterials[2];
                song4.GetComponent<Renderer>().material = songMaterials[3];
                break;
            case 4:
                song1.GetComponent<Renderer>().material = songMaterials[0];
                song2.GetComponent<Renderer>().material = songMaterials[1];
                song3.GetComponent<Renderer>().material = songMaterials[2];
                song4.GetComponent<Renderer>().material = songSelectedMaterials[3];
                break;
        }
        switch (ArenaSelected)
        {
            case 3:
                arena3.GetComponent<Renderer>().material = arenaSelectedMaterials[0];
                arena4.GetComponent<Renderer>().material = arenaMaterials[1];
                break;
            case 4:
                arena3.GetComponent<Renderer>().material = arenaMaterials[0];
                arena4.GetComponent<Renderer>().material = arenaSelectedMaterials[1];
                break;
        }
    }

    void Start ()
    {
        ChangeSongMaterial(DefaultSongSelected, DefaultArenaSelected);
    }

    // This script will be attatched to each of the hand objects.

    // Check for collision between the hand objects and the song and arena objects.
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Song1"))
        {
            ChangeSongMaterial(1, arenaIndex + 2);
            songIndex = 0;
        }
        else if (other.gameObject.CompareTag("Song2"))
        {
            ChangeSongMaterial(2, arenaIndex + 2);
            songIndex = 1;
        }
        else if (other.gameObject.CompareTag("Song3"))
        {
            ChangeSongMaterial(3, arenaIndex + 2);
            songIndex = 2;
        }
        else if (other.gameObject.CompareTag("Song4"))
        {
            ChangeSongMaterial(4, arenaIndex + 2);
            songIndex = 3;
        }
        else if (other.gameObject.CompareTag("Arena3"))
        {
            ChangeSongMaterial(songIndex + 1, 3);
            arenaIndex = 3;
        }
        else if (other.gameObject.CompareTag("Arena4"))
        {
            ChangeSongMaterial(songIndex + 1, 4);
            arenaIndex = 4;
        }
        else if (other.gameObject.CompareTag("Start"))
        {
            Debug.Log("Start");
            if (arenaIndex == 0)
            {
                ArenaInitialize.songSelected = songIndex + 1;
                ArenaInitialize.delay_initial = delay;
                SceneManager.LoadScene(1);
            }
            else if (arenaIndex == 1)
            {
                ArenaInitialize.songSelected = songIndex + 1;
                ArenaInitialize.delay_initial = delay;
                SceneManager.LoadScene(2);
            }
        }
    }

    int delay = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Delay 1");
            UpdateDelayText(1);
            delay = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Delay 2");
            UpdateDelayText(2);
            delay = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Delay 3");
            UpdateDelayText(3);
            delay = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Delay 4");
            UpdateDelayText(4);
            delay = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Delay 5");
            UpdateDelayText(5);
            delay = 5;
        }

        // Incase the user wants to use the keyboard to select the song and arena. We will use the square left and right brackets to circle through the song and arena options. Left bracked for arena, right bracket for song.
        // If the left bracket key is pressed
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            // If the arena index is 0
            if (arenaIndex == 0)
            {
                // Change the arena index to 1
                arenaIndex = 1;
                // Change the material of the arena objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 3);
            }
            // If the arena index is 1
            else if (arenaIndex == 1)
            {
                // Change the arena index to 0
                arenaIndex = 0;
                // Change the material of the arena objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 3);
            }
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            // If the song index is 0
            if (songIndex == 0)
            {
                // Change the song index to 1
                songIndex = 1;
                // Change the material of the song objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 2);
            }
            // If the song index is 1
            else if (songIndex == 1)
            {
                // Change the song index to 2
                songIndex = 2;
                // Change the material of the song objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 2);
            }
            // If the song index is 2
            else if (songIndex == 2)
            {
                // Change the song index to 3
                songIndex = 3;
                // Change the material of the song objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 2);
            }
            // If the song index is 3
            else if (songIndex == 3)
            {
                // Change the song index to 0
                songIndex = 0;
                // Change the material of the song objects to their alternate selection materials
                ChangeSongMaterial(songIndex + 1, arenaIndex + 2);
            }
        }
        // Escape key to start the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Start");
            if (arenaIndex == 0)
            {
                ArenaInitialize.songSelected = songIndex + 1;
                ArenaInitialize.delay_initial = delay;
                SceneManager.LoadScene(1);
            }
            else if (arenaIndex == 1)
            {
                ArenaInitialize.songSelected = songIndex + 1;
                ArenaInitialize.delay_initial = delay;
                SceneManager.LoadScene(2);
            }
        }
    }

    public TMPro.TextMeshProUGUI DelayText;
    void UpdateDelayText(int delayTextInt)
    {
        DelayText.text = "Difficulty:" + delayTextInt + "\n------------\n1 is Highest";
    }
}