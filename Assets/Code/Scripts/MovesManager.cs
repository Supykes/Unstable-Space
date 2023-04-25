using UnityEngine;
using TMPro;

public class MovesManager : MonoBehaviour
{
    public GameObject player;
    public TMP_Text movesLeftText;
    public TMP_Text distanceTravelledText;
    int movesLeft = 5;
    int distanceTravelled = 0;

    void Update()
    {
        CountMovesLeft();
        CountDistanceTravelled();
    }

    void CountMovesLeft()
    {
        if ((Input.GetKeyDown("f") || Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -6) || (Input.GetKeyDown("d") &&
        player.transform.position.x != 6)) && !ObstaclesMovement.isMoving)
        {
            movesLeft--;
        }

        if (movesLeft == 0)
        {
            movesLeft = 5;
        }

        movesLeftText.text = "Moves left: " + movesLeft;
    }

    void CountDistanceTravelled()
    {
        if (Input.GetKeyDown("w") && !ObstaclesMovement.isMoving)
        {
            distanceTravelled++;
        }

        distanceTravelledText.text = "Distance travelled: " + distanceTravelled;
    }
}