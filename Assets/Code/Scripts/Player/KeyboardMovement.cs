using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public float speed = 2f;
    Vector3 startPosition;
    Vector3 targetPosition;
    bool isMoving;

    void Update()
    {
        ControlMovement();
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

        if (Input.GetKeyDown("a") && GameManager.sidePosition != -3)
        {
            targetPosition = transform.position + (Vector3.left * 2);
            startPosition = transform.position;

            isMoving = true;

            GameManager.sidePosition--;
        }
        else if (Input.GetKeyDown("d") && GameManager.sidePosition != 3)
        {
            targetPosition = transform.position + (Vector3.right * 2);
            startPosition = transform.position;

            isMoving = true;

            GameManager.sidePosition++;
        }
    }
}