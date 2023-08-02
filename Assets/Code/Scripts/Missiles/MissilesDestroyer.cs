using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{
    public GameObject player;
    MissileSpawner missileSpawner;

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.transform.tag == "Missile")
        {
            int missileXCoordinate = collider.gameObject.GetComponent<MissileLane>().xCoordinate;

            missileSpawner.missileLanes[missileXCoordinate] = false;

            Destroy(collider.gameObject);
        }
    }
}