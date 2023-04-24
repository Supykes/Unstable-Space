using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public static int healthCount = 3;

    void Update()
    {
        DisplayHealth();
    }

    void DisplayHealth()
    {
        if (healthCount == 0)
        {
            healthText.text = "Game Over";

            return;
        }

        healthText.text = "Health: " + healthCount;
    }
}