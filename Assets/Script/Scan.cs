using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scan : MonoBehaviour
{
    public void SelectGame()
    {
        SceneManager.LoadScene("SelectGame");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CT1()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void CT2()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void CT3()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
