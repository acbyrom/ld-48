using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void Options()
    {
        Debug.Log("options");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu Scene");
        PersistentData.roomNo = 0;
        PersistentData.totalTime = 0;
        PersistentData.totalDeaths = 0;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
