using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Scene[,] scenes;
    public void Die(){
        StartCoroutine(ReloadLevel());
    }
    public void Win()
    {
        Scene nextRoom = scenes[PersistentData.floorNo,Random.Range(0,scenes.Length)];
        StartCoroutine(LoadLevel(nextRoom.name));
    }
    public Animator transition;
    IEnumerator LoadLevel(string newLevel)
    {
        transition.SetTrigger("Transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(newLevel);
    }
    IEnumerator ReloadLevel()
    {
        transition.SetTrigger("Transition");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
