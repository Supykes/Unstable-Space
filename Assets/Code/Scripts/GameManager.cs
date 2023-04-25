using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isInputEnabled;

    void Awake()
    {
        isInputEnabled = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}