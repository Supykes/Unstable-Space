using UnityEngine;
using System.Collections.Generic;

public class MissilesCollision : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;
    Dictionary<int, bool> missileLanes;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        missileLanes = player.GetComponent<MissileSpawner>().missileLanes;
    }

    void OnTriggerEnter(Collider obstacle)
    {
        if (obstacle.gameObject.transform.tag == "Player")
        {
            PlayerHealth.healthCount--;
            playerHealth.RemoveHealthSquare();

            Destroy(gameObject);
        }

        if (obstacle.gameObject.transform.tag == "Enemy Missile" || obstacle.gameObject.transform.tag == "Enemy Spacecraft" || obstacle.gameObject.transform.tag == "Asteroid" ||
        obstacle.gameObject.transform.tag == "Large Asteroid")
        {
            int missileXCoordinate = gameObject.GetComponent<MissileLane>().xCoordinate;

            missileLanes[missileXCoordinate] = false;

            Destroy(obstacle.gameObject);
            Destroy(gameObject);
        }
    }
}