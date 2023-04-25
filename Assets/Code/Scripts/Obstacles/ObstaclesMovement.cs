using UnityEngine;

public class ObstaclesMovement : MonoBehaviour
{
    float speed = 2f;
    public GameObject player;
    Vector3 startPosition;
    Vector3 targetPosition;
    public static bool isMoving;

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

        if (Input.GetKeyDown("f") || Input.GetKeyDown("w") || (Input.GetKeyDown("a") && player.transform.position.x != -6) || (Input.GetKeyDown("d") && player.transform.position.x != 6))
        {
            targetPosition = transform.position + (Vector3.back * 2);
            startPosition = transform.position;

            isMoving = true;
        }
    }
}