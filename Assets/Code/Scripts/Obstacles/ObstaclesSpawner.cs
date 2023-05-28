using UnityEngine;
using System.Collections.Generic;

public class ObstaclesSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject enemySpacecraft;
    public GameObject smallAsteroid;
    public GameObject mediumAsteroid;
    public GameObject largeAsteroid;
    public GameObject movesManagerGameObject;
    MissileSpawner missileSpawner;
    MovesManager movesManager;
    GameObject[] obstacles = new GameObject[4];
    public static int randomObstacleIndex = -1;
    public static int randomXCoordinate;
    public static int previousRandomXCoordinate = -1;
    public Dictionary<int, bool> enemySpacecraftLanes = new Dictionary<int, bool>();

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
        movesManager = movesManagerGameObject.GetComponent<MovesManager>();

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
        if (GameManager.isInputEnabled)
        {
            GetRandomNumbers();

            SpawnRandomObstacle();
        }
    }

    void GetRandomNumbers()
    {
        if (missileSpawner.missileLanes.ContainsKey((int)player.transform.position.x))
        {
            if (((Input.GetKeyDown("f") && missileSpawner.missileLanes[(int)player.transform.position.x] != true && movesManager.spacecraftStatuses[2] != true) || Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -4 && movesManager.spacecraftStatuses[3] != true) || (Input.GetKeyDown("d") && player.transform.position.x != 4 && movesManager.spacecraftStatuses[3] != true)) && !ObstaclesMovement.isMoving)
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