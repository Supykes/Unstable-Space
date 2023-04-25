using UnityEngine;

public class MissilesMovement : MonoBehaviour
{
    float speed = 2f;
    public GameObject player;
    Vector3 startPosition;
    Vector3 targetPosition;
    public static bool isMoving;

    void Update()
    {
        MoveMissiles();
    }

    void MoveMissiles()
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
            targetPosition = transform.position + (Vector3.forward * 2);
            startPosition = transform.position;

            isMoving = true;
        }
    }
}