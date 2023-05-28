using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Missile")
        {
            Destroy(collider.gameObject);
        }
    }
}