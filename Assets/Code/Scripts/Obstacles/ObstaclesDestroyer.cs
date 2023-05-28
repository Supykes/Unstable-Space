using UnityEngine;
using System.Collections.Generic;

public class ObstaclesDestroyer : MonoBehaviour
{
    public GameObject obstacles;
    Dictionary<int, bool> enemySpacecraftLanes;

    void Start()
    {
        enemySpacecraftLanes = obstacles.transform.GetComponent<ObstaclesSpawner>().enemySpacecraftLanes;
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