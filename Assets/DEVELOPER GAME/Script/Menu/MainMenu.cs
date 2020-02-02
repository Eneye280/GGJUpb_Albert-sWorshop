using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGamePlay(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
