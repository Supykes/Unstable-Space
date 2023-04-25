using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject playerView;
    public GameObject gameOverBackground;

    public void ShowGameOverView()
    {
        GameManager.isInputEnabled = false;

        gameOverBackground.SetActive(true);

        playerView.SetActive(false);
    }
}