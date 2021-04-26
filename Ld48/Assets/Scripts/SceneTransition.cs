using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    List<string> scenes = new List<string> { "Room1", "Room2", "Room4", "Room5", "Room6", "Room7", "Room8", "Room9", "Room10", "Room11", "Room12", "Room13", "Room14", "Room15", "Room16", "Room17" };
    static List<string> unusedScenes = new List<string> {};
    private void Start()
    {
        if (unusedScenes.Count == 0)
        {
            unusedScenes = scenes;
        }
    }
    public void Die(){
        StartCoroutine(ReloadLevel());
    }
    public void Win()
    {
        if (PersistentData.roomNo <10){
            int nextRoomNo = Random.Range(0, unusedScenes.Count - 1);
            string nextRoom = unusedScenes[nextRoomNo];
            unusedScenes.RemoveAt(nextRoomNo);
            StartCoroutine(LoadLevel(nextRoom));
            PersistentData.roomNo += 1;
        } else
        {
            StartCoroutine(LoadLevel("Room18"));
        }
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
