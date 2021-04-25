using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    string[] scenes = {"Room1","Room2","Room4","Room5", "Room6", "Room7", "Room8", "Room9", "Room10", "Room11", "Room12", "Room13", "Room14", "Room15", "Room16" };
    public void Die(){
        StartCoroutine(ReloadLevel());
    }
    public void Win()
    {
        string nextRoom = scenes[Random.Range(0,scenes.Length-1)];
        StartCoroutine(LoadLevel(nextRoom));
        PersistentData.roomNo += 1;
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
