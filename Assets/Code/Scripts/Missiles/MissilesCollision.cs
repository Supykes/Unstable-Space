using UnityEngine;
using System.Collections.Generic;

public class MissilesCollision : MonoBehaviour
{
    Dictionary<int, bool> missileLanes;

    void Start()
    {
        missileLanes = GameObject.Find("Player").GetComponent<MissileSpawner>().missileLanes;
    }

    void OnTriggerEnter(Collider obstacle)
    {
        int missileXCoordinate = gameObject.GetComponent<MissileLane>().xCoordinate;

        missileLanes[missileXCoordinate] = false;
    }
}