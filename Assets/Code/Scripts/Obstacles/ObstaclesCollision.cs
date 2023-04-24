using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        CheckCollision();
    }

    void CheckCollision()
    {
        if ((player.transform.position.x == transform.position.x) && (transform.position.z == 0f))
        {
            PlayerHealth.healthCount--;

            Destroy(gameObject);
        }
    }
}