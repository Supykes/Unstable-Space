using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missileToSpawn;

    void Update()
    {
        if (Input.GetKeyDown("f") && !ObstaclesMovement.isMoving)
        {
            SpawnMissile();
        }
    }

    void SpawnMissile()
    {
        Vector3 spawnPosition = transform.position;

        GameObject missile = Instantiate(missileToSpawn, spawnPosition, missileToSpawn.transform.rotation);
        missile.transform.parent = GameObject.Find("Missiles").transform;
        missile.SetActive(true);
    }
}