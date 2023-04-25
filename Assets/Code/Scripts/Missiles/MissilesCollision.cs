using UnityEngine;

public class MissilesCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider obstacle)
    {
        Destroy(gameObject);
        Destroy(obstacle.gameObject);
    }
}