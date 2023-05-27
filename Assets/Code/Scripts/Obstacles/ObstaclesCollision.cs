using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject player;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        CheckPlayerCollision();
    }

    void CheckPlayerCollision()
    {
        if ((player.transform.position.x == transform.position.x) && (transform.position.z == 0f))
        {
            PlayerHealth.healthCount--;
            playerHealth.RemoveHealthSquare();

            Destroy(gameObject);
        }
    }
}