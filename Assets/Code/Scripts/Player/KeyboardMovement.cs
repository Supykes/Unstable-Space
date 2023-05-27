using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    float speed = 2f;
    Vector3 startPosition;
    Vector3 targetPosition;
    bool isMoving;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            ControlMovement();
        }
    }

    void ControlMovement()
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

        if (Input.GetKeyDown("a") && transform.position.x != -6 && !ObstaclesMovement.isMoving)
        {
            targetPosition = transform.position + (Vector3.left * 2);
            startPosition = transform.position;

            isMoving = true;
        }
        else if (Input.GetKeyDown("d") && transform.position.x != 6 && !ObstaclesMovement.isMoving)
        {
            targetPosition = transform.position + (Vector3.right * 2);
            startPosition = transform.position;

            isMoving = true;
        }
    }
}