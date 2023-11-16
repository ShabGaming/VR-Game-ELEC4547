using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

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
    void ChangeSongMaterial(int songSelected, int ArenaSelected)
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

    // Create a function to check if the controller is colliding with the song or arena objects. If yes, update the index of the song or arena and also update the material of the song and arena objects.
    
}
