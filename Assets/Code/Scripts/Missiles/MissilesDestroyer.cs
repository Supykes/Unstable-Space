using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{
    public GameObject player;
    MissileSpawner missileSpawner;

    void Update()
    {
        for (int i = -4; i < 5; i += 2)
        {
            print(i + " " + missileSpawner.missileLanes[i]);
        }
    }

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