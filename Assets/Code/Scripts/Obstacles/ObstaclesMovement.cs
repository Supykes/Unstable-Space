using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    float speed = 2f;
    public GameObject player;
    MissileSpawner missileSpawner;
    Vector3 startPosition;
    Vector3 targetPosition;
    public static bool isMoving;

    void Start()
    {
        missileSpawner = player.GetComponent<MissileSpawner>();
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
            if (Input.GetKeyDown("f"))
            {
                if (missileSpawner.missileLanes[(int)player.transform.position.x] != true)
                {
                    missileSpawner.missileLanes[(int)player.transform.position.x] = true;

                    targetPosition = transform.position + (Vector3.back * 2);
                    startPosition = transform.position;

                    isMoving = true;
                }
            }
            else if (Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -4) || (Input.GetKeyDown("d") && player.transform.position.x != 4))
            {
                targetPosition = transform.position + (Vector3.back * 2);
                startPosition = transform.position;

                isMoving = true;

            }

        }
    }
}