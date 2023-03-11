using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    float speed = 2f;
    Vector3 startPosition;
    Vector3 targetPosition;
    bool isMoving;
    float xAngle, yAngle, zAngle;

    void Start()
    {
        RandomiseAngles();
    }

    void Update()
    {
        MoveObstacles();
        SpinObstacles();
    }

    void RandomiseAngles()
    {
        xAngle = Random.Range(0f, 15f);
        yAngle = Random.Range(0f, 15f);
        zAngle = Random.Range(0f, 15f);
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

        if (Input.GetKeyDown("w") || (Input.GetKeyDown("a") && GameManager.sidePosition != -3) || (Input.GetKeyDown("d") && GameManager.sidePosition != 3))
        {
            targetPosition = transform.position + (Vector3.back * 2);
            startPosition = transform.position;

            isMoving = true;
        }
    }

    void SpinObstacles()
    {
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);
    }
}