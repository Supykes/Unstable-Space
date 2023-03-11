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
        if ((player.transform.position.x == gameObject.transform.position.x) && (gameObject.transform.position.z == 0f))
        {
            PlayerHealth.healthCount--;
            Debug.Log(PlayerHealth.healthCount);

            Destroy(gameObject);
        }
    }
}