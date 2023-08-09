using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissilesCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionSystem;
    PlayerHealth playerHealth;
    Dictionary<int, bool> missileLanes;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
        missileLanes = player.GetComponent<MissileSpawner>().missileLanes;
    }

    void OnTriggerEnter(Collider obstacle)
    {
        StartCoroutine(WaitToMarkMissileLane(0.002f, obstacle));
    }

    IEnumerator WaitToMarkMissileLane(float delayTime, Collider obstacle)
    {
        yield return new WaitForSeconds(delayTime);

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

        PlayExplosion(obstacle);
    }

    void PlayExplosion(Collider obstacle)
    {
        GameObject explosion = Instantiate(explosionSystem, obstacle.gameObject.transform.position, explosionSystem.transform.rotation);
        explosion.SetActive(true);

        explosion.GetComponent<ParticleSystem>().Play();
    }
}