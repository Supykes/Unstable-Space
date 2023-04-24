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
        Vector3 spawnPosition = transform.position + (Vector3.forward * 2);

        GameObject missile = Instantiate(missileToSpawn, spawnPosition, missileToSpawn.transform.rotation);
        missile.SetActive(true);
    }
}