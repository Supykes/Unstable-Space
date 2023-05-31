using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject smallAsteroid;
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
}