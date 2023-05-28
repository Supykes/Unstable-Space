using UnityEngine;
using System.Collections.Generic;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missileToSpawn;
    public GameObject movesManagerGameObject;
    MovesManager movesManager;
    public Dictionary<int, bool> missileLanes = new Dictionary<int, bool>();

    void Start()
    {
        movesManager = movesManagerGameObject.GetComponent<MovesManager>();

        for (int i = -4; i < 5; i += 2)
        {
            missileLanes[i] = false;
        }
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            if (missileLanes.ContainsKey((int)transform.position.x))
            {
                if (Input.GetKeyDown("f") && !ObstaclesMovement.isMoving && missileLanes[(int)transform.position.x] == false && movesManager.spacecraftStatuses[2] != true)
                {
                    SpawnMissile();
                }
            }
        }
    }

    void SpawnMissile()
    {
        int xCoordinate = (int)transform.position.x;
        Vector3 spawnPosition = new Vector3(xCoordinate, 0f, 2f);

        GameObject missile = Instantiate(missileToSpawn, spawnPosition, missileToSpawn.transform.rotation);
        missile.transform.parent = GameObject.Find("Missiles").transform;
        missile.SetActive(true);

        missile.GetComponent<MissileLane>().xCoordinate = xCoordinate;
    }
}