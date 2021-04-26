using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject options;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            if (options.activeInHierarchy == true)
            {
                options.SetActive(false);
            }
        }
        if (!GameIsPaused)
        {
            PersistentData.totalTime += Time.deltaTime;
        }

    }

    public void Resume ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Options()
    {
        Debug.Log("options");
    }

    public void QuitGame()
    {
        PersistentData.roomNo = 0;
        PersistentData.totalTime = 0;
        PersistentData.totalDeaths = 0;
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        SceneManager.LoadScene("Menu Scene");
        #endif
    }
}
