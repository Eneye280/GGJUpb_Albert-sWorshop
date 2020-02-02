using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseControl : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;
    
    public void Winner()
    {
        winPanel.SetActive(true);
    }
    public void Lose()
    {
        losePanel.SetActive(true);
    }

    public void NextWin(int level)
    {
        SceneManager.LoadScene(level);
    }
    public void Exit()
    {
        Application.Quit();
        print("salio");
    } 
}
