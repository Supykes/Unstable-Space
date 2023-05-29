using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Sprite healthSquare;
    public GameObject healthText;
    public static int healthCount;
    public GameOverScreen gameOverScreen;
    float previousHealthSquarePosition = 60f;

    void Awake()
    {
        healthCount = 3;
    }

    void Start()
    {
        for (int i = 0; i < healthCount; i++)
        {
            AddHealthSquare();
        }
    }

    void Update()
    {
        CheckHealth();
    }

    void CheckHealth()
    {
        if (healthCount == 0)
        {
            gameOverScreen.ShowGameOverView();
        }
    }

    public void AddHealthSquare()
    {
        GameObject panel = new GameObject("Panel");
        panel.AddComponent<CanvasRenderer>();
        panel.transform.localPosition = new Vector3(previousHealthSquarePosition, -2f, 0f);
        previousHealthSquarePosition += 50f;
        panel.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        Image image = panel.AddComponent<Image>();
        image.sprite = healthSquare;
        image.color = new Color(255f / 255f, 0f / 255f, 0f / 255f, 255f / 255f);

        panel.transform.SetParent(healthText.transform, false);
    }

    public void RemoveHealthSquare()
    {
        Destroy(healthText.transform.GetChild(healthCount).gameObject);

        previousHealthSquarePosition -= 50f;
    }
}