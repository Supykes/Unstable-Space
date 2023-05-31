using UnityEngine;
using System.Collections;
using TMPro;

public class MovesManager : MonoBehaviour
{
    public GameObject player;
    public TMP_Text movesLeftText;
    public TMP_Text distanceTravelledText;
    public TMP_Text totalDistanceTravelledText;
    public TMP_Text currentStatusText;
    MissileSpawner missileSpawner;
    public bool[] spacecraftStatuses = new bool[5];
    int randomStatusIndex = 0;
    int previousRandomStatusIndex = 0;
    int movesLeft = 5;
    int distanceTravelled = 0;

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
    }

    void Update()
    {
        CountMovesLeft();
        CountDistanceTravelled();

        ControlSpacecraftStatuses();
    }

    void CountMovesLeft()
    {
        if (missileSpawner.missileLanes.ContainsKey((int)player.transform.position.x))
        {
            if (((Input.GetKeyDown("f") && missileSpawner.missileLanes[(int)player.transform.position.x] != true && spacecraftStatuses[2] != true) || Input.GetKeyDown("w") ||
            (Input.GetKeyDown("a") && player.transform.position.x != -4 && spacecraftStatuses[3] != true) || (Input.GetKeyDown("d") && player.transform.position.x != 4 && spacecraftStatuses[3] != true)) && !ObstaclesMovement.isMoving && GameManager.isInputEnabled)
            {
                movesLeft--;
            }
        }

        if (movesLeft == 0)
        {
            movesLeft = 5;

            GetRandomStatusIndex();
        }

        movesLeftText.text = "Moves left: <color=#DAA520>" + movesLeft + "</color>";
    }

    void CountDistanceTravelled()
    {
        if (Input.GetKeyDown("w") && !ObstaclesMovement.isMoving && GameManager.isInputEnabled)
        {
            distanceTravelled++;
        }

        distanceTravelledText.text = "Distance travelled: <color=#E7DF22>" + distanceTravelled + "</color>";

        totalDistanceTravelledText.text = "Total distance travelled: " + distanceTravelled;
    }

    void GetRandomStatusIndex()
    {
        randomStatusIndex = Random.Range(0, 5);

        if (randomStatusIndex == previousRandomStatusIndex)
        {
            GetRandomStatusIndex();
        }
    }

    void ControlSpacecraftStatuses()
    {
        switch (randomStatusIndex)
        {
            case -1:
                StartCoroutine(WaitToChangeStatus(0.6f, 0, 1));

                break;
            case 0:
                StartCoroutine(WaitToChangeStatus(0.6f, 0, randomStatusIndex));

                currentStatusText.text = "<color=#DAA520>Current status:</color>\n<color=#008000><size=30><i>All systems are operational!</i></size></color>";

                break;
            case 1:
                StartCoroutine(WaitToChangeStatus(0.6f, 1, randomStatusIndex));

                currentStatusText.text = "<color=#DAA520>Current status:</color>\n<color=#008000><size=30><i>Additional health received!</i></size></color>";

                PlayerHealth.healthCount++;
                player.GetComponent<PlayerHealth>().AddHealthSquare();

                randomStatusIndex = -1;

                break;
            case 2:
                StartCoroutine(WaitToChangeStatus(0.6f, 2, randomStatusIndex));

                currentStatusText.text = "<color=#DAA520>Current status:</color>\n<color=#FF0000><size=30><i>Weapon system failure!</i></size></color>";

                break;
            case 3:
                StartCoroutine(WaitToChangeStatus(0.6f, 3, randomStatusIndex));

                currentStatusText.text = "<color=#DAA520>Current status:</color>\n<color=#FF0000><size=30><i>Control system failure!</i></size></color>";

                break;
            case 4:
                StartCoroutine(WaitToChangeStatus(0.6f, 4, randomStatusIndex));

                currentStatusText.text = "<color=#DAA520>Current status:</color>\n<color=#FF0000><size=30><i>Control system malfunction!</i></size></color>";

                break;
        }
    }

    IEnumerator WaitToChangeStatus(float delayTime, int statusIndex, int randomStatusIndex)
    {
        yield return new WaitForSeconds(delayTime);

        spacecraftStatuses = new bool[5];
        spacecraftStatuses[statusIndex] = true;

        previousRandomStatusIndex = randomStatusIndex;
    }
}