using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject smallAsteroid;
    public GameObject explosionSystem;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Player")
        {
            PlayerHealth.healthCount--;
            playerHealth.RemoveHealthSquare();

            Destroy(gameObject);

            PlayExplosion(collider);
        }
        else if (collider.gameObject.transform.tag == "Missile" || collider.gameObject.transform.tag == "Enemy Missile")
        {
            if (gameObject.transform.tag == "Large Asteroid")
            {
                GameObject spawnedSmallAsteroid = Instantiate(smallAsteroid, gameObject.transform.position, gameObject.transform.rotation);
                spawnedSmallAsteroid.transform.parent = GameObject.Find("Obstacles").transform;
                spawnedSmallAsteroid.SetActive(true);
            }
        }
    }

    void PlayExplosion(Collider collider)
    {
        GameObject explosion = Instantiate(explosionSystem, collider.gameObject.transform.position, explosionSystem.transform.rotation);
        explosion.SetActive(true);

        explosion.GetComponent<ParticleSystem>().Play();
    }
}