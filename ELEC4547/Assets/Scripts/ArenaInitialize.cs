using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaInitialize : MonoBehaviour
{
    public static int songSelected;
    
    // Function to change the video material attatch to the video player to the selected song.
    // reference to the video player and 4 possible video clips.
    public UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.Video.VideoClip song1;
    public UnityEngine.Video.VideoClip song2;
    public UnityEngine.Video.VideoClip song3;
    public UnityEngine.Video.VideoClip song4;

    void ChangeVideoOfPlayer_skybox(int songSelected)
    {
        switch (songSelected)
        {
            case 1:
                videoPlayer.clip = song1;
                break;
            case 2:
                videoPlayer.clip = song2;
                break;
            case 3:
                videoPlayer.clip = song3;
                break;
            case 4:
                videoPlayer.clip = song4;
                break;
        }
    }

    public TextAsset beatLevelTextFile1;
    public TextAsset beatLevelTextFile2;
    public TextAsset beatLevelTextFile3;
    public TextAsset beatLevelTextFile4;

    // The SpawnObstacle.cs script reference to the text file that contains the beat level data.
    // Change the reference to the selected song's beat level data.
    public SpawnObstacle SpawnObstacle;
    void ChangeBeatLevelData(int songSelected)
    {
        switch (songSelected)
        {
            case 1:
                SpawnObstacle.beatLevelTextFile = beatLevelTextFile1;
                break;
            case 2:
                SpawnObstacle.beatLevelTextFile = beatLevelTextFile2;
                break;
            case 3:
                SpawnObstacle.beatLevelTextFile = beatLevelTextFile3;
                break;
            case 4:
                SpawnObstacle.beatLevelTextFile = beatLevelTextFile4;
                break;
        }
    }

    public static int delay_initial = 1;
    void Start()
    {
        // Change the video material attatch to the video player to the selected song.
        ChangeVideoOfPlayer_skybox(songSelected);

        // Change the reference to the selected song's beat level data.
        ChangeBeatLevelData(songSelected);

        SpawnObstacle.delay = delay_initial;
    }

    void Update()
    {
        // If keyboard '1/!' is pressed set SpawnObstacle.delay to 1
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Delay: 1");
            SpawnObstacle.delay = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Delay: 2");
            SpawnObstacle.delay = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Delay: 3");
            SpawnObstacle.delay = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {  
            Debug.Log("Delay: 4");
            SpawnObstacle.delay = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Delay: 5");
            SpawnObstacle.delay = 5;
        }// Escape key to goto main menu
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }
}
