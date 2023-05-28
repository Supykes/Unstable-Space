using UnityEngine;
using System;
using TMPro;

public class MovesManager : MonoBehaviour
{
    public GameObject player;
    public TMP_Text movesLeftText;
    public TMP_Text distanceTravelledText;
    public TMP_Text totalDistanceTravelledText;
    MissileSpawner missileSpawner;
    int movesLeft = 5;
    int distanceTravelled = 0;

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            CountMovesLeft();
            CountDistanceTravelled();
        }
    }

    void CountMovesLeft()
    {
        if (missileSpawner.missileLanes.ContainsKey((int)player.transform.position.x))
        {
            if (((Input.GetKeyDown("f") && missileSpawner.missileLanes[(int)player.transform.position.x] != true) || Input.GetKeyDown("w") ||
            (Input.GetKeyDown("a") && player.transform.position.x != -4) || (Input.GetKeyDown("d") && player.transform.position.x != 4)) && !ObstaclesMovement.isMoving)
            {
                movesLeft--;
            }
        }

        if (movesLeft == 0)
        {
            movesLeft = 5;
        }

        movesLeftText.text = "Moves left: <color=#DAA520>" + movesLeft + "</color>";
    }

    void CountDistanceTravelled()
    {
        if (Input.GetKeyDown("w") && !ObstaclesMovement.isMoving)
        {
            distanceTravelled++;
        }

        distanceTravelledText.text = "Distance travelled: <color=#E7DF22>" + distanceTravelled + "</color>";

        totalDistanceTravelledText.text = "Total distance travelled: " + distanceTravelled;
    }
}