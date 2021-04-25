using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    string[,] scenes = {{"",""},{"",""}};
    public void Die(){
        StartCoroutine(ReloadLevel());
    }
    public void Win()
    {
        string nextRoom = scenes[PersistentData.floorNo,Random.Range(0,scenes.Length)];
        StartCoroutine(LoadLevel(nextRoom));
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
