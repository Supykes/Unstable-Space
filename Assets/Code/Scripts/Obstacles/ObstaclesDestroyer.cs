using UnityEngine;
using System.Collections.Generic;

public class ObstaclesDestroyer : MonoBehaviour
{
    public GameObject obstaclesSpawner;
    Dictionary<int, bool> enemySpacecraftLanes;

    void Start()
    {
        enemySpacecraftLanes = obstaclesSpawner.transform.GetComponent<ObstaclesSpawner>().enemySpacecraftLanes;
    }

    void OnTriggerEnter(Collider obstacle)
    {
        Destroy(obstacle.gameObject);

        if (obstacle.gameObject.transform.tag == "Enemy Spacecraft")
        {
            int enemySpacecraftXCoordinate = obstacle.gameObject.transform.GetComponent<EnemySpacecraftLane>().xCoordinate;

            enemySpacecraftLanes[enemySpacecraftXCoordinate] = false;
        }
    }
}