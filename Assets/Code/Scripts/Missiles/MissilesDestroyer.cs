using UnityEngine;

public class MissilesDestroyer : MonoBehaviour
{
    public GameObject player;
    MissileSpawner missileSpawner;

    void Update()
    {
        ClearMissileLanes();
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

    void ClearMissileLanes()
    {
        for (int i = -4; i < 5; i += 2)
        {
            GameObject missile = GameObject.Find("Missile(Clone)");

            if (missile && missile.transform.position.x != i)
            {
                missileSpawner.missileLanes[i] = false;
            }
        }
    }
}