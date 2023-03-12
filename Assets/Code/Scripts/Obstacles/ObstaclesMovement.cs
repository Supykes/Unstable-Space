using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    public GameObject player;
    const int obstaclesCount = 3;
    GameObject[] children = new GameObject[obstaclesCount];
    float speed = 2f;
    Vector3 startPosition;
    Vector3 targetPosition;
    public bool isMoving { get; private set; }
    float[,] randomAngles = new float[obstaclesCount, 3];

    void Awake()
    {
        GetChildren();
        RandomiseAngles();
    }

    void Update()
    {
        MoveObstacles();
        SpinObstacles();
    }

    void GetChildren()
    {
        for (int i = 0; i < obstaclesCount; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
    }

    void RandomiseAngles()
    {
        for (int i = 0; i < obstaclesCount; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                randomAngles[i, j] = Random.Range(0f, 15f);
            }
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

        if (Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -6) || (Input.GetKeyDown("d") && player.transform.position.x != 6))
        {
            targetPosition = transform.position + (Vector3.back * 2);
            startPosition = transform.position;

            isMoving = true;
        }
    }

    void SpinObstacles()
    {
        for (int i = 0; i < obstaclesCount; i++)
        {
            if (children[i] != null)
            {
                children[i].transform.Rotate(randomAngles[i, 0] * Time.deltaTime, randomAngles[i, 1] * Time.deltaTime, randomAngles[i, 2] * Time.deltaTime, Space.Self);
            }
        }
    }
}