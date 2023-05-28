using UnityEngine;
using System.Collections.Generic;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemySpacecraft;
    public GameObject smallAsteroid;
    public GameObject mediumAsteroid;
    public GameObject largeAsteroid;
    MissileSpawner missileSpawner;
    GameObject[] obstacles = new GameObject[4];
    public static int randomObstacleIndex = -1;
    public static int randomXCoordinate;
    public static int previousRandomXCoordinate = -1;
    public Dictionary<int, bool> enemySpacecraftLanes = new Dictionary<int, bool>();

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();

        obstacles[0] = enemySpacecraft;
        obstacles[1] = smallAsteroid;
        obstacles[2] = mediumAsteroid;
        obstacles[3] = largeAsteroid;

        for (int i = -4; i < 5; i += 2)
        {
            enemySpacecraftLanes[i] = false;
        }

        SpawnRandomObstacle(Random.Range(1, 4), Random.Range(-2, 3) * 2);
    }

    void Update()
    {
        GetRandomNumbers();

        SpawnRandomObstacle();
    }

    void GetRandomNumbers()
    {
        if (missileSpawner.missileLanes.ContainsKey((int)player.transform.position.x))
        {
            if (((Input.GetKeyDown("f") && missileSpawner.missileLanes[(int)player.transform.position.x] != true) || Input.GetKeyDown("w") || (Input.GetKeyDown("a") &&
            player.transform.position.x != -4) || (Input.GetKeyDown("d") && player.transform.position.x != 4)) && !ObstaclesMovement.isMoving)
            {
                GetRandomXCoordinate();
                GetRandomObstacleIndex();
            }
        }
    }

    void GetRandomObstacleIndex()
    {
        randomObstacleIndex = Random.Range(0, 4);

        if (randomObstacleIndex == 0 && enemySpacecraftLanes[randomXCoordinate] == true)
        {
            GetRandomObstacleIndex();
        }
        else if (randomObstacleIndex == 0 && enemySpacecraftLanes[randomXCoordinate] == false)
        {
            enemySpacecraftLanes[randomXCoordinate] = true;
            enemySpacecraft.GetComponent<EnemySpacecraftLane>().xCoordinate = randomXCoordinate;
        }
    }

    void GetRandomXCoordinate()
    {
        randomXCoordinate = Random.Range(-2, 3) * 2;

        if (randomXCoordinate == previousRandomXCoordinate)
        {
            GetRandomXCoordinate();
        }
    }

    void SpawnRandomObstacle(int randomIndex, int randomCoordinate)
    {

        GameObject obstacle = obstacles[randomIndex];
        Vector3 spawnPosition = new Vector3(randomCoordinate, 0f, 12f);

        GameObject spawnedObstacle = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
        spawnedObstacle.transform.parent = transform;
        spawnedObstacle.SetActive(true);

        previousRandomXCoordinate = randomCoordinate;
        randomObstacleIndex = -1;
    }

    void SpawnRandomObstacle()
    {
        if (randomObstacleIndex >= 0 && randomObstacleIndex <= 3)
        {
            GameObject obstacle = obstacles[randomObstacleIndex];
            Vector3 spawnPosition = new Vector3(randomXCoordinate, 0f, 14f);

            GameObject spawnedObstacle = Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
            spawnedObstacle.transform.parent = transform;
            spawnedObstacle.SetActive(true);

            previousRandomXCoordinate = randomXCoordinate;
            randomObstacleIndex = -1;
        }
    }
}