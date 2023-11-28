using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnObstacle : MonoBehaviour
{
    public Transform leftSpawnPoint;
    public Transform rightSpawnPoint;

    public GameObject obstaclePrefab;
    public GameObject obstaclePrefabJab;

    public Material redMaterial;
    public Material blueMaterial;

    // The left spawn can spawn the following obstacles:
    // 1. Red obstacle (left)
    // 2. Red obstacle (up)
    // 3. Red obstacle (jab)
    // 4. Blue obstacle (right)
    // 5. Blue obstacle (jab)
    // The right spawn can spawn the following obstacles:
    // 1. Blue obstacle (right)
    // 2. Blue obstacle (up)
    // 3. Blue obstacle (jab)
    // 4. Red obstacle (left)
    // 5. Red obstacle (jab)

    // By defult, the obstacle with direction is upwards hence it has to be rotated around the z axis by 90 degrees left or right depending on if it should be a right or left facing obstacle

    void SpawnObstacleAt(string spawner)
    {
        int random = Random.Range(1, 6);

        if (spawner == "left")
        {
            switch (random)
            {
                case 1:
                    GameObject obstacleInstance1 = Instantiate(obstaclePrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                    obstacleInstance1.transform.Rotate(0, 0, 90);
                    obstacleInstance1.GetComponent<Renderer>().material = redMaterial;
                    // change the tag of the obstacle to "ObstacleR"
                    obstacleInstance1.tag = "ObstacleR";
                    break;
                case 2:
                    GameObject obstacleInstance2 = Instantiate(obstaclePrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                    obstacleInstance2.transform.Rotate(0, 0, 180);
                    obstacleInstance2.GetComponent<Renderer>().material = redMaterial;
                    // change the tag of the obstacle to "ObstacleR"
                    obstacleInstance2.tag = "ObstacleR";
                    break;
                case 3:
                    GameObject obstacleInstance3 = Instantiate(obstaclePrefabJab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                    obstacleInstance3.GetComponent<Renderer>().material = redMaterial;
                    // change the tag of the obstacle to "ObstacleJabR"
                    obstacleInstance3.tag = "ObstacleJabR";
                    break;
                case 4:
                    GameObject obstacleInstance4 = Instantiate(obstaclePrefab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                    obstacleInstance4.transform.Rotate(0, 0, -90);
                    obstacleInstance4.GetComponent<Renderer>().material = blueMaterial;
                    // change the tag of the obstacle to "ObstacleB"
                    obstacleInstance4.tag = "ObstacleB";
                    break;
                case 5:
                    GameObject obstacleInstance5 = Instantiate(obstaclePrefabJab, leftSpawnPoint.position, leftSpawnPoint.rotation);
                    obstacleInstance5.GetComponent<Renderer>().material = blueMaterial;
                    // change the tag of the obstacle to "ObstacleJabB"
                    obstacleInstance5.tag = "ObstacleJabB";
                    break;
            }
        }
        else if (spawner == "right")
        {
            switch (random)
            {
                case 1:
                    GameObject obstacleInstance6 = Instantiate(obstaclePrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                    obstacleInstance6.transform.Rotate(0, 0, -90);
                    obstacleInstance6.GetComponent<Renderer>().material = blueMaterial;
                    // change the tag of the obstacle to "ObstacleB"
                    obstacleInstance6.tag = "ObstacleB";
                    break;
                case 2:
                    GameObject obstacleInstance7 = Instantiate(obstaclePrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                    obstacleInstance7.transform.Rotate(0, 0, 180);
                    obstacleInstance7.GetComponent<Renderer>().material = blueMaterial;
                    // change the tag of the obstacle to "ObstacleB"
                    obstacleInstance7.tag = "ObstacleB";
                    break;
                case 3:
                    GameObject obstacleInstance8 = Instantiate(obstaclePrefabJab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                    obstacleInstance8.GetComponent<Renderer>().material = blueMaterial;
                    // change the tag of the obstacle to "ObstacleJabB"
                    obstacleInstance8.tag = "ObstacleJabB";
                    break;
                case 4:
                    GameObject obstacleInstance9 = Instantiate(obstaclePrefab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                    obstacleInstance9.transform.Rotate(0, 0, 90);
                    obstacleInstance9.GetComponent<Renderer>().material = redMaterial;
                    // change the tag of the obstacle to "ObstacleR"
                    obstacleInstance9.tag = "ObstacleR";
                    break;
                case 5:
                    GameObject obstacleInstance10 = Instantiate(obstaclePrefabJab, rightSpawnPoint.position, rightSpawnPoint.rotation);
                    obstacleInstance10.GetComponent<Renderer>().material = redMaterial;
                    // change the tag of the obstacle to "ObstacleJabR"
                    obstacleInstance10.tag = "ObstacleJabR";
                    break;
            }
        }
    }

    // Start spawning obstacles when the game starts, both the left and right spawners will spawn obstacles at the same time. The spawner will spawn obstacles on both the left and right side at each beat of the song.
    void SpawnObstacleAtLeft()
    {
        SpawnObstacleAt("left");
    }

    void SpawnObstacleAtRight()
    {
        SpawnObstacleAt("right");
    }

    // Reference to text file containing beat level of each second. Each line in the text file represents the beat level of each second. The beat level is just a number that represents the beat level of each second.
    // Convert the text file into an array of floats.
    public TextAsset beatLevelTextFile;
    private float[] beatLevelArray;
    // Fill the array with the beat level of each second.
    void FillBeatLevelArray()
    {
        string[] beatLevelStringArray = beatLevelTextFile.text.Split('\n');
        beatLevelArray = new float[beatLevelStringArray.Length];
        for (int i = 0; i < beatLevelStringArray.Length; i++)
        {
            beatLevelArray[i] = float.Parse(beatLevelStringArray[i]);
        }
    }

    // Main Spawn Obstacle function which takes the a float as an argument.
    // The float represents the beat level of the current second.
    public int currentBeatLevelIndex = 0;
    public float lower_bound = 0.4f;
    public float upper_bound = 0.85f;

    void MainSpawnFunction()
    {
        float beatLevel = beatLevelArray[currentBeatLevelIndex];
        if (beatLevel >= upper_bound)
        {
            SpawnObstacleAtLeft();
            SpawnObstacleAtRight();
        }
        else if (beatLevel >= lower_bound && beatLevel < upper_bound)
        {
            int random = Random.Range(1, 3);
            if (random == 1)
            {
                SpawnObstacleAtLeft();
            }
            else
            {
                SpawnObstacleAtRight();
            }
        }
        print(beatLevel);
        currentBeatLevelIndex++;
    }

    public int delay = 1;
    void Start()
    {
        FillBeatLevelArray();
        InvokeRepeating("MainSpawnFunction", 0, delay);
    }
}

