using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public GameObject movesManagerGameObject;
    MovesManager movesManager;
    float speed = 2f;
    Vector3 startPosition;
    Vector3 targetPosition;
    bool isMoving;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        movesManager = movesManagerGameObject.GetComponent<MovesManager>();
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
            if (movesManager.spacecraftStatuses[4] != true || ((startPosition.x == -2f && targetPosition.x == -4f) || (startPosition.x == 2f && targetPosition.x == 4f)))
            {
                if (Vector3.Distance(startPosition, transform.position) > 2f)
                {
                    transform.position = targetPosition;

                    isMoving = false;

                    return;
                }
            }
            else
            {
                if (Vector3.Distance(startPosition, transform.position) > 4f)
                {
                    transform.position = targetPosition;

                    isMoving = false;

                    return;
                }
            }


            transform.position += (targetPosition - startPosition) * speed * Time.deltaTime;

            return;
        }

        if (Input.GetKeyDown("a") && transform.position.x != -4 && !ObstaclesMovement.isMoving && movesManager.spacecraftStatuses[3] != true)
        {
            if (movesManager.spacecraftStatuses[4] != true)
            {
                targetPosition = transform.position + (Vector3.left * 2);
            }
            else if (movesManager.spacecraftStatuses[4] == true && transform.position.x != -2)
            {
                targetPosition = transform.position + (Vector3.left * 4);
            }
            else if (movesManager.spacecraftStatuses[4] == true && transform.position.x == -2)
            {
                targetPosition = transform.position + (Vector3.left * 2);
            }

            startPosition = transform.position;

            isMoving = true;
        }
        else if (Input.GetKeyDown("d") && transform.position.x != 4 && !ObstaclesMovement.isMoving && movesManager.spacecraftStatuses[3] != true)
        {
            if (movesManager.spacecraftStatuses[4] != true)
            {
                targetPosition = transform.position + (Vector3.right * 2);
            }
            else if (movesManager.spacecraftStatuses[4] == true && transform.position.x != 2)
            {
                targetPosition = transform.position + (Vector3.right * 4);
            }
            else if (movesManager.spacecraftStatuses[4] == true && transform.position.x == 2)
            {
                targetPosition = transform.position + (Vector3.right * 2);
            }

            startPosition = transform.position;

            isMoving = true;
        }
    }
}