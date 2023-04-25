using UnityEngine;

public class ObstaclesSpin : MonoBehaviour
{
    float[] randomAngles = new float[3];

    void Start()
    {
        RandomiseAngles();
    }

    void Update()
    {
        SpinObstacle();
    }

    void RandomiseAngles()
    {
        for (int i = 0; i < 3; i++)
        {
            randomAngles[i] = Random.Range(5f, 15f);
        }
    }

    void SpinObstacle()
    {
        if (transform.tag != "Enemy Spacecraft")
        {
            transform.Rotate(randomAngles[0] * Time.deltaTime, randomAngles[1] * Time.deltaTime, randomAngles[2] * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Rotate(0f, 0f, randomAngles[2] * Time.deltaTime, Space.Self);
        }
    }
}