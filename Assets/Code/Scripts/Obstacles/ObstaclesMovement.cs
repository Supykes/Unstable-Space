using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    float speed = 2f;
    public GameObject player;
    public GameObject movesManagerGameObject;
    MissileSpawner missileSpawner;
    MovesManager movesManager;
    Vector3 startPosition;
    Vector3 targetPosition;
    public static bool isMoving;

    void Awake()
    {
        isMoving = false;
    }

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
        movesManager = movesManagerGameObject.GetComponent<MovesManager>();
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            MoveObstacles();
        }
    }

    void MoveObstacles()
    {
        if (isMoving)
        {
            if (Vector3.Distance(startPosition, transform.position) > 2f)
            {
                transform.position = targetPosition;

                isMoving = false;

                return;
            }

            transform.position += (targetPosition - startPosition) * speed * Time.deltaTime;

            return;
        }

        if (missileSpawner.missileLanes.ContainsKey((int)player.transform.position.x))
        {
            if ((Input.GetKeyDown("f") && missileSpawner.missileLanes[(int)player.transform.position.x] != true && movesManager.spacecraftStatuses[2] != true) || Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -4 && movesManager.spacecraftStatuses[3] != true) || (Input.GetKeyDown("d") && player.transform.position.x != 4 && movesManager.spacecraftStatuses[3] != true))
            {
                targetPosition = transform.position + (Vector3.back * 2);
                startPosition = transform.position;

                isMoving = true;
            }
        }
    }
}