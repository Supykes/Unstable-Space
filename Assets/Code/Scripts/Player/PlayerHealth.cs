using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public TMP_Text healthText;
    public static int healthCount = 3;
    public GameOverScreen gameOverScreen;

    void Update()
    {
        DisplayHealth();
    }

    void DisplayHealth()
    {
        if (healthCount == 0)
        {
            gameOverScreen.ShowGameOverView();

            healthCount = 3;
        }

        healthText.text = "Health: " + healthCount;
    }
}