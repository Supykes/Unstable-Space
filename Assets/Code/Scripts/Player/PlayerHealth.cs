using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int healthCount = 3;

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (healthCount == 0)
        {
            Debug.Log("No health");
        }
    }
}