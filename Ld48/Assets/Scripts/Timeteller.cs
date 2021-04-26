using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeteller : MonoBehaviour
{
    Text text;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    void Update()
    {
        text.text = "Time:" + PersistentData.totalTime.ToString("#.00") + "\n" + "Deaths:" + PersistentData.totalDeaths;
    }
}
