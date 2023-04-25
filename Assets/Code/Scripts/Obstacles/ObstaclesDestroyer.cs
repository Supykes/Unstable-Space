using UnityEngine;

public class ObstaclesDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider obstacle)
    {
        Destroy(obstacle.gameObject);
    }
}