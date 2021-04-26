using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        Debug.Log("options");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
