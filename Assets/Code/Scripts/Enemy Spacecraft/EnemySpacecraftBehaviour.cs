using UnityEngine;

public class EnemySpacecraftBehaviour : MonoBehaviour
{
    public GameObject missileToSpawn;
    GameObject missile;
    int randomIndex = -1;
    bool missileHasSpawned = false;

    void Update()
    {
        GetRandomIndex();

        ControlEnemySpacecraftBehaviour();

        ResetMissileStatus();
    }

    void GetRandomIndex()
    {
        if (Input.GetKeyDown("w"))
        {
            randomIndex = Random.Range(0, 2);
        }
    }

    void ControlEnemySpacecraftBehaviour()
    {
        if (randomIndex == 0 && !missileHasSpawned)
        {
            SpawnEnemyMissile();

            randomIndex = -1;
        }
    }

    void SpawnEnemyMissile()
    {
        int xCoordinate = (int)transform.position.x;
        Vector3 spawnPosition = new Vector3(xCoordinate, 0f, transform.position.z - 4f);

        missile = Instantiate(missileToSpawn, spawnPosition, missileToSpawn.transform.rotation);
        missile.transform.parent = GameObject.Find("Enemy Missiles").transform;
        missile.SetActive(true);

        missile.GetComponent<MissileLane>().xCoordinate = xCoordinate;

        missileHasSpawned = true;
    }

    void ResetMissileStatus()
    {
        if (missile == null)
        {
            missileHasSpawned = false;
        }
    }
}